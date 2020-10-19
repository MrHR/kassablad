using System;

namespace Kassablad.api.Models {
    public class KassaNomination {
        public int Id { get; set; }
        public bool Active { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateUpdated { get; set; }
        public int UpdatedBy { get; set; }
        public int CreatedBy { get; set; }
        public int KassaId { get; set; }
        public int NominationId { get; set; }
        public int Amount { get; set; }
        
    }
}