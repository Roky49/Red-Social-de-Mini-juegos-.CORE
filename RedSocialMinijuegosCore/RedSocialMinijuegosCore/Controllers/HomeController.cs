using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RedSocialMinijuegosCore.Models;

namespace RedSocialMinijuegosCore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult index()
        {
            return View();
        }

        public IActionResult categories()
        {
            

            return View();
        }

        public IActionResult contact()
        {
            

            return View();
        }

        public IActionResult games()
        {
            return View();
        }

        public IActionResult community()
        {
            return View();
        }
        public IActionResult blog()
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
