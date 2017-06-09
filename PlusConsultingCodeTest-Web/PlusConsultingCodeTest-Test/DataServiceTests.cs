using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlusConsultingCodeTest_Infrastructure;

namespace PlusConsultingCodeTest_Test
{
	[TestClass]
	public class DataServiceTests
	{
		[TestMethod]
		public void DataServiceGetAllProductsCountShouldEqualOne()
		{
			var d = new PlusConsultingCodeTest_DataService.ProductDataService();
			var blah=d.GetAllProducts();
			Assert.IsTrue(blah.Count == 1);
		}
		[TestMethod]
		public void DataServiceGetAllProductsBySearchParameterShouldReturnOneProduct() {
			var d = new PlusConsultingCodeTest_DataService.ProductDataService();
			var products=d.GetProductsBySearchParameter(x => x.ProductName.Contains("Widget"));
			Assert.AreEqual(1, products.Count);
		}

		[TestMethod]
		public void DataServiceAddProductShouldThrowExceptionWithEmptyProduct() {
			var d = new PlusConsultingCodeTest_DataService.ProductDataService();
			var newProduct=new Product();
			Exception ex=null;
			try {
				d.AddProduct(newProduct);
			} catch(Exception e) {
				ex = e;
			}
			Assert.IsNotNull(ex);
		}
	}
}
