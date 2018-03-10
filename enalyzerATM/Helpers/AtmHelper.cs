using enalyzerATM.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace enalyzerATM.Helpers
{
    /// <summary>
    /// Class to process some ATM operations
    /// </summary>
    public static class AtmHelper
    {
        /// <summary>
        /// Calculate the change to give to the customer depending on the amount and the currency
        /// </summary>
        /// <param name="currencyName">The currency to use</param>
        /// <param name="amount">The withdrawal amount</param>
        /// <returns>A list of change to return to customer</returns>
        public static List<Money> CalculateChange(string currencyName, int amount)
        {
            List<Money> listChange = new List<Money>(); //List of change
            Currency currentCurrency = LoadCurrency(currencyName);

            if(currentCurrency != null)
            {
                foreach (Money money in currentCurrency.ListMoney)
                {
                    while (amount >= money.Amount)
                    {
                        listChange.Add(money);
                        amount = amount - money.Amount;
                    }
                }
            }

            return listChange;
        }

        /// <summary>
        /// Load the currency associated with the currency name
        /// </summary>
        /// <param name="currencyName">Name of the currency to load</param>
        /// <returns>The currenct currency, null if not found</returns>
        public static Currency LoadCurrency(string currencyName)
        {
            List<Currency> listCurrency = null; //List of all currency
            Currency currentCurrency = null; //The currency to use

            try
            {
                //Parse Json to get all currencies registered
                using (StreamReader r = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "\\Resources\\currencies.json"))
                {
                    string json = r.ReadToEnd();
                    listCurrency = JsonConvert.DeserializeObject<List<Currency>>(json);
                }
                //Retrieve the currency associated to the currency name
                currentCurrency = listCurrency?.Find(item => String.Compare(item.Name, currencyName) == 0);

                if (currentCurrency == null)
                    throw new Exception("No currency was found associated with the currency name " + currencyName);
            }
            catch(Exception e)
            {
                //Log some message
            }
            
            return currentCurrency;
        }
    }
}