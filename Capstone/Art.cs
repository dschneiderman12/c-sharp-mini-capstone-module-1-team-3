using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone
{
    public class Art
    {
        Menu menu = new Menu();
        
        public void ItemPicture(string picFile)
        {
            Menu.GetMenu();
            string directory = Environment.CurrentDirectory;
            string file = picFile;
            string pic = Path.Combine(directory, file);

            try
            {
                using (StreamReader sr = new StreamReader(pic))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        Console.WriteLine(line);
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Provides an item message and picture when purchased, depending on the type selected and matched in dictionary from the item code
        /// </summary>
        /// <param name="userSelection">Item code provided by user</param>
        /// 
       /* public string ItemMessage(string userSelection)
        {
            
            
            if (menu.ItemMenu[userSelection].Type == "Chip")
            {
                ItemPicture("chips.txt");
                return "Crunch Crunch, Yum!";
            }
            else if (ItemMenu[userSelection].Type == "Candy")
            {
                ItemPicture("candy.txt");
                return "Munch Munch, Yum!";
            }
            else if (ItemMenu[userSelection].Type == "Drink")
            {
                ItemPicture("drink.txt");
                return "Glug Glug, Yum!";
            }
            else if (ItemMenu[userSelection].Type == "Gum")
            {
                ItemPicture("gum.txt");
                return "Chew Chew, Yum!";
            }
            return "";
        }*/



    }
}
