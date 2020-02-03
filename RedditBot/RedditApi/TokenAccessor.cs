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
    public class TokenAccessor
    {
        private static string RequestUri = @"https://www.reddit.com/api/v1/access_token";
        private HttpClient httpClient;

        public TokenAccessor(HttpClient client)
        {
            httpClient = client;
        }

        public async Task<Token> GetAccessTokenAsync(string code, string redirectUri)
        {
            var form = new Dictionary<string, string>
                {
                    {"grant_type", "authorization_code"},
                    {"code", code},
                    {"redirect_uri", redirectUri},
                };

            HttpResponseMessage tokenResponse = await httpClient.PostAsync(RequestUri, new FormUrlEncodedContent(form));
            var jsonContent = await tokenResponse.Content.ReadAsStringAsync();
            Token tok = JsonConvert.DeserializeObject<Token>(jsonContent);
            return tok;
        }

        
    }
}
