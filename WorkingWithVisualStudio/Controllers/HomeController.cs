using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkingWithVisualStudio.Models;

namespace WorkingWithVisualStudio.Controllers
{
    public class HomeController : Controller 
    {

        SimpleRepository Repository = SimpleRepository.SharedRepository;
        public IActionResult Index() => View(SimpleRepository.SharedRepository.Products
                                                             .Where(p => p?.Price < 50));

        [HttpGet]
        public IActionResult AddProduct() => View(new Product());

        [HttpPost]
        public IActionResult AddProduct(Product p)
        {
            Repository.AddProduct(p);
            return RedirectToAction("Index");
        }
    }
}
