 using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using WilliamHill.Data.Helpers;
using WilliamHill.Data.Models;

namespace WilliamHill.Data
{
    public class BetRepository : IRepository<Bet>
    {
        private readonly IHttpHelper _httpHelper;
        private readonly IConfiguration _config;
        private string _endpoint;

        public BetRepository(IHttpHelper httpHelper, IConfiguration config)
        {
            _httpHelper = httpHelper;
            _config = config;

            _endpoint = string.Format("{0}/{1}?name={2}",
                _config["Endpoints:baseUrl"],
                _config["Endpoints:betsUrl"],
                _config["AppName"]
            );
        }

        public async Task<IEnumerable<Bet>> GetAll()
        {
            return await _httpHelper.Get<Bet>(_endpoint);
        }
    }
}
