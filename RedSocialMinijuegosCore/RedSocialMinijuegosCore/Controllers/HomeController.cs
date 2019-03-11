using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


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

    }
}
