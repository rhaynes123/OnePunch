using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnePunch.Models;

namespace OnePunch.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Punch> Punches { get; set; }
        public DbSet<OnePunchUser> OnePunchUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Punch>(entity => {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.ClockIn);
                entity.Property(p => p.ClockOut);
                entity.Property(p => p.IsClockedIn);
                entity.Property(p => p.Longitude);
                entity.Property(p => p.Latitude);
                entity.Property(p => p.AspNetUserId);
                entity.Property(p => p.AspNetUserRoleName);
                entity.Property(p => p.CreatedAt);
                entity.Property(p => p.ModifiedAt);
                entity.Property(p => p.DayOfWeek);
                entity.Property(p => p.LastPunch);
            });
        }

        public DateTime? GetLastPunch(string id)
        {
            try
            {
                return Punches.OrderByDescending(p => p.Id).FirstOrDefault(p => p.AspNetUserId == id)?.LastPunch;
            }
            catch (Exception)
            {
                throw new Exception("Unexpected exception referenced raised please ensure the userid provided is valid");
            }
        }

        public IEnumerable< Punch> GetPunches()
        {
            return Punches.FromSqlRaw(" CALL GetAllPunches ();").AsEnumerable();
        }
    }
}
