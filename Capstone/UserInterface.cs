using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone
{
    public class UserInterface : IColorable
    {
        public static void MainMenu()
        {
            Transactions transaction = new Transactions();
            Menu menu = new Menu();
            Menu.GetMenu();
            menu.ItemPicture("welcome.txt");

            string mainMenuChoice;
            do
            {

                Console.WriteLine("(1) Display Vending Machine Items");
                Console.WriteLine("(2) Purchase");
                Console.WriteLine("(3) Exit");

                mainMenuChoice = Console.ReadLine();
                Console.WriteLine();

                if (mainMenuChoice == "1")
                {

                    menu.PrintMenu();
                }

                string purchaseChoice = "";

                string directory = Environment.CurrentDirectory;
                string file = "Log.txt";
                string logFile = Path.Combine(directory, file);
                try
                {
                    using (StreamWriter sw = new StreamWriter(logFile, true))
                    {
                        if (mainMenuChoice == "2")
                        {
                            do
                            {
                                Console.WriteLine("(1) Feed Money");
                                Console.WriteLine("(2) Select Product");
                                Console.WriteLine("(3) Finish Transaction\n");

                                IColorable.Color($"Your current balance is {transaction.Balance.ToString("C")}\n", ConsoleColor.Green);

                                purchaseChoice = Console.ReadLine();
                                Console.WriteLine();

                                if (purchaseChoice == "1")
                                {
                                    Console.Write("Please enter whole dollar amount (no decimal): ");

                                    string moneyInput = Console.ReadLine();
                                    Console.WriteLine();

                                    if (transaction.FeedMoney(moneyInput))
                                    {
                                        sw.WriteLine($"{DateTime.Now} FEED MONEY: ${moneyInput}.00 {transaction.Balance.ToString("C")}");
                                    }
                                }

                                if (purchaseChoice == "2")
                                {
                                    menu.PrintMenu();
                                    Console.Write("Select the location of your desired snack: ");
                                    string selection = Console.ReadLine().ToUpper();
                                    Console.WriteLine();

                                    if (menu.ItemExists(selection))
                                    {
                                        if (menu.ItemAvailable(selection))
                                        {
                                            if (transaction.PurchaseItem(menu.ItemMenu[selection].Price))
                                            {
                                                menu.ItemMenu[selection].Quantity--;

                                                Console.WriteLine($"Dispensing {menu.ItemMenu[selection].ProductName} for " +
                                                    $"{menu.ItemMenu[selection].Price.ToString("C")}");

                                                Console.WriteLine(menu.ItemMessage(selection));
                                                Console.WriteLine();

                                                sw.WriteLine($"{DateTime.Now} {menu.ItemMenu[selection].ProductName} " +
                                                    $"{menu.ItemMenu[selection].SlotLocation} " +
                                                    $"{(transaction.Balance + menu.ItemMenu[selection].Price).ToString("C")} " +
                                                    $"{transaction.Balance.ToString("C")}");
                                            }
                                        }
                                        else
                                        {
                                            IColorable.Color("Sold Out :( Try again later!\n", ConsoleColor.Red);
                                        }
                                    }
                                    else
                                    {
                                        IColorable.Color("Item location code not found. Please try again.\n", ConsoleColor.Red);
                                    }
                                }
                                else if (purchaseChoice != "1" && purchaseChoice != "2" && purchaseChoice != "3")
                                {
                                    IColorable.Color("Invalid choice. Please choose 1, 2, or 3.\n", ConsoleColor.Red);
                                }

                            } while (purchaseChoice != "3");
                        }
                        if (purchaseChoice == "3")
                        {
                            Console.WriteLine($"Your remaining balance is {transaction.Balance.ToString("C")}.");
                            sw.WriteLine($"{DateTime.Now} GIVE CHANGE: {transaction.Balance.ToString("C")} $0.00");
                            transaction.GiveChange();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                if (mainMenuChoice == "3")
                {
                    menu.GoodbyeMessage();
                }

                if (mainMenuChoice == "4")
                {
                    Console.Write("Please enter password for sales report: ");
                    string password = Console.ReadLine();
                    Console.WriteLine();
                    if (password == "Interpolation")
                    {
                        menu.SalesReport();
                    }
                    else
                    {
                        IColorable.Color("Password incorrect.\n", ConsoleColor.Red);
                    }
                }
                else if (mainMenuChoice != "1" && mainMenuChoice != "2" && mainMenuChoice != "3" && mainMenuChoice != "4")
                {
                    IColorable.Color("Invalid choice. Please choose 1, 2, or 3.\n", ConsoleColor.Red);
                }

            } while (mainMenuChoice != "3");
        }
    }
}
