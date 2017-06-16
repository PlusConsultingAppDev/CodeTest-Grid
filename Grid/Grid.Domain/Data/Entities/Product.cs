using Grid.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grid.Domain.Data.Entities
{
    public class Product : IEntity
    {
        public virtual long Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Color { get; set; }
        public virtual int SafetyStockLevel { get; set; }
        public virtual int ReorderPoint { get; set; }
        public virtual decimal StandardCost { get; set; }
        public virtual decimal ListPrice { get; set; }
    }


    internal class ProductConfiguration : EntityTypeConfiguration<Product>
    {
        public ProductConfiguration()
        {
            //Primary Key
            HasKey(x => x.Id);

            //Properties
            Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(500);

            Property(x => x.Color)
                .IsRequired()
                .HasMaxLength(25);

            Property(x => x.StandardCost)
                .HasPrecision(10, 2);

            Property(x => x.ListPrice)
                .HasPrecision(10, 2);

            //Table & Column Mappings
            ToTable("d_Products");
            Property(x => x.Id).HasColumnName("Id");
            Property(x => x.Name).HasColumnName("Name");
            Property(x => x.Color).HasColumnName("Color");
            Property(x => x.SafetyStockLevel).HasColumnName("SafetyStockLevel");
            Property(x => x.ReorderPoint).HasColumnName("ReorderPoint");
            Property(x => x.StandardCost).HasColumnName("StandardCost");
            Property(x => x.ListPrice).HasColumnName("ListPrice");
        }
    }
}
