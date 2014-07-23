using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wheat.Models;
using System.Data.Entity;

namespace Wheat.Controllers
{
    public class HomeController : Controller
    {
        private WheatDbContext db = new WheatDbContext();
        public ActionResult Index()
        {
            Admin admin = new Admin();
            admin.AnswerNumber = 0;
            admin.PerformanceNumber = 0;
            admin.Performances = new List<Performance>();
            db.Admins.Add(admin);
            db.SaveChanges();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "你的应用程序说明页。";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "你的联系方式页。";

            return View();
        }

    }
}
