using Grid.Domain.Abstract;
using Grid.Web.Models.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Grid.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository repository;

        public HomeController(IRepository repo)
        {
            repository = repo;
        }



        public ActionResult Index()
        {
            IndexViewModel viewModel = new IndexViewModel();
            viewModel.Initialize(repository);

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Save(IndexViewModel viewModel)
        {
            viewModel.Initialize(repository);

            if (ModelState.IsValid)
            {
                viewModel.Save();
                return RedirectToAction("Index");
            }
            else
                return View("Index", viewModel);
        }
    }
}