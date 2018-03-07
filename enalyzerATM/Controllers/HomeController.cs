using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace enalyzerATM.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //TODO : User res file to think about futur translation
            ViewBag.TouchPadTitle = "Select amount";
            ViewBag.ResultTitle = "Depositing";
            ViewBag.ThanksMessage = "Thank you for using";
            return View();
        }
    }
}