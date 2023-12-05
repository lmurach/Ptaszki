using BirdGame.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BirdGame.Pages;

public class ViewBirdsModel : PageModel
{
    private readonly BirdDbContext _context;
    private readonly ILogger<ViewBirdsModel> _logger;

    public UserGame userGameEntity = new UserGame();
    public ICollection<Bird> ListOfBirds { get; set; } = default!;

    public ViewBirdsModel(BirdDbContext context, ILogger<ViewBirdsModel> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task OnGetAsync()
    {
        userGameEntity = await _context.UserGames
            .Include(ug => ug.OwnedBirds)
                .ThenInclude(ob => ob.Bird)
            .Where(ug => ug.Id == User.Identity.Name)
            .SingleAsync();
        ListOfBirds = await _context.Birds
            .Where(b => b.Id != 999)
            .ToListAsync();
    }
}

