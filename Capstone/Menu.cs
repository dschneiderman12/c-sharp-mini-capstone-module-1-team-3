﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone
{
    public class Menu
    {
        private static Dictionary<string, Item> itemDictionary = new Dictionary<string, Item>();
        public Dictionary<string, Item> ItemDictionary
        {
            get
            {
                return itemDictionary;
            }
        }

        /// <summary>
        /// Reads the vendingmachine.csv file, splits components and builds a dictionary with each item
        /// </summary>
        /// <returns>Item location as key, all properties of an item as the value</returns>
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
                        itemDictionary[lineArray[0]] = newItem;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return itemDictionary;
        }

        /// <summary>
        /// Prints items, their locations(item codes), prices, and remaining quantity of each
        /// </summary>
        public void PrintMenu()
        {
            foreach (KeyValuePair<string, Item> kvp in this.ItemDictionary)
            {
                Console.WriteLine($"{kvp.Key}-{kvp.Value.ProductName} {kvp.Value.Price.ToString("C")}, {kvp.Value.Quantity} remaining");
            }
        }

        /// <summary>
        /// Checks to see if the selected item is in the dictionary, and if it is, are there any still available to purchase
        /// </summary>
        /// <param name="itemLocation">Item code provided by user</param>
        /// <returns>True if the item has not yet run out, false if there are none left or if the code is not one listed in the dictionary</returns>
        public bool ItemAvailability(string itemLocation)
        {
            if (itemDictionary.ContainsKey(itemLocation))
            {
                if (itemDictionary[itemLocation].Quantity > 0)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("Sold Out :( Try again later!");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Item location code not found. Please try again");
                return false;
            }
        }

        /// <summary>
        /// Provides an item message when purchased, depending on the type selected and matched in dictionary from the item code
        /// </summary>
        /// <param name="userSelection">Item code provided by user</param>
        public void ItemMessage(string userSelection)
        {
            if (ItemDictionary[userSelection].Type == "Chip")
            {
                Console.WriteLine("Crunch Crunch, Yum!");
            }
            else if (ItemDictionary[userSelection].Type == "Candy")
            {
                Console.WriteLine("Munch Munch, Yum!");
            }
            else if (ItemDictionary[userSelection].Type == "Drink")
            {
                Console.WriteLine("Glug Glug, Yum!");
            }
            else if (ItemDictionary[userSelection].Type == "Gum")
            {
                Console.WriteLine("Chew Chew, Yum!");
            }
        }
    }
}
