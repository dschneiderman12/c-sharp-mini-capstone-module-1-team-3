using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone
{
    public class Menu : IMenuable
    {
        private static Dictionary<string, Item> itemMenu = new Dictionary<string, Item>();
        public Dictionary<string, Item> ItemMenu
        {
            get
            {
                return itemMenu;
            }
        }
        public static Dictionary<string, Item> GetMenu()
        {
            string directory = Environment.CurrentDirectory;
            string file = "vendingmachine.csv";
            string menuFile = Path.Combine(directory, file);
       
            try
            {
                using (StreamReader sr = new StreamReader(menuFile))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] lineArray = line.Split("|");
                        decimal price = decimal.Parse(lineArray[2]);
       
                        Item newItem = new Item(lineArray[0], lineArray[1], price, lineArray[3]);
                        itemMenu[lineArray[0]] = newItem;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return itemMenu;
        }
        /// <summary>
        /// Prints items, their locations(item codes), prices, and remaining quantity of each
        /// </summary>
        public void PrintMenu()
        {
            foreach (KeyValuePair<string, Item> kvp in this.ItemMenu)
            {
                Console.WriteLine($"{kvp.Key}-{kvp.Value.ProductName} {kvp.Value.Price.ToString("C")}, {kvp.Value.Quantity} remaining.");
            }
            Console.WriteLine();
        }

        public bool ItemExists(string itemLocation)
        {
            bool exists = itemMenu.ContainsKey(itemLocation) ? true : false;
            return exists;
        }

        public bool ItemAvailable(string itemLocation)
        {
            bool available = ItemMenu[itemLocation].Quantity > 0 ? true : false;
            return available;
        }

        /// <summary>
        /// Provides an item message when purchased, depending on the type selected and matched in dictionary from the item code
        /// </summary>
        /// <param name="userSelection">Item code provided by user</param>
        public string ItemMessage(string userSelection)
        {
            if (ItemMenu[userSelection].Type == "Chip")
            {
               return "Crunch Crunch, Yum!";
            }
            else if (ItemMenu[userSelection].Type == "Candy")
            {
                return "Munch Munch, Yum!";
            }
            else if (ItemMenu[userSelection].Type == "Drink")
            {
                return "Glug Glug, Yum!";
            }
            else if (ItemMenu[userSelection].Type == "Gum")
            {
                return "Chew Chew, Yum!";
            }
            return "";
        }
    }
}
