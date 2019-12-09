using System;

namespace Kassablad.api.Models {
    public class Kassa {
        public int Id { get; set; }
        public bool Active { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateUpdated { get; set; }
        public int UpdatedBy { get; set; }
        public int CreatedBy { get; set; }
        public int KassaContainerId { get; set; }
        public string Type { get; set; }
        public int EenCent { get; set; }
        public int TweeCent { get; set; }
        public int VijfCent { get; set; }
        public int TienCent { get; set; }
        public int TwintigCent { get; set; }
        public int VijftigCent { get; set; }
        public int EenEuro { get; set; }
        public int TweeEuro { get; set; }
        public int VijfEuro { get; set; }
        public int TienEuro { get; set; }
        public int TwintigEuro { get; set; }
        public int VijftigEuro { get; set; }
        public int HonderdEuro { get; set; }
    }
}