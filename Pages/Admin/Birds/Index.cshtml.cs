using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BirdGame.Data;

namespace BirdGame.Pages_Admin_Birds
{
    public class IndexModel : PageModel
    {
        private readonly BirdGame.Data.BirdDbContext _context;

        public IndexModel(BirdGame.Data.BirdDbContext context)
        {
            _context = context;
        }

        public IList<Bird> Bird { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Birds != null)
            {
                Bird = await _context.Birds.ToListAsync();
            }
        }
    }
}
