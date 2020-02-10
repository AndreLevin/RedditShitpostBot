using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RedditApi;
using RedditApi.Reddit;

namespace RedditBot
{
    class Program
    {
        private static RedditClient client;
        private static string commenttext = "nice cock bro";
        static void Main(string[] args)
        {
            string subname = "RedditBotTest621";
            string sn2 = "redditdev";
            
            BotInformation info = new BotInformation();
            client = new RedditClient(info.RedditAppId, info.RedditAppSecret, info.RedditUser, info.RedditPassword);
            SubredditWatcher watcher = new SubredditWatcher("RedditBotTest621", client);
            watcher.NewUncommentedPostSubmittet += NewPost;
            watcher.Start();
            
            Console.Read();
        }

        private static async void NewPost(Thing post)
        {
            await client.CommentOnThing(post.Data.Name, commenttext);
        }
    }
}
