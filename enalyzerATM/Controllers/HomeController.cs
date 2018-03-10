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


        [HttpPost]
        public JsonResult GetAtmChange(int amount)
        {
            /*var result;
            var listMoneys;
            foreach (var item in listMoneys)
            {

            }
           
            if(am)*/

            return Json("test", JsonRequestBehavior.AllowGet);
        }
    }
}