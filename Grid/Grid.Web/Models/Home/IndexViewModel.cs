using Grid.Domain.Abstract;
using Grid.Domain.Data.Entities;
using Grid.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Grid.Web.Models.Home
{
    public class IndexViewModel
    {
        private IRepository repository;

        public List<ProductDto> Products { get; set; }


        internal void Initialize(IRepository repo)
        {
            repository = repo;

            Products = repository.GetAll<Product>().Select(x => new ProductDto(id: x.Id, 
                name: x.Name, 
                color: x.Color, 
                safetyStockLevel: x.SafetyStockLevel, 
                reorderPoint: x.ReorderPoint, 
                standardCost: x.StandardCost, 
                listPrice: x.ListPrice)).ToList();
        }
    }
}