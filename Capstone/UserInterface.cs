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
            Inventory inventory = new Inventory();
            ArtMessages art = new ArtMessages();
            Inventory.GetMenu();
            art.GetPicture("welcome.txt");

            string mainMenuChoice;
            do
            {
                Console.WriteLine("│**************| Main Menu |**************│");
                Console.WriteLine("│                                         │");
                Console.WriteLine("│    (1) Display Vending Machine Items    │");
                Console.WriteLine("│              (2) Purchase               │");
                Console.WriteLine("│                (3) Exit                 │");
                Console.WriteLine("│                                         │");
                Console.WriteLine("│*****************************************│");

                mainMenuChoice = Console.ReadLine();
                Console.WriteLine();

                if (mainMenuChoice == "1")
                {

                    inventory.PrintMenu();
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
                                Console.WriteLine("│************| Purchase Menu |************│");
                                Console.WriteLine("│                                         │");
                                Console.WriteLine("│             (1) Feed Money              │");
                                Console.WriteLine("│           (2) Select Product            │");
                                Console.WriteLine("│         (3) Finish Transaction          │");
                                Console.WriteLine("│                                         │");
                                Console.WriteLine("│*****************************************│\n");

                                IColorable.Color($"Your current balance is {transaction.Balance.ToString("C")}\n\n", ConsoleColor.Green);

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
                                    inventory.PrintMenu();
                                    Console.Write("Select the location of your desired snack: ");
                                    string selection = Console.ReadLine().ToUpper();
                                    Console.WriteLine();

                                    if (inventory.ItemExists(selection))
                                    {
                                        if (inventory.ItemAvailable(selection))
                                        {
                                            if (transaction.PurchaseItem(inventory.ItemMenu[selection].Price))
                                            {
                                                inventory.ItemMenu[selection].Quantity--;

                                                Console.WriteLine($"Dispensing {inventory.ItemMenu[selection].ProductName} for " +
                                                    $"{inventory.ItemMenu[selection].Price.ToString("C")}");

                                                Console.WriteLine(art.ItemMessage(selection));
                                                Console.WriteLine();

                                                sw.WriteLine($"{DateTime.Now} {inventory.ItemMenu[selection].ProductName} " +
                                                    $"{inventory.ItemMenu[selection].SlotLocation} " +
                                                    $"{(transaction.Balance + inventory.ItemMenu[selection].Price).ToString("C")} " +
                                                    $"{transaction.Balance.ToString("C")}");
                                            }
                                        }
                                        else
                                        {
                                            IColorable.Color("Sold Out :( Try again later!\n\n", ConsoleColor.Red);
                                        }
                                    }
                                    else
                                    {
                                        IColorable.Color("Item location code not found. Please try again.\n\n", ConsoleColor.Red);
                                    }
                                }
                                else if (purchaseChoice != "1" && purchaseChoice != "2" && purchaseChoice != "3")
                                {
                                    IColorable.Color("Invalid choice. Please choose 1, 2, or 3.\n\n", ConsoleColor.Red);
                                }

                            } while (purchaseChoice != "3");
                        }
                        if (purchaseChoice == "3")
                        {
                            Console.WriteLine($"Your remaining balance is {transaction.Balance.ToString("C")}.\n");
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
                    art.GoodbyeMessage();
                }

                if (mainMenuChoice == "4")
                {
                    Console.Write("Please enter password for sales report: ");
                    string password = Console.ReadLine();
                    Console.WriteLine();
                    if (password == "Interpolation")
                    {
                        inventory.SalesReport();
                    }
                    else
                    {
                        IColorable.Color("Password incorrect.\n\n", ConsoleColor.Red);
                    }
                }
                else if (mainMenuChoice != "1" && mainMenuChoice != "2" && mainMenuChoice != "3" && mainMenuChoice != "4")
                {
                    IColorable.Color("Invalid choice. Please choose 1, 2, or 3.\n\n", ConsoleColor.Red);
                }

            } while (mainMenuChoice != "3");
        }
    }
}
