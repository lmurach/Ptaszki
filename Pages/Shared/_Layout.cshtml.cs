using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BirdGame.Pages;

public class LayoutModel : PageModel
{
    private readonly ILogger<LayoutModel> _logger;

    public LayoutModel(ILogger<LayoutModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }
}
