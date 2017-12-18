using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WilliamHill.Service;

namespace WilliamHill.Web.Controllers
{
    public class CustomersController : Controller
    {

        private readonly IConfiguration _config;
        private readonly ICustomerService _customerService;

        public CustomersController(IConfiguration config, ICustomerService customerService)
        {
            _config = config;
            _customerService = customerService;
        }

        //2a
        [HttpGet]
        public JsonResult GetAll()
        {
            try
            {
                var result = _customerService.GetAllCustomers();
                return Json(result);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        //2b
        [HttpGet]
        public JsonResult GetTotalBets(int id)
        {
            try
            {
                var result = _customerService.GetTotalBets(id);
                return Json(result);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        //2c
        [HttpGet]
        public JsonResult GetTotalBetAmount(int id)
        {
            try
            {
                var result = _customerService.GetTotalBetAmount(id);
                return Json(result);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        //2d
        [HttpGet]
        public JsonResult GetTotalBetAmount()
        {
            try
            {
                var result = _customerService.GetTotalBetAmount();
                return Json(result);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        //2e
        [HttpGet]
        public JsonResult GetRiskyCustomers()
        {
            try
            {
                var result = _customerService.GetRiskyCustomers();
                return Json(result);
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
