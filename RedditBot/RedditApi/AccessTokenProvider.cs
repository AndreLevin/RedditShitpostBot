using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.IO;

namespace RedditApi
{
    public class AccessTokenProvider
    {
        private static string RequestUri = @"https://www.reddit.com/api/v1/access_token";
        private static string RevokeUri = @"https://www.reddit.com/api/v1/revoke_token";
        private static string defaultFilePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\accesstoken.json";

        private HttpClient httpClient;
        private string Username;
        private string Password;
        private AccessToken accessToken;

        internal AccessTokenProvider(HttpClient client, string username, string password)
        {
            httpClient = client;
            Username = username;
            Password = password;
        }

        public async Task RefreshClient()
        {
            AccessToken at = await GetValidAccessToken();
            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", $"{at.Token}");
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", @"windows:CockPosts:v1.0.0 (by /user/CockPostBot)");
        }

        private async Task<AccessToken> GetValidAccessToken()
        {
            if (IsTokenValid())
                return accessToken;

            try
            {
                accessToken = AccessToken.LoadFromFile(defaultFilePath);
                if(!accessToken.IsValid())
                    throw new Exception();
            } catch
            {
                accessToken = await GetNewAccessTokenAsync();

                if (!accessToken.IsValid())
                    throw new Exception("Error retrieving the access token.");
                else
                    accessToken.Save(defaultFilePath);
            }
            
            return accessToken;
        }

        private async Task<AccessToken> GetNewAccessTokenAsync()
        {
            var form = new Dictionary<string, string>
                {
                    {"grant_type", "password"},
                    {"username", Username},
                    {"password", Password},
                    {"scope", "*"}
                };

            HttpResponseMessage tokenResponse = await httpClient.PostAsync(RequestUri, new FormUrlEncodedContent(form));
            var tok = await HttpHelper.HttpResponseToObject<AccessToken>(tokenResponse);
            return tok;
        }

        public async Task RevokeToken()
        {
            var form = new Dictionary<string, string>
                {
                    {"token", accessToken.Token},
                    {"token_type_hint", "access_token"}
                };
            await httpClient.PostAsync(RevokeUri, new FormUrlEncodedContent(form));
        }

        private bool IsTokenValid() => accessToken != null && accessToken.IsValid();
    }
}
