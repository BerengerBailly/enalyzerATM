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
            List<MoneyViewModel> listMoneyToDisplay = new List<MoneyViewModel>();

            try
            {
                //Check valid parameters
                if (amount == 0 || String.IsNullOrEmpty(currencyName))
                    throw new Exception("Invalid parameters passed to the method");

                //Get the list of money
                List<Money> listAllMoney = AtmHelper.CalculateChange(currencyName, amount);
                List<Money> listDistinctMoney = listAllMoney.Distinct().ToList();

                //Get the list of money view model
                
                MoneyViewModel moneyToDisplay = null;
                foreach (Money moneyType in listDistinctMoney)
                {
                    moneyToDisplay = new MoneyViewModel();
                    moneyToDisplay.Number = listAllMoney.Where(item => item == moneyType).Count();
                    moneyToDisplay.DisplayMoney = moneyType;
                    listMoneyToDisplay.Add(moneyToDisplay);
                }

                //If there is no money to display return explicit message to the client
                if (listMoneyToDisplay.Count == 0)
                    throw new Exception("No money to return");

            }
            catch(Exception e)
            {
                //TODO Log exception
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }

            return Json(new { displayAmount = amount, listMoney = listMoneyToDisplay }, JsonRequestBehavior.AllowGet);
              
        }
    }
}