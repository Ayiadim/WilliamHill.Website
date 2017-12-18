using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WilliamHill.Service;

namespace WilliamHill.Web.Controllers
{
    public class HomeController : Controller
    {

        private readonly IConfiguration _config;
        private readonly IRaceService _raceService;

        public HomeController(IConfiguration config, IRaceService raceService)
        {
            _config = config;
            _raceService = raceService;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            try
            {
                var races = await _raceService.GetRaces();
                return View(races);
            }
            catch (Exception e)
            {
                return View("Error", e);
            }
        }
    }
}
