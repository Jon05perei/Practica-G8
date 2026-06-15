using Microsoft.AspNetCore.Mvc;
using Practica_1.Models;
using System.Diagnostics;

namespace Practica_1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // Redirect home page to the Clientes list
            return RedirectToAction("Index", "Cliente");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
