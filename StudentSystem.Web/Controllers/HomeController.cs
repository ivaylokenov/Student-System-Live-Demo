using StudentSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentSystem.Web.Controllers
{
    public class HomeController : Controller
    {
        private StudentSystemData data;

        public HomeController()
        {
            this.data = new StudentSystemData();
        }

        public ActionResult Index()
        {
            var course = data.Courses.All();

            return View(course);
        }
    }
}
