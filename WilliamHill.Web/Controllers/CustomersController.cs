using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using WilliamHill.Data.Models;
using WilliamHill.Web.Helpers;

namespace WilliamHill.Web.Controllers
{
    public class CustomersController : Controller
    {
        private readonly IConfiguration _config;
        private string customersEndpoint;
        private string betsEndpoint;
        private const int RISKY_THRESHOLD = 200;


        public CustomersController(IConfiguration config)
        {
            this._config = config;

            customersEndpoint = string.Format("{0}/{1}?name={2}",
                _config["Endpoints:baseUrl"],
                _config["Endpoints:customersUrl"],
                _config["AppName"]
            );

            betsEndpoint = string.Format("{0}/{1}?name={2}",
                _config["Endpoints:baseUrl"],
                _config["Endpoints:betsUrl"],
                _config["AppName"]
            );
        }

        //2a
        [HttpGet]
        public async Task<JsonResult> GetAll()
        {
            try
            {
                var customers = await HttpHelper<Customer>.Get(customersEndpoint);

                return Json(customers);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        //2b
        [HttpGet]
        public async Task<JsonResult> GetTotalBets(int id)
        {
            try
            {
                var bets = await HttpHelper<Bet>.Get(betsEndpoint);

                var totalBets = bets.Where(b => b.CustomerID == id).ToList();

                return Json(totalBets.Count);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        //2c
        [HttpGet]
        public async Task<JsonResult> GetTotalBetAmount(int id)
        {
            try
            {
                var bets = await HttpHelper<Bet>.Get(betsEndpoint);

                var totalBets = bets.Where(b => b.CustomerID == id).ToList();

                double total = 0;
                foreach (var bet in totalBets)
                {
                    total += bet.Stake;
                }

                return Json(total);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        //2d
        [HttpGet]
        public async Task<JsonResult> GetTotalBetAmount()
        {
            try
            {
                var bets = await HttpHelper<Bet>.Get(betsEndpoint);

                double total = 0;
                foreach (var bet in bets)
                {
                    total += bet.Stake;
                }

                return Json(total);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        //2e
        [HttpGet]
        public async Task<JsonResult> GetRiskyCustomers()
        {
            try
            {
                var customers = await HttpHelper<Customer>.Get(customersEndpoint);
                var bets = await HttpHelper<Bet>.Get(betsEndpoint);

                var riskyCustomers = new List<Customer>();
                foreach(var customer in customers)
                {
                    // Could re-use code in GetTotalBetAmount if ported to a helper.
                    var totalBets = bets.Where(b => b.CustomerID == customer.ID).ToList();
                    double totalAmount = 0;
                    foreach(var bet in totalBets)
                    {
                        totalAmount += bet.Stake;
                    }
                    if(totalAmount > RISKY_THRESHOLD)
                    {
                        riskyCustomers.Add(customer);
                    }
                }

                return Json(riskyCustomers);
            }
            catch (Exception e)
            {
                return null;
            }
        }

    }
}
