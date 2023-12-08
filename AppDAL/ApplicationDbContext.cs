using AppEntity.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public void CreateSchema(ModelBuilder builder)
        {
            OnModelCreating(builder);
        }

        public DbSet<ProductDTO> Products { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductDTO>(b =>
            {
                b.ToTable("Product");
                b.HasKey(m => m.Id);
            });
        }

    }
}
