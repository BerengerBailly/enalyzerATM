using enalyzerATM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace enalyzerATM.ViewModel
{
    /// <summary>
    /// View model of the money model
    /// </summary>
    public class MoneyViewModel
    {
        private int number;
        private Money displayMoney;

        public Money DisplayMoney
        {
            get { return displayMoney; }
            set { displayMoney = value; }
        }

        public int Number
        {
            get { return number; }
            set { number = value; }
        }


    }
}