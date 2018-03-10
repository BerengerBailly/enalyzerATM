using enalyzerATM.Helpers;
using enalyzerATM.Models;
using enalyzerATM.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace enalyzerATM.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //TODO : User res file for translations
            ViewBag.TouchPadTitle = "Select amount";
            ViewBag.ResultTitle = "Depositing";
            ViewBag.ThanksMessage = "Thank you for using";
            ViewBag.Currency = "£"; //TODO load user's currency
            return View();
        }


        /// <summary>
        /// Process the withdrawal
        /// </summary>
        /// <param name="amount">The total amount of the withdrawal</param>
        /// <param name="currencyName">The name of the currency to use for the withdrawal</param>
        /// <returns>JsonResult containing the amount and a list of MoneyViewModel to display</returns>
        [HttpPost]
        public JsonResult GetAtmChange(int amount, string currencyName)
        {
            string errorMessage = string.Empty;

            //Check valid parameters
            if(amount == 0 || String.IsNullOrEmpty(currencyName))
            {
                //Log some message
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }
                
            //Get the list of money
            List<Money> listAllMoney = AtmHelper.CalculateChange(currencyName, amount);
            List<Money> listDistinctMoney = listAllMoney.Distinct().ToList();
            
            //Get the list of money view model
            List<MoneyViewModel> listMoneyToDisplay = new List<MoneyViewModel>();
            MoneyViewModel moneyToDisplay = null;
            foreach (Money moneyType in listDistinctMoney)
            {
                moneyToDisplay = new MoneyViewModel();
                moneyToDisplay.Number = listAllMoney.Where(item => item == moneyType).Count();
                moneyToDisplay.DisplayMoney = moneyType;
                listMoneyToDisplay.Add(moneyToDisplay);
            }

            //If there is no money to display throw error
            if (listMoneyToDisplay.Count == 0)
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            return Json(new { displayAmount = amount, listMoney = listMoneyToDisplay }, JsonRequestBehavior.AllowGet);
        }
    }
}