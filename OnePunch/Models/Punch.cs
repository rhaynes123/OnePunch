using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace OnePunch.Models
{
    [Index(nameof(ClockIn), nameof(IsClockedIn))]
    public class Punch
    {
        
        [Required,Key]
        public int Id { get; set; }
        [Required]
        public DateTime ClockIn { get; set; } = DateTime.Now;
        public DateTime? ClockOut { get; set; }
        [Required, Display(Name = "In")]
        public bool IsClockedIn { get; set; } = true;
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        [Required, Display(Name ="Employee #")]
        public string AspNetUserId { get; set; }
        [NotMapped]
        public OnePunchUser IdentityUser { get; set; }
        [Required, StringLength(25)]
        public string AspNetUserRoleName { get; set; }
        [NotMapped]
        public IdentityRole IdentityRole { get; set; } = new IdentityRole(Role.Employee.ToString());
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        [Required]
        public DateTime ModifiedAt { get; set; } = DateTime.Now;
        [Required]
        public DayOfWeek DayOfWeek { get; set; } = DateTime.Now.DayOfWeek;
        [Required]
        public DateTime LastPunch { get; set; } = DateTime.Now;
    }
}
