using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class Transactions
    {
        public decimal Balance { get; set; }
        public void FeedMoney( string moneyToFeed)
        {
            
            int wholeNumber;
            bool success = int.TryParse(moneyToFeed, out wholeNumber);
            if (success)
            {
                decimal moneyAdd = decimal.Parse(moneyToFeed);
                this.Balance = this.Balance += moneyAdd;
            }
            else
            {
                Console.WriteLine("Please enter a whole dollar amount");
            }
        }
        public bool PurchaseItem(decimal price)
        {

            if (this.Balance >= price)
            {
                this.Balance -= price;
                return true;
            }
            else
            {
                Console.WriteLine("Insufficient funds.");
                return false;
            }  
                
            
        }

    }
}
