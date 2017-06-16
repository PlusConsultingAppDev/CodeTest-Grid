using Grid.Domain.Abstract;
using Grid.Domain.Data.Entities;
using Grid.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Grid.Web.Models.Home
{
    public class IndexViewModel
    {
        private IRepository repository;


        [Display(Name = "Name")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Color")]
        [Required]
        public string SelectedColor { get; set; }
        public List<SelectListItem> ColorSelectListItems { get; private set; }

        [Display(Name = "Safety Stock Level")]
        [Required]
        public int? SafetyStockLevel { get; set; }

        [Display(Name = "Reorder Point")]
        [Required]
        public int? ReorderPoint { get; set; }

        [Display(Name = "Standard Cost")]
        [Required]
        public decimal? StandardCost { get; set; }

        [Display(Name = "List Price")]
        [Required]
        public decimal? ListPrice { get; set; }


        public List<ProductDto> Products { get; private set; }


        internal void Initialize(IRepository repo)
        {
            repository = repo;

            ColorSelectListItems = new List<SelectListItem>
            {
                new SelectListItem{ Value = "1", Text = "Red" },
                new SelectListItem{ Value = "2", Text = "Black" },
                new SelectListItem{ Value = "3", Text = "White" },
                new SelectListItem{ Value = "4", Text = "Silver" }
            };

            Products = repository.GetAll<Product>()
                .Select(x => new ProductDto(id: x.Id,
                    name: x.Name,
                    color: x.Color,
                    safetyStockLevel: x.SafetyStockLevel,
                    reorderPoint: x.ReorderPoint,
                    standardCost: x.StandardCost,
                    listPrice: x.ListPrice))
                .OrderByDescending(x => x.Id)
                .ToList();
        }

        internal void Save()
        {
            Product newProduct = new Product
            {
                Name = Name,
                Color = ColorSelectListItems.FirstOrDefault(x => x.Value.Equals(SelectedColor, StringComparison.InvariantCultureIgnoreCase)).Text,
                ListPrice = ListPrice.Value,
                ReorderPoint = ReorderPoint.Value,
                SafetyStockLevel = SafetyStockLevel.Value,
                StandardCost = StandardCost.Value
            };

            repository.SaveOrUpdate(newProduct);
        }
    }
}