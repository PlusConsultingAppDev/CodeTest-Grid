using Grid.Domain.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grid.Domain.Data.Contexts
{
    public class EFDbContext : DbContext
    {
        public EFDbContext() : base("PlusConsulting")
        {
            Configuration.LazyLoadingEnabled = false;
        }


        public DbSet<Product> Products { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProductConfiguration());
        }
    }
}
