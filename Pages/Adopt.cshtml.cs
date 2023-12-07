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

    public IActionResult OnPostReroll(UserGame ug) {
        Console.WriteLine(ug.Id);
        Console.WriteLine(UserGameEntity.Id);
        // if (UserGameEntity.Seeds >= 2) {
        //     UserGameEntity.Seeds -= 2;
        //     _context.UserGames.Update(UserGameEntity);
        //     _context.SaveChanges();
        //     // Reroll();
        //     return Page();
        // }
        return Page();
    }
}
