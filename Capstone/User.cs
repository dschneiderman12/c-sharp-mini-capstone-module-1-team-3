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
            Menu menu = new Menu();


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

                menu.PrintMenu();
            }
            string userPurchaseChoice = "";
            {
                if (userMainMenuChoice == "2")
                {
                    while (userPurchaseChoice != "3")
                    {





                        Console.WriteLine("(1) Feed Money");
                        Console.WriteLine("(2) Select Product");
                        Console.WriteLine("(3) Finish Transaction");

                        userPurchaseChoice = Console.ReadLine();

                        if (userPurchaseChoice == "1")
                        {
                            Console.WriteLine("Please enter whole dollar amount (no decimal): ");

                            string userMoneyInput = Console.ReadLine();
                            transaction.FeedMoney(userMoneyInput);
                        }
                        if (userPurchaseChoice == "2")
                        {
                            menu.PrintMenu();
                            Console.WriteLine("Select the location of your desired snack");
                            string userSelection = Console.ReadLine().ToUpper();

                            if (menu.CanChangeQuantity(userSelection))
                            {
                                if (transaction.PurchaseItem(menu.ItemDictionary[userSelection].Price))
                                {
                                    menu.ItemDictionary[userSelection].Quantity--;
                                    Console.WriteLine($"Dispensing {menu.ItemDictionary[userSelection].ProductName} for {menu.ItemDictionary[userSelection].Price.ToString("C")}");
                                    Console.WriteLine($"Remaining Balance: {transaction.Balance.ToString("C")}");
                                    
                                    if (menu.ItemDictionary[userSelection].Type == "Chip")
                                    {
                                        Console.WriteLine("Crunch Crunch, Yum!");
                                    }
                                    else if(menu.ItemDictionary[userSelection].Type == "Candy")
                                    {
                                        Console.WriteLine("Munch Munch, Yum!");

                                    }
                                    else if(menu.ItemDictionary[userSelection].Type == "Drink")
                                    {
                                        Console.WriteLine("Glug Glug, Yum!");
                                    }
                                    else if(menu.ItemDictionary[userSelection].Type == "Gum")
                                    {
                                        Console.WriteLine("Chew Chew, Yum!");
                                    }
                                }
                            }
                        }
                    }
                    if (userPurchaseChoice == "3")
                    {
                        Console.WriteLine($"Your Remaining Balance is {transaction.Balance.ToString("C")}.");
                        transaction.GiveChange();
                    
                    }
                }
            }
            
        }
        
       
    }
}
