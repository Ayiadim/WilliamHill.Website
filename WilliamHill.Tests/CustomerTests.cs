using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WilliamHill.Data.Models;
using WilliamHill.Data;
using WilliamHill.Tests.Mocks;
using WilliamHill.Service;

namespace WilliamHill.Tests
{
    [TestClass]
    public class CustomerTests
    {
        IRepository<Bet> _mockBetRepository;
        IRepository<Customer> _mockCustomerRepository;
        ICustomerService _customerService;

        [TestCleanup]
        public void Clean()
        {
            _mockBetRepository = null;
            _mockCustomerRepository = null;
            _customerService = null;
        }

        [TestInitialize]
        public void Init()
        {
            _mockBetRepository = new MockBetRepository();
            _mockCustomerRepository = new MockCustomerRepository();
            _customerService = new CustomerService(_mockCustomerRepository, _mockBetRepository);
        }

        [TestMethod]
        public void TestCustomerTotalBets()
        {
            var totalBets = _customerService.GetTotalBets(1);

            var expected = 3;

            Assert.AreEqual(expected, totalBets.Result);
        }

        [TestMethod]
        public void TestCustomerTotalBetAmount()
        {
            var totalBetAmount = _customerService.GetTotalBetAmount(2);

            var expected = 70;
            Assert.AreEqual(expected, totalBetAmount.Result);
        }

        [TestMethod]
        public void TestCustomerTotalBetAmountMultiple()
        {
            var totalBets = _customerService.GetTotalBetAmount();

            var expected = new Dictionary<int, double>();
            expected.Add(1, 120.0);
            expected.Add(2, 70.0);
            expected.Add(3, 329.0);

            Assert.AreEqual(expected[1], totalBets.Result[1]);
            Assert.AreEqual(expected[2], totalBets.Result[2]);
            Assert.AreEqual(expected[3], totalBets.Result[3]);
        }

        [TestMethod]
        public void TestRiskyCustomers()
        {
            var riskyCustomers = _customerService.GetRiskyCustomers();
            var list = (List<Customer>)riskyCustomers.Result;

            var expected = 1;
            Assert.AreEqual(expected, list.Count);
        }
    }
}
