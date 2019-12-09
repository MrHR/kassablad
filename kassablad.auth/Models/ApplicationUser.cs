using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kassablad.auth.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int Id { get; set; }
        public bool Active { get; set; }
        public string Type { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
    }
}
