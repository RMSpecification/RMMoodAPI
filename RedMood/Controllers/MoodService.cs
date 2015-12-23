using Newtonsoft.Json;
using RedMood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace RedMood.Controllers
{
    public class MoodService
    {

        

        public async Task<List<Moods>> GetMoodsAsync()
        {
            string uri = "http://localhost:53154//api/moods";

            using (HttpClient httpClient = new HttpClient())
            {

                return JsonConvert.DeserializeObject<List<Moods>>(
                    await httpClient.GetStringAsync(uri)
                );
            }
        }

        public async Task<HttpResponseMessage> Increase(int id)
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:53154//api/Moods/" + id);
            StringContent content = new System.Net.Http.StringContent(id.ToString(), Encoding.UTF8, "application/json");

            return await httpClient.PutAsync("http://localhost:53154//api/Moods/" + id, content);
        }
    }
}