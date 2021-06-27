using System;
using Microsoft.AspNetCore.Identity;

namespace OnePunch.Models
{
    public class OnePunchUser: IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
