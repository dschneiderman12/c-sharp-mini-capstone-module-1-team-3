using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class User //contains user interactions with the vending machine
    {
        public static void MainMenu() //main menu displayed to user
        {
            Transactions transaction = new Transactions();
            string userMainMenuChoice;
            do
            {
                Console.WriteLine("(1) Display Vending Machine Items");
                Console.WriteLine("(2) Purchase");
                Console.WriteLine("(3) Exit");

                userMainMenuChoice = Console.ReadLine(); // add 4 for hidden sales list
            } while (userMainMenuChoice != "1" && userMainMenuChoice != "2" && userMainMenuChoice != "3");

            Menu.GetMenu();
            if (userMainMenuChoice == "1")
            {
                Menu menu = new Menu();
                foreach (Item choice in menu.MenuItems)
                {
                    Console.WriteLine($"{choice.SlotLocation}-{choice.ProductName} {choice.Price.ToString("C")}, {choice.Quantity} remaining");
                }
            }

            if (userMainMenuChoice == "2")
            {
                Console.WriteLine("(1) Feed Money");
                Console.WriteLine("(2) Select Product");
                Console.WriteLine("(3) Finish Transaction");

                string userPurchaseChoice = Console.ReadLine();

                if (userPurchaseChoice == "1")
                {
                    Console.WriteLine("Please enter whole dollar amount (no decimal): ");

                    string userMoneyInput = Console.ReadLine();
                    int wholeNumber;
                    bool success = int.TryParse(userMoneyInput, out wholeNumber);
                    if (success)
                    {
                        decimal moneyAdd = decimal.Parse(userMoneyInput);
                        transaction.Balance = transaction.Balance += moneyAdd;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a whole dollar amount");
                    }
                }
            }
        }
    }
}
