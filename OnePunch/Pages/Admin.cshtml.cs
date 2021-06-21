using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OnePunch.Data;
using OnePunch.Models;

namespace OnePunch.Pages
{
    public class AdminModel : PageModel
    {
        private readonly OnePunch.Data.ApplicationDbContext _context;

        public AdminModel(OnePunch.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Punch> Punch { get;set; }

        public async Task OnGetAsync()
        {
            Punch = await _context.Punches.ToListAsync();
        }
    }
}
