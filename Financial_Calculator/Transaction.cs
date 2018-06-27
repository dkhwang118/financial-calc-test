/* Transaction.cs
 * Author: David K Hwang
 */
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financial_Calculator
{
    public class Transaction
    {
        public string Date { get; }
        public string Description { get; }
        public decimal Debit { get; }
        public decimal Credit { get; }
        public string Category { get; }

        /// <summary>
        /// Class holding a single transaction's data
        /// </summary>
        /// <param name="date">Date of transaction</param>
        /// <param name="desc">Description as posted by online bank platform</param>
        /// <param name="debit">Amount debited</param>
        /// <param name="credit">Amount Credited</param>
        /// <param name="cat">Category of Transaction</param>
        public Transaction(string date, string desc, decimal debit, decimal credit, string cat)
        {
            Date = date;
            Description = desc;
            Debit = debit;
            Credit = credit;
            Category = cat;
        }

    }
}
