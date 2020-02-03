using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;

namespace RedditApi
{
    public class RedditClient
    {
        private HttpClient httpClient;
        private TokenAccessor TokenAccessor;
        private AccessToken accessToken;

        public RedditClient(string appId, string appSecret, string username, string password)
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", HttpHelper.StringToBase64String($"{appId}:{appSecret}"));
            TokenAccessor = new TokenAccessor(httpClient, username, password);
        }

        public async Task SubmitComment(string comment)
        {
            await RefreshToken();

        }

        private async Task RefreshToken()
        {
            if (accessToken == null || DateTime.Now >= accessToken.ExpirationDateTime)
                accessToken = await TokenAccessor.GetNewAccessTokenAsync();

        }
    }
}
