using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace enalyzerATM.Models
{  

    public class Money
    {
        private int amount;
        private int size;
        private MoneyType type;
        private string symbol;

        /// <summary>
        /// Name of the money symbol
        /// Improve to use Image in the futur
        /// </summary>
        public string Symbol
        {
            get { return symbol; }
            set { symbol = value; }
        }

        /// <summary>
        /// Type of the money (Notes or Coin)
        /// </summary>
        public MoneyType Type
        {
            get { return type; }
            set { type = value; }
        }

        /// <summary>
        /// Size (0 for notes, X for coins)
        /// </summary>
        public int Size
        {
            get { return size; }
            set { size = value; }
        }

        /// <summary>
        /// Value of the money
        /// </summary>
        public int Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="type">Type of the money</param>
        /// <param name="size">Size of the money</param>
        /// <param name="amount">Amount of the money</param>
        /// <param name="symbol">Symbol of the money</param>
        public Money(MoneyType type, int size, int amount, string symbol)
        {
            this.type = type;
            this.size = size;
            this.amount = amount;
            this.symbol = symbol;
        }
    }

    /// <summary>
    /// Enumeration of money type
    /// </summary>
    public enum MoneyType { Notes, Coin }

}