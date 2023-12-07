using BirdGame.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Logging;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BirdGame.Pages;

public class AdoptModel : PageModel
{
    private readonly BirdDbContext _context;
    private readonly ILogger<AdoptModel> _logger;

    [BindProperty]
    public UserGame UserGameEntity { get; set; }

    public AdoptModel(BirdDbContext context, ILogger<AdoptModel> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task OnGetAsync()
    {
        UserGameEntity = await _context.UserGames
            .Include(ug => ug.OwnedBirds)
                .ThenInclude(bc => bc.Bird)
            .Include(ug => ug.rolledSSBs)
                .ThenInclude(bc => bc.Bird)
            .Include(ug => ug.sideShopBirds)
                .ThenInclude(bc => bc.Bird)
            .Where(ug => ug.Id == User.Identity.Name)
            .SingleAsync();
    }

    public IActionResult OnPostReroll() {
        Console.WriteLine(UserGameEntity.Id);
        if (UserGameEntity.Seeds >= 2) {
            UserGameEntity.Seeds -= 2;
            _context.Entry(UserGameEntity).State = EntityState.Modified;
            _context.SaveChanges();
            Reroll();
            return Redirect("./Adopt");
        }
        return Redirect("./Adopt");
    }

    public void Reroll() {
        assignNewSSBirds();
    }

    int getRarity() {
        var rand = new Random();
        int roll = rand.Next(81);
        roll += UserGameEntity.RarityUpgrade * (50 / (UserGameEntity.RarityUpgrade + 1));
        
        if (roll < 50) {
            return 0;
        }
        if (roll < 75) {
            return 1;
        }
        if (roll < 100) {
            return 2;
        }
        if (roll < 111) {
            return 3;
        }
        return 4;
    }

    Bird getBird(int rarity) {
        List<Bird> birds = _context.Birds
            .Where(b => b.Rarity == rarity)
            .ToList();
        var rand = new Random();
        int bIndex = rand.Next(birds.Count);
        return birds[bIndex];
    }

    void assignNewSSBirds() {
        _context.RolledSSBs.RemoveRange(_context.RolledSSBs
            .Where(b => b.User.Id == UserGameEntity.Id));
        _context.SaveChanges();
        for (int i = 0; i < 3; i++) {
            Bird newBird = getBird(getRarity());
            _context.Add(new RolledSSB {User = UserGameEntity, Bird = newBird});
        }
        _context.SaveChanges();
    }
}
