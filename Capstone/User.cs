using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class User //contains user interactions with the vending machine
    {
        public static void MainMenu() //main menu displayed to user
        {
            string userMainMenuChoice;
            do
            {
                Console.WriteLine("(1) Display Vending Machine Items");
                Console.WriteLine("(2) Purchase");
                Console.WriteLine("(3) Exit");

                userMainMenuChoice = Console.ReadLine(); // add 4 for hidden sales list
            } while (userMainMenuChoice != "1" && userMainMenuChoice != "2" && userMainMenuChoice != "3"); 


        }
    }
}
