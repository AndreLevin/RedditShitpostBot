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
            var WebAgent = new BotWebAgent("", "", "", "", "http://uwu24.de");
            bool authenticated = false;
            //BotInformation.Refresh();
            reddit = new Reddit(WebAgent, false);
            //reddit = new Reddit(BotInformation.RedditUser, BotInformation.RedditPassword, true);
            reddit.InitOrUpdateUser();
            authenticated = reddit.User != null;
            sub = null;
            if (!authenticated)
            {
               // BotInformation.GetSub();
                sub = reddit.GetSubreddit("");
            }
        }
    }
}
