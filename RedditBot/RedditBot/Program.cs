using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RedditApi;

namespace RedditBot
{
    class Program
    {
        static  void Main(string[] args)
        {
            string subname = "RedditBotTest621";
            string sn2 = "redditdev";
            BotInformation info = new BotInformation();
            var client = new RedditClient(info.RedditAppId, info.RedditAppSecret, info.RedditUser, info.RedditPassword);

            //client.GetMe().Wait();
            client.GetSubbredditNew("RedditBotTest621").Wait();
            //client.SubmitText(subname).Wait();
        }
    }
}
