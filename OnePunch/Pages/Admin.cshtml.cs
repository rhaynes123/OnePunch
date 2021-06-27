using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public IList<Punch> Punches { get;set; }

        public void OnGet()
        {
            Punches =  _context.GetPunches().ToList();
        }

        public async Task<FileResult> OnPostDownload()
        {
            StringBuilder FileStringBuilder = new ();
            var data = await _context.Punches.ToListAsync();
            FileStringBuilder.Append("Punch #, UserId, Role, Day Of Week,Clock In, Clock Out\n");
            foreach ( var line in data)
            {
                FileStringBuilder.Append($"{line.Id},{line.AspNetUserId},{line.AspNetUserRoleName},{line.DayOfWeek},{line.ClockIn},{line.ClockOut}");
                FileStringBuilder.Append("\r\n");
            }

            return File(Encoding.ASCII.GetBytes(FileStringBuilder.ToString()),"text/csv", $"DownLoads_{DateTime.Now.ToShortTimeString()}.csv");
        }
    }
}
