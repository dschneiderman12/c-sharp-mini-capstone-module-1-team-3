using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone
{
    public class Menu
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
            int i = 0;
            string[] menuArray = new string[this.ItemMenu.Count];
            foreach (KeyValuePair<string, Item> kvp in this.ItemMenu)
            { 
                string result = ($"║{kvp.Key}-{kvp.Value.ProductName} {kvp.Value.Price.ToString("C")}, {kvp.Value.Quantity} remaining");
                int length = 42;
                int spacesNeeded = 43 - result.Length;
                string spaces = "";
                for (int j = 0; j < spacesNeeded; j++)
                {
                    spaces += " ";
                }
                result = result + spaces + "║";
            
                { }
                //making the top of box
                string topOfOurBox = "╔";
                
                for (int c = 0; c < length; c++)
                {
                    topOfOurBox+= "═";
                }
                topOfOurBox += "╗";
                //filling the box
        
                //bottom of our box
                string bottomOfBox = "╚";
               
                for (int c = 0; c < length; c++)
                {
                    bottomOfBox+="═";
                }
                bottomOfBox+=("╝");

                if (i % 2 == 0)
                {
                    Console.WriteLine();
                    Console.Write(topOfOurBox);
                    Console.Write(topOfOurBox);
                    Console.WriteLine();
                    Console.Write(result);
                    
                }
                else 
                {
                    Console.Write(result);
                    Console.WriteLine();
                    Console.Write(bottomOfBox + bottomOfBox);
                }
                i++;
                
               
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
        /// 

        public string ItemMessage(string userSelection)
        {
            if (ItemMenu[userSelection].Type == "Chip")
            {
                string directory = Environment.CurrentDirectory;
                string file = "chips.txt";
                string chipsPic = Path.Combine(directory, file);

                try
                {
                    using (StreamReader sr = new StreamReader(chipsPic))
                    {
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            Console.WriteLine(line);
                        }
                    }
                    return "Crunch Crunch, Yum!";
                }
                catch (IOException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else if (ItemMenu[userSelection].Type == "Candy")
            {
                string directory = Environment.CurrentDirectory;
                string file = "candy.txt";
                string candyPic = Path.Combine(directory, file);
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
                    return "Munch Munch, Yum!";
                }
                catch (IOException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else if (ItemMenu[userSelection].Type == "Drink")
            {
                string directory = Environment.CurrentDirectory;
                string file = "drink.txt";
                string drinkPic = Path.Combine(directory, file);

                try
                {
                    using (StreamReader sr = new StreamReader(drinkPic))
                    {
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            Console.WriteLine(line);
                        }

                    }
                    return "Glug Glug, Yum!";
                }
                catch (IOException ex)
                {
                    Console.WriteLine(ex.Message);
                }


            }
            else if (ItemMenu[userSelection].Type == "Gum")
            {
                string directory = Environment.CurrentDirectory;
                string file = "Gum.txt";
                string gumPic = Path.Combine(directory, file);
                try
                {
                    using (StreamReader sr = new StreamReader(gumPic))
                    {
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            Console.WriteLine(line);
                        }

                    }
                    return "Chew Chew, Yum!";
                }
                catch (IOException ex)
                {
                    Console.WriteLine(ex.Message);
                }


            }
            return "";
        }


        private void CalculateSales()
        {
            string directory = Environment.CurrentDirectory;
            string file = "Log.txt";
            string logFile = Path.Combine(directory, file);

            try
            {
                using (StreamReader sr = new StreamReader(logFile))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        foreach (KeyValuePair<string, Item> kvp in ItemMenu)
                        {
                            if (line.Contains(kvp.Key))
                            {
                                kvp.Value.NumberSold++;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void SalesReport()
        {
            CalculateSales();

            string directory = Environment.CurrentDirectory;
            string file = $"Sales Report {DateTime.Now.ToString("MM-dd-yyyy HH.mm.ss")}.txt";
            string logFile = Path.Combine(directory, file);

            try
            {
                using (StreamWriter sw = new StreamWriter(logFile, false))
                {
                    foreach (KeyValuePair<string, Item> kvp in ItemMenu)
                    {
                        sw.WriteLine($"{kvp.Value.ProductName}|{kvp.Value.NumberSold}");
                    }
                }
                Console.WriteLine("Sales report generated.\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
