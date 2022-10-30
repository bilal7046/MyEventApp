using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyEventApp.Data;
using MyEventApp.Models;

namespace MyEventApp.Pages.Members
{
    public class IndexModel : PageModel
    {
        private readonly MyEventApp.Data.ApplicationDbContext _context;

        public IndexModel(MyEventApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Member> Member { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Member != null)
            {
                Member = await _context.Member
                .Include(m => m.IdentityUser).ToListAsync();
            }
        }
    }
}