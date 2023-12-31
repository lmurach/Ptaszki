using BirdGame.Data;
using BirdGame.ControllerData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using Microsoft.Identity;
using System.Text.Json;
using System.Net.WebSockets;
using System.Runtime.Intrinsics.X86;
using BirdGame.Migrations;

namespace CSCI3600.API;

[ApiController]
[Route("/api/[controller]")]
public class PickBirdController : ControllerBase
{
    private readonly ILogger<PickBirdController> _logger;
    private readonly BirdDbContext _context;

    public PickBirdController(
        ILogger<PickBirdController> logger,
        BirdDbContext context
    )
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet]
    public async Task<UserGame> GetPickBirdAsync()
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
    public async Task<ActionResult> PostPickBirdAsync()
    {
        var reader = new StreamReader( Request.Body );
        string JSON = await reader.ReadToEndAsync();
        PickedBird bird = JsonSerializer.Deserialize<PickedBird>(JSON);
        _logger.LogInformation($"trying to add {bird.birdId}");
        int birdId = new int();
        Int32.TryParse(bird.birdId, out birdId);
        try
        {
            UserGame UserGameEntity = await _context.UserGames
                .Include(ug => ug.OwnedBirds)
                    .ThenInclude(ob => ob.Bird)
                .Include(ug => ug.jobBirds.OrderBy(jb => jb.SlotNum))
                    .ThenInclude(jb => jb.Bird)
                .Where(ug => ug.Id == User.Identity.Name)
                .SingleAsync();
            Bird pickedBird = await _context.Birds
                .Where(b => b.Id == birdId)
                .SingleAsync();
            int index = JobFunctions.FindEmptyJobIndex(UserGameEntity);
            if (index >= 0) {
                JobFunctions.RemoveOldBird(UserGameEntity, _context, index);
                JobBird jobBird = JobFunctions.AddJobBird(
                    UserGameEntity, pickedBird, _context, index);
                await _context.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unable to Adopt");
            return StatusCode(500, ex);
        }
        return Ok();
    }
}