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
    public class IndexModel : PageModel
    {
        private readonly MyEventApp.Data.ApplicationDbContext _context;

        public IndexModel(MyEventApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Ride> Ride { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Ride != null)
            {
                Ride = await _context.Ride.ToListAsync();
            }
        }
    }
}
