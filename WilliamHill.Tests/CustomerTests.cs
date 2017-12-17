using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WilliamHill.Data.Models;

namespace WilliamHill.Tests
{
    [TestClass]
    public class CustomerTests
    {
        List<Bet> bets;
        List<Customer> customers;

        [TestCleanup]
        public void Clean()
        {
            customers = null;
            bets = null;
        }

        [TestInitialize]
        public void Init()
        {
            customers = new List<Customer>
            {
                new Customer { ID = 1, Name = "Dimitri" },
                new Customer { ID = 2, Name = "Del" },
                new Customer { ID = 3, Name = "Russel" }
            };

            bets = new List<Bet>
            {
                new Bet { CustomerID = 1, Stake = 50},
                new Bet { CustomerID = 1, Stake = 30},
                new Bet { CustomerID = 1, Stake = 40},
                new Bet { CustomerID = 2, Stake = 20},
                new Bet { CustomerID = 2, Stake = 20},
                new Bet { CustomerID = 2, Stake = 30},
                new Bet { CustomerID = 3, Stake = 40},
                new Bet { CustomerID = 3, Stake = 234},
                new Bet { CustomerID = 3, Stake = 55},
            };
        }

        [TestMethod]
        public void TestCustomerTotalBets()
        {
            var totalBets = bets.Where(b => b.CustomerID == 1).ToList().Count;

            var expected = 3;
            Assert.AreEqual(expected, totalBets);
        }

        [TestMethod]
        public void TestCustomerTotalBetAmount()
        {
            var totalBets = bets.Where(b => b.CustomerID == 2).ToList();

            double total = 0;
            foreach (var bet in totalBets)
            {
                total += bet.Stake;
            }


            var expected = 70;
            Assert.AreEqual(expected, total);
        }

        [TestMethod]
        public void TestCustomerTotalBetAmountMultiple()
        {
            double total = 0;
            foreach (var bet in bets)
            {
                total += bet.Stake;
            }


            var expected = 519;
            Assert.AreEqual(expected, total);
        }

        [TestMethod]
        public void TestRiskyCustomers()
        {
            var riskyCustomers = new List<Customer>();
            foreach (var customer in customers)
            {
                var totalBets = bets.Where(b => b.CustomerID == customer.ID).ToList();
                double totalAmount = 0;
                foreach (var bet in totalBets)
                {
                    totalAmount += bet.Stake;
                }
                if (totalAmount > 200)
                {
                    riskyCustomers.Add(customer);
                }
            }

            var expected = 1;
            Assert.AreEqual(expected, riskyCustomers.Count);
        }
    }
}
