using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class Transactions
    {
        public decimal Balance { get; private set; }

        /// <summary>
        /// Accepts money from user and adds it to the balance, making sure the amount given is a whole number
        /// </summary>
        /// <param name="moneyToFeed">number input from user</param>
        public void FeedMoney(string moneyToFeed)
        {
            int wholeNumber;
            bool success = int.TryParse(moneyToFeed, out wholeNumber);
            if (success && wholeNumber > 0)

            {
                decimal moneyAdd = decimal.Parse(moneyToFeed);

                this.Balance = this.Balance += moneyAdd;
            }
            else
            {
                Console.Write("Please enter a whole dollar amount: ");
            }
        }

        /// <summary>
        /// Checks that the price of the item selected is not more than the remaining balance, 
        /// and subtracts the price from the balance if true.  
        /// Otherwise, lets the user know they do not have enough to purchase the item.
        /// </summary>
        /// <param name="price">reads the price of the item selected</param>
        /// <returns>returns true if there is enough money for the item, or false if not</returns>
        public bool PurchaseItem(decimal price)
        {

            if (this.Balance >= price)
            {
                this.Balance -= price;
                return true;
            }
            else
            {
                Console.WriteLine("Insufficient funds.\n");
                return false;
            }
        }

        /// <summary>
        /// Takes the remaining balance and provides change in quarters, dimes, and nickels using the fewest coins possible.
        /// </summary>
        public string GiveChange()
        {
            int quarter = 0;
            int dime = 0;
            int nickel = 0;
            while (this.Balance >= .25M)
            {
                quarter++;
                this.Balance -= .25M;
            }
            while (this.Balance >= .10M)
            {
                dime++;
                this.Balance -= .10M;
            }
            while (this.Balance >= .05M)
            {
                nickel++;
                this.Balance -= .05M;
            }
            return$"Dispensing: {quarter} Quarter(s), {dime} Dime(s), {nickel} Nickel(s).\n";
        }
    }
}
