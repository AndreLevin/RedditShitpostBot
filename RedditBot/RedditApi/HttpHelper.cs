using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace RedditApi
{
    public class HttpHelper
    {
        public static string StringToBase64String(string orig) => Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(orig));
        public static async Task<T> HttpResponseToObject<T>(HttpResponseMessage response)
        {
            string jsonContent = await response.Content.ReadAsStringAsync();
            return  JsonConvert.DeserializeObject<T>(jsonContent);
        }
    }
}
