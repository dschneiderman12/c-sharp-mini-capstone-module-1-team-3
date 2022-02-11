using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone;

namespace CapstoneTests
{
    [TestClass]
    public class MenuTests
    {


        [TestMethod]

        public void PrintMenu_HappyPath()
        {

            //Arrage
            Menu menu = new Menu();
            Item item = new Item();
            //   Dictionary<string, >


            //Act


            //Assert
        }
        [TestMethod]
        public void ItemExists_HappyPath()
        {
            //Arrange
            Menu menu = new Menu();
            Menu.GetMenu();
            string testInput = "A1";
            //Act
            bool result = menu.ItemExists(testInput);
            //Assert
            Assert.IsTrue(result);
        }
        [TestMethod("ItemExists() should return false if user inputs a non existent item ")]
        public void ItemExists_FalseTest()
        {
            //Arrange
            Menu menu = new Menu();
            Menu.GetMenu();
            string testInput = "A6";
            //Act
            bool result = menu.ItemExists(testInput);
            //Assert
            Assert.IsFalse(result);
        }
        [TestMethod("ItemAvailable() should return false if an item quantity is 0")]

        public void ItemAvailable_OutOfStockTest()
        {
            //Arrange
            Menu menu = new Menu();
            Item item = new Item();
            Menu.GetMenu();
           
            menu.ItemMenu["A1"].Quantity = 0;
            string testInput = "A1";
            //Act
            bool result = menu.ItemAvailable(testInput);
            //Assert
            Assert.IsFalse(result);
            

        }
        [TestMethod("ItemAvailable() should return true if an item quantity is greater than 0")]

        public void ItemAvailable_InStockTest()
        {
            //Arrange
            Menu menu = new Menu();
            Item item = new Item();
            Menu.GetMenu();

            menu.ItemMenu["A1"].Quantity = 1;
            string testInput = "A1";
            //Act
            bool result = menu.ItemAvailable(testInput);
            //Assert
            Assert.IsTrue(result);


        }

















    }
}
