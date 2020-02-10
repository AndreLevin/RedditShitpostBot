using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using RedditApi.Reddit;
using Newtonsoft.Json;

namespace RedditApi
{
    public class RedditClient
    {
        private HttpClient httpClient;
        private AccessTokenProvider tokenProvider;
        private static string oauthUri = @"https://oauth.reddit.com";
        public User Me { get; private set; }

        public RedditClient(string appId, string appSecret, string username, string password)
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", HttpHelper.StringToBase64String($"{appId}:{appSecret}"));
            tokenProvider = new AccessTokenProvider(httpClient, username, password);
            Me = GetMe().Result;
        }

        public async Task Close()
        {
            //await tokenProvider.RevokeToken();
        }

        private async Task<User> GetMe()
        {
            await tokenProvider.RefreshClient();
            var response = await httpClient.GetAsync($@"{oauthUri}/api/v1/me");
            return await HttpHelper.HttpResponseToObject<User>(response);
        }

        public async Task<Listing> GetNew(string subredditName, int count)
        {
            await tokenProvider.RefreshClient();
            var response = await httpClient.GetAsync($@"{oauthUri}/r/{subredditName}/new?limit={count}");
            return await HttpHelper.HttpResponseToObject<Listing>(response);
        }

        public async Task<HttpResponseMessage> CommentOnThing(string fullname, string text)
        {
            await tokenProvider.RefreshClient();
            var form = new Dictionary<string, string>
            {
                {"text", text },
                {"thing_id", fullname }
            };

            return await httpClient.PostAsync($@"{oauthUri}/api/comment", new FormUrlEncodedContent(form));
        }

        public async Task<Listing[]> GetListing(string endpointUrl)
        {
            var response = await httpClient.GetAsync($@"{oauthUri}{endpointUrl}");
            return await HttpHelper.HttpResponseToObject<Listing[]>(response);
        }
    }
}
