// using BirdGame.Data;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
// using NuGet.Protocol;
// using Microsoft.Identity;
// using System.Text.Json;

// namespace CSCI3600.API;

// [ApiController]
// [Route("/api/[controller]")]
// public class AdoptController : ControllerBase
// {
//     private readonly ILogger<AdoptController> _logger;
//     private readonly BirdDbContext _context;

//     public AdoptController(
//         ILogger<AdoptController> logger,
//         BirdDbContext context
//     )
//     {
//         _logger = logger;
//         _context = context;
//     }

//     [HttpPost]
//     public async Task<ActionResult> PostAdoptAsync(IHttpContextAccessor contextAccessor)
//     {
//         var reader = new StreamReader( Request.Body );
//         string JSON = await reader.ReadToEndAsync();
//         AdoptButton button = JsonSerializer.Deserialize<AdoptButton>(JSON);
//         _logger.LogInformation($"trying to add {button.buttonId}");
//         int bId = new int();
//         Int32.TryParse(button.buttonId, out bId);
//         try
//         {
//             UserGame UserGameEntity = await _context.UserGames
//                 .Include(ug => ug.OwnedBirds)
//                     .ThenInclude(bc => bc.Bird)
//                 .Include(ug => ug.rolledSSBs)
//                     .ThenInclude(bc => bc.Bird)
//                 .Include(ug => ug.sideShopBirds)
//                     .ThenInclude(bc => bc.Bird)
//                 .Where(ug => ug.Id == User.Identity.Name)
//                 .SingleAsync();
//             Bird nullBird = await _context.Birds
//                 .Where(b => b.Id == 999)
//                 .SingleAsync();
//             var authenticatedUser = contextAccessor.HttpContext.User.Identity.Name;
//             _context.RolledSSBs.RemoveRange(_context.RolledSSBs
//                 .Where(r => r.User.Id == authenticatedUser && r.SlotNum == bId));
//             _context.Add(new RolledSSB {
//                 User = UserGameEntity, 
//                 Bird = nullBird, 
//                 SlotNum = bId
//             });
//             await _context.SaveChangesAsync();
//         }
//         catch (Exception ex)
//         {
//             _logger.LogError(ex, "Unable to Adopt");
//             return StatusCode(500, ex);
//         }

//         return Ok();
//     }

// }