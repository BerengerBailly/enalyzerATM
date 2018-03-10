using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace enalyzerATM.Models
{
    public class Currency
    {
        private string symbol;
        private string name;
        private List<Money> listMoney;

        public List<Money> ListMoney
        {
            get { return listMoney; }
            set { listMoney = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Symbol
        {
            get { return symbol; }
            set { symbol = value; }
        }

        /// <summary>
        /// By default, return default English currency.
        /// See the json res file for newest Englush currency
        /// </summary>
        public Currency()
        {
            symbol = "£";
            name = "GBP";
            listMoney = new List<Money>();
            listMoney.Add(new Money(MoneyType.Notes, 0, 1000, "Notes"));
            listMoney.Add(new Money(MoneyType.Notes, 0, 500, "Notes"));
            listMoney.Add(new Money(MoneyType.Notes, 0, 200, "Notes"));
            listMoney.Add(new Money(MoneyType.Notes, 0, 100, "Notes"));
            listMoney.Add(new Money(MoneyType.Notes, 0, 50, "Notes"));
            listMoney.Add(new Money(MoneyType.Coin, 40, 20, "Coins"));
            listMoney.Add(new Money(MoneyType.Coin, 20, 10, "Coins"));
            listMoney.Add(new Money(MoneyType.Coin, 50, 5, "Coins"));
            listMoney.Add(new Money(MoneyType.Coin, 30, 2, "Coins"));
            listMoney.Add(new Money(MoneyType.Coin, 10, 1, "Coins"));
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">The name of the currency (ex : Pound, US Dollar, Danish Crown, ...)</param>
        /// <param name="symbol">Symbol associate to the currency (ex: €, $, ...)</param>
        /// <param name="listMoney">List of money type of the currency</param>
        public Currency(List<Money> listMoney, string name, string symbol)
        {
            this.name = name;
            this.symbol = symbol;
            this.listMoney = listMoney;
        }
    }
}