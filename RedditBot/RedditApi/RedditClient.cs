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

        public RedditClient(string appId, string appSecret, string username, string password)
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", HttpHelper.StringToBase64String($"{appId}:{appSecret}"));
            tokenProvider = new AccessTokenProvider(httpClient, username, password);
        }

        public async Task Close()
        {
            await tokenProvider.RevokeToken();
        }

        public async Task<User> GetMe()
        {
            await tokenProvider.RefreshClient();
            var response = await httpClient.GetAsync($@"{oauthUri}/api/v1/me");
            User u = await HttpHelper.HttpResponseToObject<User>(response);
            return u;
        }

        public async Task<SubredditSearchResult> GetSubredditSearchResult(string name)
        {
            await tokenProvider.RefreshClient();
            var form = new Dictionary<string, string>
            {
                {"exact", "true" },
                {"include_over_18", "true" },
                {"include_unadvertisable","true" },
                { "query",name }
            };

            HttpResponseMessage response = await httpClient.PostAsync($@"{oauthUri}/api/search_subreddits", new FormUrlEncodedContent(form));
            var res = await HttpHelper.HttpResponseToObject<SubredditSearchResult>(response);
            return res;
        }

        public async Task GetSubbredditNew(string subname)
        {
            await tokenProvider.RefreshClient();
            string url = $@"https://www.reddit.com/r/{subname}/new.json";
            var response = await httpClient.GetAsync(url);
            string jsonContent = await response.Content.ReadAsStringAsync();
        }

        public async Task SubmitText(string subname)
        {
            await tokenProvider.RefreshClient();
            var form = new Dictionary<string, string>
            {
                {"sr", subname },
                {"title", "subtest" },
                {"text","hallotest1234" },
               
            };
            HttpResponseMessage response = await httpClient.PostAsync($@"{oauthUri}/api/submit", new FormUrlEncodedContent(form));
            string i = await response.Content.ReadAsStringAsync();
            //var res = await HttpHelper.HttpResponseToObject<SubredditSearchResult>(response);
        }
    }
}
