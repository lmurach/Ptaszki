using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BirdGame.Pages;

public class JobsModel : PageModel
{
    private readonly ILogger<JobsModel> _logger;

    public JobsModel(ILogger<JobsModel> logger)
    {
        _logger = logger;
    }
}
