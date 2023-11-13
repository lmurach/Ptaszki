using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BirdGame.Pages;

public class CraftingModel : PageModel
{
    private readonly ILogger<CraftingModel> _logger;

    public CraftingModel(ILogger<CraftingModel> logger)
    {
        _logger = logger;
    }
}
