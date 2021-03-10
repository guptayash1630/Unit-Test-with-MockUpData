using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Test.Controllers
{
    public class InventoryController : Controller
    {
        List<string> inventory = new List<string>() {
           "Item1",
           "Item2",
           "Item3",
           "Item4"
        };
        List<string> cardDetail = new List<string>() {
           "4565123478650092",
           "3465123478650092",
           "8465123478650092",
           "4567800478650092"
        };
        // GET: Inventory
        public ActionResult Index()
        {
            return View();
        }
        public bool CheckInventory(string productId, int qty)
        {
            bool quantity = false;
            if (inventory.Contains(productId) == true)
            {
                quantity = true;
            }
            if (inventory.Contains(productId) == true && qty > 0)
            {
                //passing number credit card number and amount here directly
                ChargePayment("ABC", decimal.Parse("100.01"));
            }
            return quantity;
        }
        public bool ChargePayment(string creditCardNumber, decimal amount)
        {
            bool isPayment = false;
            if (cardDetail.Contains(creditCardNumber) == true)
            {
                isPayment = true;
            }

            return isPayment;
        }
    }
}