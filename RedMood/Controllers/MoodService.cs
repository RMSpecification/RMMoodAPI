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
        HttpClient httpClient;
        Uri uri;

        public MoodService()
        {
            httpClient = new HttpClient();
            uri = new Uri("http://localhost:53154//api/Moods/");
        }

        public async Task<List<Mood>> GetMoodsAsync()
        {
            return JsonConvert.DeserializeObject<List<Mood>>(
                await httpClient.GetStringAsync(uri)
            );
        }

        public async Task<Mood> GetMoodAsync(int id)
        {
            return JsonConvert.DeserializeObject<Mood>(
                await httpClient.GetStringAsync(uri + id.ToString())
            );
        }

        public async Task<HttpResponseMessage> Increase(int id)
        {
            StringContent content = new System.Net.Http.StringContent(id.ToString(), Encoding.UTF8, "application/json");

            return await httpClient.PutAsync(uri + id.ToString(), content);
        }       
    }
}