using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using stock_transfer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stock_transfer.Context
{

    public class Masterfile_DBContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public Masterfile_DBContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbSet<Masterfile_Items> Masterfile_Items { get; set; } 


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=masterfile_dev;Trusted_Connection=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Masterfile_Items>().HasKey(e => e.Item_Code); 
        }
    }
}
