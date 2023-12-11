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
public class RemoveBirdController : ControllerBase
{
    private readonly ILogger<AdoptController> _logger;
    private readonly BirdDbContext _context;

    public RemoveBirdController(
        ILogger<AdoptController> logger,
        BirdDbContext context
    )
    {
        _logger = logger;
        _context = context;
    }
    
    [HttpGet]
    public async Task<UserGame> GetRemoveBirdAsync()
    {
        return await _context.UserGames
            .Include(ug => ug.OwnedBirds)
                .ThenInclude(ob => ob.Bird)
            .Include(ug => ug.jobBirds.OrderBy(jb => jb.SlotNum))
                    .ThenInclude(jb => jb.Bird)
            .Where(ug => ug.Id == User.Identity.Name)
            .SingleAsync();
    }

    [HttpPost]
    public async Task<ActionResult> PostRemoveBirdAsync()
    {
        var reader = new StreamReader( Request.Body );
        string JSON = await reader.ReadToEndAsync();
        RemovedBird bird = JsonSerializer.Deserialize<RemovedBird>(JSON);
        int birdId;
        int birdPosition;
        Int32.TryParse(bird.birdId, out birdId);
        Int32.TryParse(bird.birdPosition, out birdPosition);
        try
        {
            UserGame UserGameEntity = await _context.UserGames
                .Include(ug => ug.OwnedBirds)
                    .ThenInclude(ob => ob.Bird)
                .Include(ug => ug.jobBirds.OrderBy(jb => jb.SlotNum))
                    .ThenInclude(jb => jb.Bird)
                .Where(ug => ug.Id == User.Identity.Name)
                .SingleAsync();
            Bird RemovedBird = await _context.Birds
                .Where(b => b.Id == birdId)
                .SingleAsync();
            Bird nullBird = await _context.Birds
                .Where(b => b.Id == 999)
                .SingleAsync();
            JobFunctions.RemoveOldBird(UserGameEntity, _context, birdPosition);
            JobFunctions.AddJobBird(UserGameEntity, nullBird, _context, birdPosition);
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