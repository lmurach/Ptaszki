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
        CraftableItems = await _context.CraftableItems
            .Include(ci => ci.itemRelationships)
                .ThenInclude(ir => ir.BasicItem)
            .ToListAsync();
        Console.WriteLine(CraftableItems[0].Name);
        foreach (var item in CraftableItems[0].itemRelationships) {
            Console.WriteLine(item.BasicItem.Name);
        }
    }
}
