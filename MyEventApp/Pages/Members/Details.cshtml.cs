﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyEventApp.Data;
using MyEventApp.Models;

namespace MyEventApp.Pages.Members
{
    public class DetailsModel : PageModel
    {
        private readonly MyEventApp.Data.ApplicationDbContext _context;

        public DetailsModel(MyEventApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Member Member { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.Member == null)
            {
                return NotFound();
            }

            var member = await _context.Member.FirstOrDefaultAsync(m => m.MemberID == id);
            if (member == null)
            {
                return NotFound();
            }
            else 
            {
                Member = member;
            }
            return Page();
        }
    }
}
