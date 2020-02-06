using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using RedditApi.Reddit;

namespace RedditApi
{
    internal class HttpHelper
    {
        internal static string StringToBase64String(string orig) => Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(orig));
        internal static async Task<T> HttpResponseToObject<T>(HttpResponseMessage response)
        {
            string jsonContent = await response.Content.ReadAsStringAsync();
            return  JsonConvert.DeserializeObject<T>(jsonContent, new JsonSerializerSettings() { NullValueHandling= NullValueHandling.Ignore});
        }
    }
}
