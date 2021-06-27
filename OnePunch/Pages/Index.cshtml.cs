using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OnePunch.Data;
using OnePunch.Models;

namespace OnePunch.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ApplicationDbContext _context;

        public IndexModel(ILogger<IndexModel> logger
            , ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        [BindProperty]
        public IEnumerable<Punch> Punches { get; set; }
        [BindProperty]
        public DateTime LastPunch { get; set; }
        [BindProperty]
        public string UserId { get; private set; }
        public async Task<IActionResult> OnGetAsync()
        {
            try
            {
                UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (string.IsNullOrWhiteSpace(UserId))
                {
                    _logger.LogError("User Id was not Found Authorize May have Failed");
                    return RedirectToPage("/Account/Login", new { area = "Identity" });
                }
                Punches = await _context.Punches.Where(p => p.AspNetUserId == UserId).OrderByDescending(p => p.Id).Take(10).ToListAsync();
                LastPunch = _context.GetLastPunch(UserId);
                return Page();
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Index Raised a Critical Exception: {ex.Message}");
                return RedirectToPage("./Shared/Whoops");
            }
            
        }
    }
}
