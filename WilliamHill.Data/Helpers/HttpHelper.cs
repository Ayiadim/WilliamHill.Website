using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WilliamHill.Data.Models;

namespace WilliamHill.Data.Helpers
{
    public interface IHttpHelper
    {
        Task<IEnumerable<T>> Get<T>(string endpoint);
    }

    public class HttpHelper : IHttpHelper
    {
        public async Task<IEnumerable<T>> Get<T>(string endpoint)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync(endpoint);
                    response.EnsureSuccessStatusCode();
                    var content = await response.Content.ReadAsStringAsync();
                    var model = JsonConvert.DeserializeObject<List<T>>(content);

                    return model;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
