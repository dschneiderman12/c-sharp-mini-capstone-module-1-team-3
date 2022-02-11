using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class Menu : IMenuable
    {
        //private static Dictionary<string, Item> itemMenu = new Dictionary<string, Item>();
        public Dictionary<string, Item> ItemMenu
        {
            get
            {
                return IMenuable.GetMenu();
            }
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
            bool exists = ItemMenu.ContainsKey(itemLocation) ? true : false;
            return exists;
        }

        public bool ItemAvailable(string itemLocation)
        {
            bool available = ItemMenu.ContainsKey(itemLocation) ? true : false;
            return available;
        }

        /// <summary>
        /// Provides an item message when purchased, depending on the type selected and matched in dictionary from the item code
        /// </summary>
        /// <param name="userSelection">Item code provided by user</param>
        public void ItemMessage(string userSelection)
        {
            if (ItemMenu[userSelection].Type == "Chip")
            {
                Console.WriteLine("Crunch Crunch, Yum!\n");
            }
            else if (ItemMenu[userSelection].Type == "Candy")
            {
                Console.WriteLine("Munch Munch, Yum!\n");
            }
            else if (ItemMenu[userSelection].Type == "Drink")
            {
                Console.WriteLine("Glug Glug, Yum!\n");
            }
            else if (ItemMenu[userSelection].Type == "Gum")
            {
                Console.WriteLine("Chew Chew, Yum!\n");
            }
        }
    }
}
