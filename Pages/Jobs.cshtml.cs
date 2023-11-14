using BirdGame.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BirdGame.Pages;

public class JobsModel : PageModel
{
    private readonly BirdDbContext _context;
    private readonly ILogger<JobsModel> _logger;

    public ICollection<Bird> OwnedBirds { get; set; } = default!;

    public JobsModel(BirdDbContext context, ILogger<JobsModel> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task OnGetAsync()
    {
        this.OwnedBirds = await _context.Birds
            .ToListAsync();
    }
}
