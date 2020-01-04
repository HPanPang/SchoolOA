using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OABackground.Services;
using SchoolOA.Models;

namespace SchoolOA.Controllers
{
    public class HomeController : Controller
    {
        ApiController api = new ApiController() { };
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult LogIn()
        {
            return View();
        }
        public IActionResult APDetail(int id)
        {
            ViewData["APID"] = id;
            return View();
        }
        public IActionResult Teacher()
        {
            return View();
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
