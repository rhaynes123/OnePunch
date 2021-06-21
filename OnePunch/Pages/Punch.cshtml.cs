using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnePunch.Data;
using OnePunch.Models;

namespace OnePunch.Pages
{
    [Authorize]
    public class PunchModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;

        public PunchModel(ApplicationDbContext context
            , RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> OnGet()
        {
            Roles = await _roleManager.Roles.Select(r=> new SelectListItem {Value = r.Name, Text = r.Name }).ToListAsync();
            return Page();
        }

        [BindProperty]
        public Punch Punch { get; set; }
        [BindProperty]
        public List<SelectListItem> Roles { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Punch openPunch = await _context.Punches.FirstOrDefaultAsync(p => p.AspNetUserId == Punch.AspNetUserId && p.IsClockedIn);
            if (openPunch == null)
            {
                _context.Punches.Add(Punch);
            }
            else
            {
                Punch = openPunch;
                Punch.ClockOut = DateTime.UtcNow;
                Punch.IsClockedIn = false;
                _context.Attach(Punch).State = EntityState.Modified;
            }
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
