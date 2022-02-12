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
        public void ItemExists_HappyPath()
        {
            //Arrange
            Inventory menu = new Inventory();
            Inventory.GetMenu();
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
            Inventory menu = new Inventory();
            Inventory.GetMenu();
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
            Inventory menu = new Inventory();
            Item item = new Item();
            Inventory.GetMenu();

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
            Inventory menu = new Inventory();
            Item item = new Item();
            Inventory.GetMenu();

            menu.ItemMenu["A1"].Quantity = 1;
            string testInput = "A1";

            //Act
            bool result = menu.ItemAvailable(testInput);
            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ItemMessage_ChipStringTest()
        {
            Inventory menu = new Inventory();
            Item item = new Item();
            ArtMessages art = new ArtMessages();
            Inventory.GetMenu();
            string testInput = "A1";

            //Act
            string result = art.ItemMessage(testInput);

            //Assert
            Assert.AreEqual("Crunch Crunch, Yum!", result);
        }

        [TestMethod]
        public void ItemMessage_GumStringTest()
        {
            Inventory menu = new Inventory();
            Item item = new Item();
            ArtMessages art = new ArtMessages();
            Inventory.GetMenu();
            string testInput = "D4";

            //Act
            string result = art.ItemMessage(testInput);

            //Assert
            Assert.AreEqual("Chew Chew, Yum!", result);
        }
    }
}
