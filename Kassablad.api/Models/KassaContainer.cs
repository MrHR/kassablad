using System;

namespace Kassablad.api.Models {
    public class KassaContainer {
        public int Id { get; set; }
        public bool Active { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateUpdated { get; set; }
        public int UpdatedBy { get; set; }
        public int CreatedBy { get; set; }
        public string NaamTapper { get; set; }
        public DateTime BeginUur { get; set; }
        public DateTime EindUur { get; set; }
        public string Notes { get; set; }
        public string NaamTapperSluit { get; set; }
        public int Bezoekers { get; set; }
        public decimal Afroomkluis { get; set; }
        public decimal InkomstBar { get; set; }
        public decimal InkomstLidkaart { get; set; }
    }
}