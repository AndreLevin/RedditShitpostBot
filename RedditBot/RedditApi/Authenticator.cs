using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RedditApi
{
    public class Authenticator
    {
        public static async Task<string> GetAccessTokenAsync()
        {
            HttpClient client = new HttpClient();
            //client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", @"application/x-www-form-urlencoded; charset=utf-8");
            //client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", StringToBase64String("appid:appsecret"));

            HttpContent data = GetHttpContent();
            HttpResponseMessage response = await client.PostAsync(@"https://www.reddit.com/api/v1/access_token", data).ConfigureAwait(false);
            return GetAccesTokenFromResponseMessage(response);
        }

        private static StringContent GetHttpContent()
        {
            var data = new JObject();
            //data.Add("username", "");
            //data.Add("password", "");
            //data.Add("grant_type", "");

            data.Add("grant_type", "authorization_code");
            data.Add("code", "");
            data.Add("redirect_uri", @"");
            string jsonstring = JsonConvert.SerializeObject(data);
            var stringContent = new StringContent(jsonstring, Encoding.UTF8, "application/x-www-form-urlencoded");
            stringContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/x-www-form-urlencoded");
            return stringContent;
        }

        private static string GetAccesTokenFromResponseMessage(HttpResponseMessage message)
        {
            string rr = message.Content.ReadAsStringAsync().Result;
            return rr;
        }

        static string StringToBase64String(string orig)
        {
            return Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(orig));
        }
    }
}
