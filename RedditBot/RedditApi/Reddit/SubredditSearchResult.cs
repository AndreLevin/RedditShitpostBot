using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RedditApi.Reddit
{
    [JsonObject]
    public class SubredditSearchResult 
    {
        [JsonProperty("subreddits")]
        public Subreddit[] Subreddits { get; private set; }
    }
}
