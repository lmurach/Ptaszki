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
    public class DeleteModel : PageModel
    {
        private readonly BirdGame.Data.BirdDbContext _context;

        public DeleteModel(BirdGame.Data.BirdDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Bird Bird { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.Birds == null)
            {
                return NotFound();
            }

            var bird = await _context.Birds.FirstOrDefaultAsync(m => m.Name == id);

            if (bird == null)
            {
                return NotFound();
            }
            else 
            {
                Bird = bird;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null || _context.Birds == null)
            {
                return NotFound();
            }
            var bird = await _context.Birds.FindAsync(id);

            if (bird != null)
            {
                Bird = bird;
                _context.Birds.Remove(Bird);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
