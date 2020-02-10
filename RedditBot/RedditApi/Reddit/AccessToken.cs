using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace RedditApi.Reddit
{
    [JsonObject]
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

        [JsonProperty("scope")]
        public string Scope { get; private set; }

        [JsonProperty("ExpirationDateTime")]
        public DateTime ExpirationDateTime { get; private set; }

        public bool IsValid()
        {
            return DateTime.Now < ExpirationDateTime && !string.IsNullOrEmpty(Token);
        }

        public void Save(string filename)
        {
            using (StreamWriter file = File.CreateText(filename))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, this);
            }
        }

        public static AccessToken LoadFromFile(string filename)
        {
            using (StreamReader file = File.OpenText(filename))
            {
                JsonSerializer serializer = new JsonSerializer();
                return (AccessToken)serializer.Deserialize(file, typeof(AccessToken));
            }
        }

    }
}

