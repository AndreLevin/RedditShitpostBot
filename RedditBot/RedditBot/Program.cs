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
            BotInformation info = new BotInformation();
            var client = new RedditClient(info.RedditAppId, info.RedditAppSecret, info.RedditUser, info.RedditPassword);
             client.SubmitComment("nice cock").Wait();

            
        }
    }
}
