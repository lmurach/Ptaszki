using BirdGame.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BirdGame.Pages;

public class CraftingModel : PageModel
{
    private readonly BirdDbContext _context;
    private readonly ILogger<CraftingModel> _logger;

    public UserGame UserGameEntity = new UserGame();
    public List<CraftableItem> CraftableItems = new List<CraftableItem>();

    public CraftingModel (BirdDbContext context, ILogger<CraftingModel> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task OnGetAsync() {
        UserGameEntity = await _context.UserGames
            .Include(ug => ug.userIRs)
                .ThenInclude(ur => ur.BasicItem)
            .Where(ug => ug.Id == User.Identity.Name)
            .SingleAsync();
        CraftableItems = await _context.CraftableItems
            .Include(ci => ci.itemRelationships)
                .ThenInclude(ir => ir.BasicItem)
            .ToListAsync();
    }
}
