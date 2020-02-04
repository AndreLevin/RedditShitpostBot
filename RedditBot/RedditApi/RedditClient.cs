using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using RedditApi.Reddit;

namespace RedditApi
{
    public class RedditClient
    {
        private HttpClient httpClient;
        private AccessTokenProvider tokenProvider;

        public RedditClient(string appId, string appSecret, string username, string password)
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", HttpHelper.StringToBase64String($"{appId}:{appSecret}"));
            tokenProvider = new AccessTokenProvider(httpClient, username, password);
        }

        public async Task SubmitComment(string comment)
        {
            Subreddit sub = await GetSubredditByName("RedditBotTest621");
        }

        public async Task Close()
        {
            await tokenProvider.RevokeToken();
        }

        public async Task<Subreddit> GetSubredditByName(string name)
        {
            await tokenProvider.Refresh();
            var form = new Dictionary<string, string>
            {
                {"exact", "true" },
                {"include_over_18", "true" },
                {"include_unadvertisable","true" },
                { "query",name }
            };

            HttpResponseMessage tokenResponse = httpClient.PostAsync(@"https://oauth.reddit.com/api/search_subreddits", new FormUrlEncodedContent(form)).Result;
            string jsonContent = tokenResponse.Content.ReadAsStringAsync().Result;
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Subreddit>(jsonContent);
        }
    }
}
