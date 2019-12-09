using System;

namespace Kassablad.api.Models {
    public class ConsumptieCount {
        public int Id { get; set; }
        public bool Active { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateUpdated { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public int KassaContainerId { get; set; }
        public int ConsumptieId { get; set; }
        public int Aantal { get; set; }
    }
}