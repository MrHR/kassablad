using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Kassablad.api.Models;

namespace Kassablad.api.Data {
    public class KassabladContext : DbContext
    {
        public KassabladContext (DbContextOptions<KassabladContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=KassabladDatabase.db");
        }

        public DbSet<Kassablad.api.Models.User> User { get; set; }
        public DbSet<Kassablad.api.Models. KassaContainer> KassaContainer { get; set; }
        public DbSet<Kassablad.api.Models.Kassa> Kassa { get; set; }
        public DbSet<Kassablad.api.Models.Consumptie> Consumptie { get; set; }
        public DbSet<Kassablad.api.Models.ConsumptieCount> ConsumptieCount { get; set; }

    }
}
    
