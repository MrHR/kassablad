using System;
using Microsoft.AspNetCore.Identity;

namespace Kassablad.api.Models {    
    public class User : IdentityUser {
        // public int Id { get; set; }
        public bool Active { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateUpdated { get; set; }
        public DateTime DateCreated { get; set; }

    }
}