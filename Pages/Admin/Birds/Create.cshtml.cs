using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BirdGame.Data;

namespace BirdGame.Pages_Admin_Birds
{
    public class CreateModel : PageModel
    {
        private readonly BirdGame.Data.BirdDbContext _context;

        public CreateModel(BirdGame.Data.BirdDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Bird Bird { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Birds == null || Bird == null)
            {
                return Page();
            }

            _context.Birds.Add(Bird);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
