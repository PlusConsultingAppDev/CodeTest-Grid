using System;
using System.Collections.Generic;
using System.Linq;
using PlusConsultingCodeTest_Infrastructure;

namespace PlusConsultingCodeTest_DataAccess
{
	public class ProductFactory
	{
		public List<Product> Products {get;set;}
		public ProductFactory() {

			//Todo: add inital product
			Product p = new Product {
				ProductName = "Widget Number 1",
				Color = "Red",
				ListPrice = 10.25D,
				ProductNumber = 1,
				ReorderPoint = 50,
				SafetyStockLevel = 150,
				StandardCost = 10.0D
			};
			Products = new List<Product> { p };
		}

		public void AddProduct(Product product) {
			try {
				if(string.IsNullOrEmpty(product.ProductName))
					throw new Exception("Empty Product");
				product.ProductNumber = GetNextProductNumber();
				Products.Add(product);
			} catch(Exception e) {

				throw e;
			}
		}

		public int GetNextProductNumber() {
			return Products.Last().ProductNumber + 1;
		}

		public void AddAWholeBunchOfProducts() {
			Add50Products();
		}

		private void Add50Products() {
			for(int i=0;i<50;i++) {
				var p=new Product {
					ProductName=$"New Product # {i}",
					Color="purple",
					ListPrice=10.0D,
					ProductNumber=GetNextProductNumber(),
					ReorderPoint=2,
					SafetyStockLevel=5,
					StandardCost=6.00D
				};

				Products.Add(p);
			}
		}
	}

}
