using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WilliamHill.Data.Models;

namespace WilliamHill.Web.Helpers
{
    public static class HttpHelper<T>
    {
        public static async Task<IEnumerable<T>> Get(string endpoint)
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
