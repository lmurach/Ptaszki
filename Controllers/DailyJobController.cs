using BirdGame.Data;
using BirdGame.ControllerData;
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
public class DailyJobController : ControllerBase
{
    private readonly ILogger<DailyJobController> _logger;
    private readonly BirdDbContext _context;

    public DailyJobController(
        ILogger<DailyJobController> logger,
        BirdDbContext context
    )
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet]
    public async Task<List<Yield>> GetAdoptAsync()
    {
        return await _context.Yields
            .Include(ug => ug.Bird)
            .Where(y => y.User.Id == User.Identity.Name
                && y.Date == DateTime.Today)
            .ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult> PostAdoptAsync()
    {
        var reader = new StreamReader( Request.Body );
        string JSON = await reader.ReadToEndAsync();
        DailyJob jobs = JsonSerializer.Deserialize<DailyJob>(JSON);
        try
        {
            UserGame UserGameEntity = await _context.UserGames
                .Include(ug => ug.jobBirds.OrderBy(jb => jb.SlotNum))
                    .ThenInclude(jb => jb.Bird)
                .Include(ug => ug.userIRs)
                    .ThenInclude(ir => ir.BasicItem)
                .Include(ug => ug.Yields)
                    .ThenInclude(y => y.Bird)
                .Where(ug => ug.Id == User.Identity.Name)
                .SingleAsync();
            // if (UserGameEntity.LastDailyRoll == DateTime.Today) {
            //     return Ok();
            // }
            List<string> jobStrings = JobFunctions.JobObjToStringList(jobs);
            for (int i = 0; i < 5; i++) {
                if (jobStrings[i] != ""){
                    UserGameEntity.LastDailyRoll = DateTime.Today;
                    if (jobStrings[i].ToLower() == "seed-collector"){
                        UserGameEntity.Seeds += 50;
                        _context.Yields.Add(new Yield {
                            User = UserGameEntity,
                            Bird = UserGameEntity.jobBirds[i].Bird,
                            BasicItemName = "Seed(s)",
                            Amount = 50,
                            Date = DateTime.Today
                        });
                    }
                }
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
}