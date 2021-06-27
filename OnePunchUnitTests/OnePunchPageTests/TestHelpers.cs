using System;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OnePunch.Data;
using OnePunch.Models;

namespace OnePunchUnitTests.OnePunchPageTests
{
    public static class TestHelpers
    {
        public static ClaimsIdentity GetTestClaims()
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, "John Doe"),
                new Claim(ClaimTypes.NameIdentifier, "1"),
                new Claim("name", "John Doe"),
            };
            return  new ClaimsIdentity(claims, "TestAuthType");
        }

        public static DbContextOptions<ApplicationDbContext> TestDbContextOptions()
        {
            // Create a new service provider to create a new in-memory database.
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            // Create a new options instance using an in-memory database and 
            // IServiceProvider that the context should resolve all of its 
            // services from.
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("InMemoryDb")
                .UseInternalServiceProvider(serviceProvider);

            return builder.Options;
        }

        public static List<Punch> GetTestPunches()
        {
            return new List<Punch>()
            {
                new Punch
                {
                    Id = 1,
                    ClockIn = DateTime.Now,
                    ClockOut = null,
                    IsClockedIn = true,
                    Latitude = 0,
                    Longitude = 0,
                    AspNetUserId = "1",
                    AspNetUserRoleName = Role.Admin.ToString(),
                    CreatedAt = DateTime.Now,
                    ModifiedAt = DateTime.Now,
                    DayOfWeek = DateTime.Now.DayOfWeek,
                    LastPunch = DateTime.Now
                }
            };
        }
    }
}
