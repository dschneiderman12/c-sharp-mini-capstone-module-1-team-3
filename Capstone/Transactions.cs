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
        public void GiveChange()
        {
            int quarter = 0;
            int dime = 0;
            int nickel = 0;
            while (this.Balance >= .25M)
            {
                quarter++;
                Balance -= .25M;
            
            }
            while (this.Balance >= .10M)
            {
                dime++;
                Balance -= .10M;
            
            }
            while (this.Balance >= .05M)
            {
                nickel++;
                Balance -= .05M;
            }
            Console.WriteLine($"Dispensing: {quarter} Quarter(s), {dime} Dime(s), {nickel} Nickel(s)");
        }

    }
}
