using BirdGame.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using Microsoft.Identity;
using System.Text.Json;
using System.Net.WebSockets;
using System.Runtime.Intrinsics.X86;

namespace CSCI3600.API;

[ApiController]
[Route("/api/[controller]")]
public class AdoptController : ControllerBase
{
    private readonly ILogger<AdoptController> _logger;
    private readonly BirdDbContext _context;

    public AdoptController(
        ILogger<AdoptController> logger,
        BirdDbContext context
    )
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet]
    public async Task<UserGame> GetAdoptAsync()
    {
        return await _context.UserGames
            .Include(ug => ug.rolledSSBs.OrderBy(r => r.SlotNum))
                .ThenInclude(bc => bc.Bird)
            .Include(ug => ug.sideShopBirds.OrderBy(ss => ss.SlotNum))
                .ThenInclude(bc => bc.Bird)
            .Where(ug => ug.Id == User.Identity.Name)
            .SingleAsync();
    }

    [HttpPost]
    public async Task<ActionResult> PostAdoptAsync(IHttpContextAccessor contextAccessor)
    {
        var reader = new StreamReader( Request.Body );
        string JSON = await reader.ReadToEndAsync();
        AdoptButton button = JsonSerializer.Deserialize<AdoptButton>(JSON);
        _logger.LogInformation($"trying to add {button.buttonId}");
        int bId = new int();
        Int32.TryParse(button.buttonId, out bId);
        try
        {
            UserGame UserGameEntity = await _context.UserGames
                .Include(ug => ug.OwnedBirds)
                    .ThenInclude(bc => bc.Bird)
                .Include(ug => ug.rolledSSBs.OrderBy(r => r.SlotNum))
                    .ThenInclude(bc => bc.Bird)
                .Include(ug => ug.sideShopBirds.OrderBy(ss => ss.SlotNum))
                    .ThenInclude(bc => bc.Bird)
                .Where(ug => ug.Id == User.Identity.Name)
                .SingleAsync();
            Bird newBird = UserGameEntity.rolledSSBs[bId].Bird;
            Bird nullBird = await _context.Birds
                .Where(b => b.Id == 999)
                .SingleAsync();
            List<int> whereCombine1Star = new List<int>();
            List<int> whereCombine2Star = new List<int>();
            int combineInt = whatCombine(newBird, UserGameEntity, ref whereCombine1Star, ref whereCombine2Star);
            if (combineInt > 0) {
                combineBirds(combineInt, whereCombine1Star, whereCombine2Star, newBird, nullBird, UserGameEntity);
                changeRollBird(UserGameEntity, nullBird, bId);
            }
            else {
                if (isSSFull(UserGameEntity)) {
                    return Ok();
                }
                int emptyIndex = findEmptyIndex(UserGameEntity);
                changeRollBird(UserGameEntity, nullBird, bId);
                changeSSBird(UserGameEntity, newBird, emptyIndex);
            }
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unable to Adopt");
            return StatusCode(500, ex);
        }
        return Ok();
    }

    void changeRollBird(UserGame UserGameEntity, Bird nullBird, int bId) {
        _context.RolledSSBs.RemoveRange(_context.RolledSSBs
            .Where(r => r.User.Id == UserGameEntity.Id 
                && r.SlotNum == bId));
        _context.Add(new RolledSSB {
            User = UserGameEntity, 
            Bird = nullBird, 
            SlotNum = bId
        });
    }

    void changeSSBird(UserGame UserGameEntity, Bird newBird, int emptyIndex) {
        _context.SideShopBirds.RemoveRange(_context.SideShopBirds
            .Where(r => r.User.Id == UserGameEntity.Id 
                && r.SlotNum == emptyIndex));
        _context.Add(new SideShopBird {
            User = UserGameEntity,
            Bird = newBird,
            SlotNum = emptyIndex,
        });
    }

    int findEmptyIndex(UserGame UserGameEntity) {
        for (int i = 0; i < 7; i++) {
            if (UserGameEntity.sideShopBirds[i].Bird.Id == 999) {
                return i;
            }
        }
        return -1;
    }

    bool isSSFull(UserGame UserGameEntity) {
        for (int i = 0; i < 7; i++) {
            if (UserGameEntity.sideShopBirds[i].Bird.Id == 999) {
                return false;
            }
        }
        return true;
    }

    int whatCombine(Bird bird, UserGame UserGameEntity, ref List<int> wC1, ref List<int> wC2) {
        int count = 0;
        int star2Count = 0;
        for (int i = 0; i < 7; i++ ) {
            if (UserGameEntity.sideShopBirds[i].Star == 1 
                && UserGameEntity.sideShopBirds[i].Bird.Id == bird.Id)  {
                count += 1;
                wC1.Add(i);
            }
            if (UserGameEntity.sideShopBirds[i].Star == 2 
                && UserGameEntity.sideShopBirds[i].Bird.Id == bird.Id) {
                star2Count += 1;
                wC2.Add(i);
            }
        }
        if (star2Count >= 2 && count >= 2) {
            return 2;
        }
        if (count >= 2) {
            return 1;
        }
        return 0;
    }

    void combineBirds(int star, List<int> wC1, List<int> wC2, Bird bird, Bird nullBird, UserGame UserGameEntity) {
        _context.SideShopBirds.RemoveRange(_context.SideShopBirds
            .Where(ss => ss.User.Id == UserGameEntity.Id
                && ss.Bird.Id == bird.Id
                && ss.Star == 1));
        int emptyIndex = findEmptyIndex(UserGameEntity);
        if (star == 1) {
            _context.SideShopBirds.RemoveRange(_context.SideShopBirds
            .Where(ss => ss.User.Id == UserGameEntity.Id
                && ss.SlotNum == emptyIndex));
            _context.Add(new SideShopBird {
                User = UserGameEntity,
                Bird = bird,
                Star = 2,
                SlotNum = emptyIndex
            });
        }
        else {
            _context.SideShopBirds.RemoveRange(_context.SideShopBirds
            .Where(ss => ss.User.Id == UserGameEntity.Id
                && ss.Bird.Id == bird.Id
                && ss.Star == 2));
            _context.Add(new BirdConnector {
                User = UserGameEntity,
                Bird = bird
            });
            foreach (int combineIndex in wC2) {
                _context.Add(new SideShopBird {
                    User = UserGameEntity,
                    Bird = nullBird,
                    SlotNum = combineIndex
                });
            }
        }
        foreach (int combineIndex in wC1) {
            if (combineIndex != emptyIndex) {
                _context.Add(new SideShopBird {
                    User = UserGameEntity,
                    Bird = nullBird,
                    SlotNum = combineIndex
                });
            }
        }
    }
}