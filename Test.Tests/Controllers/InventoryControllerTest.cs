using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Test;
using Test.Controllers;
using Moq;

namespace Test.Tests.Controllers
{
    [TestClass]
    public class InventoryControllerTest
    {
        #region Inventory
        [TestMethod]
        public void Inventory_InventoryExists()
        {
            string productID = "Item1";
            int quantity = 2;
            // Arrange
            InventoryController controller = new InventoryController();

            // Act
            bool result = controller.CheckInventory(productID, quantity);

            // Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void Inventory_InventoryNotExists()
        {
            string productID = "ABCTest";
            int quantity = 2;
            // Arrange
            InventoryController controller = new InventoryController();

            // Act
            bool result = controller.CheckInventory(productID, quantity);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Inventory_MockData()
        {
            string productID = "Item1";
            int quantity = 2;
            Exception ex = new Exception("An exception has occurred");
            //var mockFRepository = new Mock<IFundsRepository>();
            InventoryController inventory = new InventoryController();
            List<dynamic> inventoryList = new List<dynamic>()
            {
               new
               {
                    ItemID=1,
                    ItemName="Item1",
                    Description="ABC test item"
                }
            };

            bool result = inventory.CheckInventory(productID, quantity);
            Assert.IsTrue(result);

            //another way
            //Mock<InventoryController> name = new Mock<InventoryController>();
            //name.CallBase = true;
            //name.Setup(x => x.CheckInventory(productID, quantity)).Returns(true);

            //var results = name.Object.ChargePayment(It.IsAny<string>(), It.IsAny<int>());

            //string expected = string.Format("hello {0}", results);

            //Assert.AreEqual(expected, results);
        }
        #endregion

        #region Payment
        [TestMethod]
        public void Payment_CreditCardExists()
        {
            string cardDetails = "4565123478650092";
            // Arrange
            InventoryController controller = new InventoryController();

            // Act
            bool result = controller.ChargePayment(cardDetails, decimal.Parse("2.03"));

            // Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void Payment_CreditCardNotExists()
        {
            string cardDetails = "CardTest";
            // Arrange
            InventoryController controller = new InventoryController();

            // Act
            bool result = controller.ChargePayment(cardDetails, decimal.Parse("2.03"));

            // Assert
            Assert.IsFalse(result);
        }
        #endregion
    }
}
