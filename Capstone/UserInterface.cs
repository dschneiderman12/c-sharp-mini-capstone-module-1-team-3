﻿using System;
using System.Collections.Generic; 
using System.Text;
using System.IO;

namespace Capstone
{
    public class UserInterface
    {
        public static void MainMenu()
        {
            Transactions transaction = new Transactions();
            Menu menu = new Menu();
            Menu.GetMenu();

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
                                Console.WriteLine("(3) Finish Transaction");

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
                                    Console.WriteLine($"Your balance is {transaction.Balance.ToString("C")}\n");
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

                                                Console.WriteLine($"Remaining Balance: {transaction.Balance.ToString("C")}\n");

                                                sw.WriteLine($"{DateTime.Now} {menu.ItemMenu[selection].ProductName} " +
                                                    $"{menu.ItemMenu[selection].SlotLocation} " +
                                                    $"{(transaction.Balance + menu.ItemMenu[selection].Price).ToString("C")} " +
                                                    $"{transaction.Balance.ToString("C")}");
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Sold Out :( Try again later!\n");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Item location code not found. Please try again.\n");
                                    }
                                }

                            } while (purchaseChoice != "3");
                        }

                        if (purchaseChoice == "3")
                        {
                            Console.WriteLine($"Your Remaining Balance is {transaction.Balance.ToString("C")}.");
                            sw.WriteLine($"{DateTime.Now} GIVE CHANGE: {transaction.Balance.ToString("C")} $0.00");
                            Console.WriteLine(transaction.GiveChange());
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                if (mainMenuChoice == "3")
                {
                    
                    string directory2 = Environment.CurrentDirectory;
                    string file2 = "applause.txt";
                    string candyPic = Path.Combine(directory2, file2);

                    try
                    {
                        using (StreamReader sr = new StreamReader(candyPic))
                        {
                            while (!sr.EndOfStream)
                            {
                                string line = sr.ReadLine();
                                Console.WriteLine(line);
                            }
                        }
                        
                    }
                    catch (IOException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    Console.WriteLine();
                    Console.WriteLine("\x1b[1mThanks for shopping with us! Have a great day!\x1b[0m\n");
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
                        
                        Console.ForegroundColor = ConsoleColor.Red;
                        
                        Console.WriteLine("Password incorrect.\n");
                        
                        Console.ForegroundColor = ConsoleColor.White;
                  
                    }
                }

            } while (mainMenuChoice != "3");
        }
    }
}
