using BirdGame.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Logging;

namespace BirdGame.Pages;

public class AdoptModel : PageModel
{
    private readonly BirdDbContext _context;
    private readonly ILogger<AdoptModel> _logger;

    public int Seeds { get; set; }

    public AdoptModel(BirdDbContext context, ILogger<AdoptModel> logger)
    {
        _context = context;
        _logger = logger;
    }

    // public async Task OnGetAsync()
    // {
    //     this.Seeds = await _context.UserGames
    //         .Single(b => b.Id == UserManager.GetUserName(User));
    // }
}
