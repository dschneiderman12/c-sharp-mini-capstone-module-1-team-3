﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone
{
    public class ArtMessages
    {
        Inventory menu = new Inventory();

        /// <summary>
        /// Pulls a picture file based on input txt file
        /// </summary>
        /// <param name="picFile">ASCII art text file</param>
        public void GetPicture(string picFile)
        {
            string directory = Environment.CurrentDirectory;
            string file = @"ASCII\" + picFile;
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
        public string ItemMessage(string userSelection)
        {
            if (menu.ItemMenu[userSelection].Type == "Chip")
            {
                GetPicture("chips.txt");
                return "Crunch Crunch, Yum!";
            }
            else if (menu.ItemMenu[userSelection].Type == "Candy")
            {
                GetPicture("candy.txt");
                return "Munch Munch, Yum!";
            }
            else if (menu.ItemMenu[userSelection].Type == "Drink")
            {
                GetPicture("drink.txt");
                return "Glug Glug, Yum!";
            }
            else if (menu.ItemMenu[userSelection].Type == "Gum")
            {
                GetPicture("gum.txt");
                return "Chew Chew, Yum!";
            }
            return "";
        }

        /// <summary>
        /// Provides a goodbye message and picture once user exits the vending machine
        /// </summary>
        /// 
        public void GoodbyeMessage()
        {
            GetPicture("applause.txt");

            Console.WriteLine();
            Console.WriteLine("\x1b[1mThanks for shopping with us! Have a great day!\x1b[0m\n");
        }

    }
}