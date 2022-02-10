using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone
{
    public class Menu
    {
        User menuUser = new User();   
        //private static List<Item> menuItems = new List<Item>();
        //public List<Item> MenuItems
        //{
        //    get
        //    {
        //        return menuItems;
        //    }
        //}
        private static Dictionary<string, Item> itemDictionary = new Dictionary<string, Item>();
        public Dictionary<string, Item> ItemDictionary
        {
            get
            {
                return itemDictionary;
            }
        }
        public static Dictionary<string, Item> GetMenu()// read a file and put items into the menu item list
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
                        //menuItems.Add(newItem);
                        itemDictionary[lineArray[0]] = newItem;
                        
                    }
                }
            }
            catch (Exception) { }
            return itemDictionary;
        }

        public void PrintMenu()
        {
            foreach(KeyValuePair<string, Item> kvp in this.ItemDictionary)
                {
                Console.WriteLine($"{kvp.Key}-{kvp.Value.ProductName} {kvp.Value.Price.ToString("C")}, {kvp.Value.Quantity} remaining");
            }
        }
       public bool CanChangeQuantity(string itemLocation)
       {
            
            if (itemDictionary.ContainsKey(itemLocation))
            {
                if(itemDictionary[itemLocation].Quantity > 0)
                {
                    
                    return true;
                }
                else
                {
                    Console.WriteLine("Sold Out:( Try again later!");
                    return false;
                }
               
            }
            else
            {
                Console.WriteLine("Item location code not found. Please try again");
                return false;
            }
       }
    }
}
