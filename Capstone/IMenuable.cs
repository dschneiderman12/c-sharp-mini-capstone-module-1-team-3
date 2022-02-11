using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone
{
    interface IMenuable
    {
        private static Dictionary<string, Item> itemMenu = new Dictionary<string, Item>();

        /// <summary>
        /// Reads the vendingmachine.csv file, splits components and builds a dictionary with each item
        /// </summary>
        /// <returns>Item location as key, all properties of an item as the value</returns>
       // public static Dictionary<string, Item> GetMenu()
       // {
       //     string directory = Environment.CurrentDirectory;
       //     string file = "vendingmachine.csv";
       //     string menuFile = Path.Combine(directory, file);
       //
       //     try
       //     {
       //         using (StreamReader sr = new StreamReader(menuFile))
       //         {
       //             while (!sr.EndOfStream)
       //             {
       //                 string line = sr.ReadLine();
       //                 string[] lineArray = line.Split("|");
       //                 decimal price = decimal.Parse(lineArray[2]);
       //
       //                 Item newItem = new Item(lineArray[0], lineArray[1], price, lineArray[3]);
       //                 itemMenu[lineArray[0]] = newItem;
       //             }
       //         }
       //     }
       //     catch (Exception ex)
       //     {
       //         Console.WriteLine(ex.Message);
       //     }
       //     return itemMenu;
       // }
    }
}
