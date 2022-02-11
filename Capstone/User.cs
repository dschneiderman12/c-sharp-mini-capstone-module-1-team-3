using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone
{
    public class User //contains user interactions with the vending machine
    {

        public static void MainMenu() //main menu displayed to user
        {
            Transactions transaction = new Transactions();
            Menu menu = new Menu();
            Menu.GetMenu();

            string userMainMenuChoice;
            do
            {
                Console.WriteLine("(1) Display Vending Machine Items");
                Console.WriteLine("(2) Purchase");
                Console.WriteLine("(3) Exit");

                userMainMenuChoice = Console.ReadLine(); // add 4 for hidden sales list

                if (userMainMenuChoice == "1")
                {
                    menu.PrintMenu();
                }

                string userPurchaseChoice = "";

                string directory = Environment.CurrentDirectory;
                string file = "Log.txt";
                string logFile = Path.Combine(directory, file);
                try
                {
                    using (StreamWriter sw = new StreamWriter(logFile, true))
                    {
                        if (userMainMenuChoice == "2")
                        {
                            do
                            {
                                Console.WriteLine("(1) Feed Money");
                                Console.WriteLine("(2) Select Product");
                                Console.WriteLine("(3) Finish Transaction");

                                userPurchaseChoice = Console.ReadLine();

                                if (userPurchaseChoice == "1")
                                {
                                    Console.Write("Please enter whole dollar amount (no decimal): ");

                                    string userMoneyInput = Console.ReadLine();
                                    transaction.FeedMoney(userMoneyInput);
                                    sw.WriteLine($"{DateTime.Now} FEED MONEY: ${userMoneyInput}.00 {transaction.Balance.ToString("C")}");
                                }

                                if (userPurchaseChoice == "2")
                                {
                                    menu.PrintMenu();
                                    Console.WriteLine("Select the location of your desired snack");
                                    string userSelection = Console.ReadLine().ToUpper();

                                    if (menu.ItemAvailability(userSelection))
                                    {
                                        if (transaction.PurchaseItem(menu.ItemDictionary[userSelection].Price))
                                        {
                                            menu.ItemDictionary[userSelection].Quantity--;

                                            Console.WriteLine($"Dispensing {menu.ItemDictionary[userSelection].ProductName} for " +
                                                $"{menu.ItemDictionary[userSelection].Price.ToString("C")}");
                                            Console.WriteLine($"Remaining Balance: {transaction.Balance.ToString("C")}");

                                            sw.WriteLine($"{DateTime.Now} {menu.ItemDictionary[userSelection].ProductName} " +
                                                $"{menu.ItemDictionary[userSelection].SlotLocation} " +
                                                $"{(transaction.Balance + menu.ItemDictionary[userSelection].Price).ToString("C")} " +
                                                $"{transaction.Balance.ToString("C")}");

                                            menu.ItemMessage(userSelection);
                                        }
                                    }
                                }
                            } while (userPurchaseChoice != "3");
                        }

                        if (userPurchaseChoice == "3")
                        {
                            Console.WriteLine($"Your Remaining Balance is {transaction.Balance.ToString("C")}.");
                            sw.WriteLine($"{DateTime.Now} GIVE CHANGE: {transaction.Balance.ToString("C")} $0.00");
                            transaction.GiveChange();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                if (userMainMenuChoice == "3")
                {
                    Console.WriteLine("Thanks for shopping with us! Have a great day!");
                }

            } while (userMainMenuChoice != "3");
        }
    }
}
