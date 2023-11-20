using BirdGame.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BirdGame.Pages;

public class JobsModel : PageModel
{
    private readonly BirdDbContext _context;
    private readonly ILogger<JobsModel> _logger;

    public UserGame UserGameEntity = new UserGame();
    public ICollection<Bird> OwnedBirds { get; set; } = default!;

    public JobsModel(BirdDbContext context, ILogger<JobsModel> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task OnGetAsync()
    {
        UserGameEntity = await _context.UserGames
            .Include(ug => ug.OwnedBirds)
                .ThenInclude(bc => bc.Bird)
            .Where(ug => ug.Id == User.Identity.Name)
            .SingleAsync();
    }
}
