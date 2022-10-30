using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyEventApp.Data;
using MyEventApp.Models;

namespace MyEventApp.Pages.Rides
{
    public class DeleteModel : PageModel
    {
        private readonly MyEventApp.Data.ApplicationDbContext _context;

        public DeleteModel(MyEventApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Ride Ride { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.Ride == null)
            {
                return NotFound();
            }

            var ride = await _context.Ride.FirstOrDefaultAsync(m => m.RideID == id);

            if (ride == null)
            {
                return NotFound();
            }
            else 
            {
                Ride = ride;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null || _context.Ride == null)
            {
                return NotFound();
            }
            var ride = await _context.Ride.FindAsync(id);

            if (ride != null)
            {
                Ride = ride;
                _context.Ride.Remove(Ride);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
