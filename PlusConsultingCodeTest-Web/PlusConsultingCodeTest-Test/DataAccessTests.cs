using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlusConsultingCodeTest_Infrastructure;

namespace PlusConsultingCodeTest_Test
{
	[TestClass]
	public class DataAccessTests
	{
		[TestMethod]
		public void DataAccessInitialShouldCreateANewListOfProductsWithOneProduct() {
			var d=new PlusConsultingCodeTest_DataAccess.ProductFactory();
			
			Assert.AreEqual(1, d.Products.Count);

		}

		[TestMethod]
		public void DataAccessGetNextProductNumberShouldReturnNextProductNumber() {
			var d = new PlusConsultingCodeTest_DataAccess.ProductFactory();
			var productNumber=d.GetNextProductNumber();
			Assert.AreEqual(2, productNumber);
		}

		[TestMethod]
		public void DataAccessAddMethodShouldIncreaseNumberOfProductsByOne() {
			var d = new PlusConsultingCodeTest_DataAccess.ProductFactory();

			var p=new Product {
				ProductName="TestProduct",
				Color="blue",
				ListPrice=10.00D,
				ReorderPoint=10,
				SafetyStockLevel=2,
				StandardCost=5.25D
			};
			d.AddProduct(p);
			Assert.AreEqual(2, d.Products.Count);
		}
	}
}
