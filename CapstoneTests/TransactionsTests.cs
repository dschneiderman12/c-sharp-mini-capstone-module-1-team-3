﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone;

namespace CapstoneTests
{
    [TestClass]
    public class TransactionsTests
    {
        [TestMethod("FeedMoney() should add money to the balance if given a positive whole number ")]
        public void FeedMoney_WholeNumberTest()
        {
            //Arrange
            Transactions transactions = new Transactions();
            decimal testBalance = 10.00M;
            string testInput = "10";

            //Act
            transactions.FeedMoney(testInput);
            //Assert
            Assert.AreEqual(testBalance, transactions.Balance);
        }
        [TestMethod("FeedMoney() should not add money to the balance if given a negative number ")]
        public void FeedMoney_NegativeNumberTest()
        {
            //Arrange
            Transactions transactions = new Transactions();
            decimal testBalance = 0.00M;
            string testInput = "-10";

            //Act
            transactions.FeedMoney(testInput);
            //Assert
            Assert.AreEqual(testBalance, transactions.Balance);
        }
        [TestMethod("FeedMoney() should not add money to the balance if not given a whole number ")]
        public void FeedMoney_NonWholeNumberTest()
        {
            //Arrange
            Transactions transactions = new Transactions();
            decimal testBalance = 0.00M;
            string testInput = "10.05";

            //Act
            transactions.FeedMoney(testInput);
            //Assert
            Assert.AreEqual(testBalance, transactions.Balance);



        }
   
        [TestMethod]
        public void PurchaseItem_HappyPath()
        {
            Transactions transactions = new Transactions();
            transactions.FeedMoney("5");
            decimal testInput = 3.50M;
            //Act
            transactions.PurchaseItem(testInput);
            //Assert
            Assert.AreEqual(1.50M, transactions.Balance);

        }
        [TestMethod]
        public void PurchaseItem_AllInTest()
        {
            Transactions transactions = new Transactions();
            transactions.FeedMoney("5");
            decimal testInput = 5.00M;
            //Act
            transactions.PurchaseItem(testInput);
            //Assert
            Assert.AreEqual(0.00M, transactions.Balance);

        }
        [TestMethod]
        public void PurchaseItem_EmptyWalletTest()
        {
            Transactions transactions = new Transactions();
            
            decimal testInput = 5.00M;
            //Act
            bool result = transactions.PurchaseItem(testInput);
            //Assert
            Assert.IsFalse(result);

        }
        [TestMethod]
        public void GiveChange_HappyPath()
        {
            //Arrange
            Transactions transactions = new Transactions();
            transactions.FeedMoney("4");
            transactions.PurchaseItem(2.35M);
            string expectedString = "Dispensing: 6 Quarter(s), 1 Dime(s), 1 Nickel(s).\n";
            //Act
            string result = transactions.GiveChange();
            //Assert
            Assert.AreEqual(expectedString, result);
            Assert.AreEqual(transactions.Balance, 0.00M);
        }
        [TestMethod]
        public void GiveChange_NickelAndDimedTest()
        {
            //Arrange
            Transactions transactions = new Transactions();
            transactions.FeedMoney("1");
            transactions.PurchaseItem(0.85M);
            string expectedString = "Dispensing: 0 Quarter(s), 1 Dime(s), 1 Nickel(s).\n";
            //Act
            string result = transactions.GiveChange();
            //Assert
            Assert.AreEqual(expectedString, result);
            Assert.AreEqual(transactions.Balance, 0.00M);
        }




    }
}
