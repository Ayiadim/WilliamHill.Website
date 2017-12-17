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
    public class HomeController : Controller
    {

        private readonly IConfiguration _config;
        private string racesEndpoint;
        private string betsEndpoint;

        public HomeController(IConfiguration config)
        {
            this._config = config;

            racesEndpoint = string.Format("{0}/{1}?name={2}",
                _config["Endpoints:baseUrl"],
                _config["Endpoints:racesUrl"],
                _config["AppName"]
            );

            betsEndpoint = string.Format("{0}/{1}?name={2}",
                _config["Endpoints:baseUrl"],
                _config["Endpoints:betsUrl"],
                _config["AppName"]
            );
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            try
            {
                var races = await HttpHelper<Race>.Get(racesEndpoint);
                var bets = await HttpHelper<Bet>.Get(betsEndpoint);

                foreach (var race in races)
                {
                    race.TotalMoneyPlaced = race.GetTotalMoneyPlaced(bets);
                    foreach (var horse in race.Horses)
                    {
                        horse.TotalBets = horse.GetTotalBets(bets);
                        horse.Payout = horse.GetPayout(bets);
                    }
                }

                return View(races);
            }
            catch (Exception e)
            {
                return View("Error", e);
            }
        }
    }
}
