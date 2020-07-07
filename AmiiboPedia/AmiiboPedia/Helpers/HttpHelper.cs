using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AmiiboPedia.Helpers
{
    public class HttpHelper<T>
    {
        public async Task<T> GetRestServiceDataAsync(string ServiceAddress)
        {
            var client = new HttpClient();
            //client.BaseAddress = new Uri(ServiceAddress);
            //client.GetAsync(client.BaseAddress);
            var response = await client.GetAsync(ServiceAddress);
            response.EnsureSuccessStatusCode();

            var jsonResult = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<T>(jsonResult);

            return result;
        }

    }
}
