using System;
using System.Collections.Generic;
using System.Linq;
using PlusConsultingCodeTest_Infrastructure;
using PlusConsultingCodeTest_DataAccess;

namespace PlusConsultingCodeTest_DataService
{
	public class ProductDataService {
		private readonly ProductFactory _products;
		public ProductDataService() {
			_products = new ProductFactory();
		}
		public List<Product> GetAllProducts() {
			return _products.Products;
		}
		
		public List<Product> GetProductsBySearchParameter(Predicate<Product> predicate) {
			return _products.Products.FindAll(predicate).ToList();
		}

		public void AddProduct(Product newProduct) {
			try {
				_products.AddProduct(newProduct);
			} catch(Exception ex) {
				throw new Exception($"Error Adding New Product: {ex.Message}", ex);
			}
		}

		public void AddAWholeLotOfProducts() {
			_products.AddAWholeBunchOfProducts();
		}
	}
}
