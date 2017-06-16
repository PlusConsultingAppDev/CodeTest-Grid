using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grid.Domain.DTOs
{
    public class ProductDto
    {
        public ProductDto(long id, 
            string name, 
            string color, 
            int safetyStockLevel, 
            int reorderPoint, 
            decimal standardCost, 
            decimal listPrice)
        {
            Id = id;
            Name = name;
            Color = color;
            SafetyStockLevel = safetyStockLevel;
            ReorderPoint = reorderPoint;
            StandardCost = standardCost;
            ListPrice = listPrice;
        }


        public long Id { get; }
        public string Name { get; }
        public string Color { get; }
        public int SafetyStockLevel { get; }
        public int ReorderPoint { get; }
        public decimal StandardCost { get; }
        public decimal ListPrice { get; }
    }
}
