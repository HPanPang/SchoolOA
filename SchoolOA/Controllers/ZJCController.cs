using Microsoft.AspNetCore.Mvc;
using OABackground.Services;

namespace SchoolOA.Controllers
{
    public class ZJCController : Controller
    {
        protected IndexService indexservice = new IndexService();
        
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CommitPlan()
        {
            return View();
        }
        public IActionResult HandleStudents()
        {
            return View();
        }
        public IActionResult DocManager()
        {
            return View();
        }
        public IActionResult SearchTeacher()
        {
            return View();
        }
        public IActionResult HandlePunish(int id)
        {
            ViewData["HPID"] = id;
            return View();
        }
        public IActionResult HandleAward(int id)
        {
            ViewData["HAID"] = id;
            return View();
        }

    }
}
