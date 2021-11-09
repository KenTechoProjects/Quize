using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Application.Helper
{
    public class HttpClientHelper
    {

        public async Task<T> GetAsync<T>(string path, AuthenticationHeaderValue auth = default,
            Dictionary<string, string> headers = default)
        {
            var client = new HttpClient();
            if (auth != null)
                client.DefaultRequestHeaders.Authorization = auth;
            if (headers != null)
            {
                foreach (var h in headers)
                {
                    client.DefaultRequestHeaders.Add(h.Key, h.Value);
                }
            }
            
            var response = await client.GetAsync(path);
            //Log Request/Response
            Log.Information($"[Inf] {JsonConvert.SerializeObject(response)}");
            if (!response.IsSuccessStatusCode)
                throw new Exception("The request was not successful...");
            string result = response.Content.ReadAsStringAsync().Result;
            T returnValue = JsonConvert.DeserializeObject<T>(result);
            return returnValue;
        }


        public async Task<T> PostAsync<T, M>(M detail, string path, AuthenticationHeaderValue auth = default,
             Dictionary<string, string> headers = default)
        {
            var client = new HttpClient();
            var jsonContent = JsonConvert.SerializeObject(detail);
            var data = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            if (headers != null)
            {
                foreach (var h in headers)
                {
                    client.DefaultRequestHeaders.Add(h.Key, h.Value);
                }
            }

            if (auth != null)
                client.DefaultRequestHeaders.Authorization = auth;


            var response = await client.PostAsync(path, data);
            //Log Request/Response
            Log.Information($"[Inf] {JsonConvert.SerializeObject(response)}");
            string result = response.Content.ReadAsStringAsync().Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(result);
            }
            else
            {
                T returnValue = JsonConvert.DeserializeObject<T>(result);
                return returnValue;
            }
        }
        public async Task<T> PostAsync<T>(Dictionary<string, string> body, string path, AuthenticationHeaderValue auth = default,
               Dictionary<string, string> headers = default)
        {
            var client = new HttpClient();

            var data = new FormUrlEncodedContent(body);

            if (headers != null)
            {
                foreach (var h in headers)
                {
                    client.DefaultRequestHeaders.Add(h.Key, h.Value);
                }
            }

            if (auth != null)
                client.DefaultRequestHeaders.Authorization = auth;

            var response = await client.PostAsync(path, data);
            //Log Request/Response
            Log.Information($"[Inf] {JsonConvert.SerializeObject(response)}");
            string result = response.Content.ReadAsStringAsync().Result;

            T returnValue = JsonConvert.DeserializeObject<T>(result);
            return returnValue;
        }
    }
}
