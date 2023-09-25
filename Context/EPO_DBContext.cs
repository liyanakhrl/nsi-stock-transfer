using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using stock_transfer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stock_transfer.Context
{
    public class EPO_DBContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public EPO_DBContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbSet<Item> Item { get; set; }
        public DbSet<Store> Store { get; set; }
        public DbSet<InventorySummary> InventorySummary { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=epo_dev;Trusted_Connection=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().HasKey(e => e.Item_ID);
            modelBuilder.Entity<InventorySummary>().HasKey(e => e.ID);
            modelBuilder.Entity<Store>().HasKey(e => e.Store_ID);
        }
    }

}
