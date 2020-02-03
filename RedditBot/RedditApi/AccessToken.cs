using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RedditApi
{
    public class AccessToken
    {

        [JsonProperty("access_token")]
        public string Token { get; private set; }

        [JsonProperty("token_type")]
        public string TokenType { get; private set; }

        private int _ExpiresIn;
        [JsonProperty("expires_in")]
        private int ExpiresIn
        {
            get => _ExpiresIn;
            set
            {
                _ExpiresIn = value;
                ExpirationDateTime = DateTime.Now.AddSeconds(_ExpiresIn);
            }
        }

        [JsonProperty("refresh_token")]
        public string RefreshToken { get; private set; }

        [JsonProperty("ExpirationDateTime")]
        public DateTime ExpirationDateTime { get; private set; }
    }
}

