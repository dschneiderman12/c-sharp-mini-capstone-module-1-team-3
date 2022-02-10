using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone
{
    public class Menu
    {
        private static List<Item> menuItems = new List<Item>();
        public List<Item> MenuItems
        {
            get
            {
                return menuItems;
            }
        }

        public static List<Item> GetMenu()// read a file and put items into the menu item list
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
                        menuItems.Add(newItem);
                    }
                }
            }
            catch (Exception) { }
            return menuItems;
        }
    }
}
