using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;

namespace RedditApi
{
    /*
    
    */
    public class RedditClient
    {
        HttpClient httpClient;
        Token accessToken;

        public RedditClient(string appId, string appSecret)
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", HttpHelper.StringToBase64String($"{appId}:{appSecret}"));
        }

        public void SubmitComment(Token token, string comment)
        {

        }
    }
}
