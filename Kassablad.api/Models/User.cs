namespace Kassablad.api.Models {
    using System;
    
    public class User {
        public int Id { get; set; }
        public bool Active { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateUpdated { get; set; }
        public DateTime DateCreated { get; set; }
        public string Type { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }

    }
}