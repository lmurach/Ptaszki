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

    public UserGame UserGameEntity = new UserGame();
    public int Seeds { get; set; }

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
}
