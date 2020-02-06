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
        private const string subname = "RedditBotTest621";

        static void Main(string[] args)
        {
            BotInformation info = new BotInformation();
            client = new RedditClient(info.RedditAppId, info.RedditAppSecret, info.RedditUser, info.RedditPassword);
            SubredditWatcher watcher = new SubredditWatcher(subname, client);
            watcher.UncommentedPostSubmittet += UncommentedPostSubmittet;
            watcher.Start();
            
            Console.Read();
        }

        private static async void UncommentedPostSubmittet(Thing post)
        {
            await client.CommentOnThing(post.Fullname, commenttext).ConfigureAwait(false);
        }
    }
}
