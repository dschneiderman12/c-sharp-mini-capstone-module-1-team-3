using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone;

namespace CapstoneTests
{
    [TestClass]
    public class ArtMessagesTests
    {
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

        [TestMethod]
        public void ItemMessage_DrinkStringTest()
        {
            Inventory menu = new Inventory();
            Item item = new Item();
            ArtMessages art = new ArtMessages();
            Inventory.GetMenu();
            string testInput = "C3";

            //Act
            string result = art.ItemMessage(testInput);

            //Assert
            Assert.AreEqual("Glug Glug, Yum!", result);
        }

        [TestMethod]
        public void ItemMessage_CandyStringTest()
        {
            Inventory menu = new Inventory();
            Item item = new Item();
            ArtMessages art = new ArtMessages();
            Inventory.GetMenu();
            string testInput = "B2";

            //Act
            string result = art.ItemMessage(testInput);

            //Assert
            Assert.AreEqual("Munch Munch, Yum!", result);
        }
    }
}
