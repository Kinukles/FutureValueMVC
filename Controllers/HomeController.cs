using FutureValueMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FutureValueMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(FutureValueModelMVC model)
        {
            if (ModelState.IsValid)
            {
                ViewBag.FutureValue = model.CalculateFutureValue();
            }

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}
