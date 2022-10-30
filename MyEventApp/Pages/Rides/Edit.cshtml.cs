using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyEventApp.Data;
using MyEventApp.Models;

namespace MyEventApp.Pages.Rides
{
    public class EditModel : PageModel
    {
        private readonly MyEventApp.Data.ApplicationDbContext _context;

        public EditModel(MyEventApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Ride Ride { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.Ride == null)
            {
                return NotFound();
            }

            var ride =  await _context.Ride.FirstOrDefaultAsync(m => m.RideID == id);
            if (ride == null)
            {
                return NotFound();
            }
            Ride = ride;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Ride).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RideExists(Ride.RideID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool RideExists(Guid id)
        {
          return _context.Ride.Any(e => e.RideID == id);
        }
    }
}
