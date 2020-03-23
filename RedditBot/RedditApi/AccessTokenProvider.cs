using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.IO;
using RedditApi.Reddit;

namespace RedditApi
{
    public class AccessTokenProvider
    {
        private static string RequestUri = @"https://www.reddit.com/api/v1/access_token";
        private static string RevokeUri = @"https://www.reddit.com/api/v1/revoke_token";
        private static string defaultFilePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\accesstoken.json";

        private HttpClient TokenProviderClient;
        private HttpClient ApiRequestClient;
        private string Username;
        private string Password;
        private AccessToken accessToken;

        internal AccessTokenProvider(HttpClient apiRequestClient, string username, string password)
        {
            TokenProviderClient = new HttpClient();
            TokenProviderClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(apiRequestClient.DefaultRequestHeaders.Authorization.Scheme, apiRequestClient.DefaultRequestHeaders.Authorization.Parameter); //kopie
            ApiRequestClient = apiRequestClient; //reference
            Username = username;
            Password = password;
        }

        public async Task RefreshClient()
        {
            AccessToken at = await GetValidAccessToken();
            ApiRequestClient.DefaultRequestHeaders.Clear();
            ApiRequestClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", $"{at.Token}");
            ApiRequestClient.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", @"windows:CockPosts:v1.0.0 (by /user/CockPostBot)");
        }

        private async Task<AccessToken> GetValidAccessToken()
        {
            if (IsTokenValid())
                return accessToken;


            accessToken = AccessToken.LoadFromFile(defaultFilePath);
            if (!IsTokenValid())
            {
                accessToken = await GetNewAccessTokenAsync();

                if (!IsTokenValid())
                    throw new Exception("Error retrieving valid access token");
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

            HttpResponseMessage tokenResponse = await TokenProviderClient.PostAsync(RequestUri, new FormUrlEncodedContent(form));
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
            await ApiRequestClient.PostAsync(RevokeUri, new FormUrlEncodedContent(form));
        }

        private bool IsTokenValid() => accessToken != null && accessToken.IsValid();
    }
}
