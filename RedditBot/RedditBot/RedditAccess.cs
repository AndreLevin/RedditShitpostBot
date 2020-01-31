using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RedditSharp;
using RedditSharp.Things;
using System.Net.Http;
using System.Net;

namespace RedditBot
{
    class RedditAccess
    {
        private Reddit reddit = new Reddit();
        private Subreddit sub = null;
        public void RedditLogIn()
        {
            try
            {
                Authenticate();
            }
            catch (Exception e)
            {
                Console.WriteLine(e + Environment.NewLine);
                System.Threading.Thread.Sleep(500);
                RedditLogIn();
            }
        }
        void Authenticate()
        {
            var WebAgent = new BotWebAgent(BotInformation.RedditUser, BotInformation.RedditPassword, BotInformation.RedditAppId, BotInformation.RedditAppSecret, "http://uwu24.de");
            bool authenticated = false;
            BotInformation.Refresh();
            reddit = new Reddit(WebAgent, false);
            //reddit = new Reddit(BotInformation.RedditUser, BotInformation.RedditPassword, true);
            reddit.InitOrUpdateUser();
            authenticated = reddit.User != null;
            sub = null;
            if (!authenticated)
            {
                BotInformation.GetSub();
                sub = reddit.GetSubreddit("");
            }
        }
        public void test()
        {
            var posts = sub.Posts.Take(100);
            List<Object> model = new List<Object>();
            foreach (var post in posts)
            {
                if (post.Upvotes>0)
                {
                    int i = 0;
                }
            }

        }
    }
    class TestModel
    {
        public int i = 0;
    }
}
