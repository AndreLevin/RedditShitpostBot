using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace RedditApi
{
    public class TokenAccessor
    {
        private static string RequestUri = @"https://www.reddit.com/api/v1/access_token";
        private HttpClient httpClient;
        private string Username;
        private string Password;

        internal TokenAccessor(HttpClient client, string username, string password)
        {
            httpClient = client;
            Username = username;
            Password = password;
        }

        public async Task<AccessToken> GetNewAccessTokenAsync()
        {
            var form = new Dictionary<string, string>
                {
                    {"grant_type", "password"},
                    {"username", Username},
                    {"password", Password},
                };

            HttpResponseMessage tokenResponse = await httpClient.PostAsync(RequestUri, new FormUrlEncodedContent(form));
            string jsonContent = await tokenResponse.Content.ReadAsStringAsync();
            AccessToken tok = JsonConvert.DeserializeObject<AccessToken>(jsonContent);
            return tok;
        }


        
    }
}
