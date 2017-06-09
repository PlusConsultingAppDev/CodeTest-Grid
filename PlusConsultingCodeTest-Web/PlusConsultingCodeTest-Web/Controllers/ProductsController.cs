using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PlusConsultingCodeTest_DataService;

namespace PlusConsultingCodeTest_Web.Controllers
{
	public class ProductsController : Controller
	{
		private ProductDataService _products;
		public ProductsController() {
			_products= new ProductDataService();
			_products.AddAWholeLotOfProducts();
		}
		// GET: Products
		public ActionResult Index()
		{
			return View();
		}


		#region JSON
		[HttpGet]
		public JsonResult GetAllProducts() {
			var products=_products.GetAllProducts();
			return new JsonResult{Data = products, JsonRequestBehavior = JsonRequestBehavior.AllowGet};
		}
		#endregion
	}
}