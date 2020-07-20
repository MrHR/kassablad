using System;

namespace Kassablad.api.Models {
    public class KassaTemplate {
        public int Id { get; set; }
        public bool Active { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateUpdated { get; set; }
        public int UpdatedBy { get; set; }
        public int CreatedBy { get; set; }
        public string Nominations { get; set; }
        
    }
}