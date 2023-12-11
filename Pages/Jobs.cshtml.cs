using BirdGame.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BirdGame.Pages;

public class JobsModel : PageModel
{
    private readonly BirdDbContext _context;
    private readonly ILogger<JobsModel> _logger;

    public UserGame UserGameEntity = new UserGame();
    public List<Yield> Yields = new List<Yield>();

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
            .Include(ug => ug.jobBirds.OrderBy(jb => jb.SlotNum))
                .ThenInclude(jb => jb.Bird)
            .Where(ug => ug.Id == User.Identity.Name)
            .SingleAsync();
        Yields = await _context.Yields
            .Include(y => y.Bird)
            .Where(y => y.Date == DateTime.Today
                && y.User.Id == User.Identity.Name)
            .ToListAsync();
    }
}
