using Newtonsoft.Json;
using Patricte_NewsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patricte_NewsApp.Services
{
    public class ApiServices
    {
        public async Task<Root> GetNews(string categoryName)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync
                ($"https://gnews.io/api/v4/top-headlines?{categoryName.ToLower()}&apikey=16871115f22abba0b1bd0db43dc58fd0&lang=en");
            return JsonConvert.DeserializeObject<Root>(response);
        }
    }
}
