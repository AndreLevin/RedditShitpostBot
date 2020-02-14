using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RedditApi;
using RedditApi.Reddit;
using CommentBuilder;
using Logger;

namespace RedditBot
{
    class Program
    {
        private static RedditClient client;
        private static CommentBuilder.CommentBuilder cb = new CommentBuilder.CommentBuilder();
        static void Main(string[] args)
        {
            StartBot();
        }

        private static async void NewPost(Thing post)
        {
            if (post.Kind == Thing.ThingKind.Link)
            {
                var response = await client.CommentOnThing(post.Data.Name, cb.GetComment());
                var PostResponse = await HttpHelper.HttpResponseToObject<PostResponse>(response);
                if (PostResponse.Success)
                {
                    Console.WriteLine("Successfully posted comment on " + DateTime.Now.ToString());
                }
                else 
                {
                    Console.WriteLine("Post comment failed (" + DateTime.Now.ToString() + ")");
                }
            }
            
        }
        private static void StartBot()
        {
            try 
            {
                BotInformation info = new BotInformation();
                client = new RedditClient(info.RedditAppId, info.RedditAppSecret, info.RedditUser, info.RedditPassword);
                SubredditWatcher watcher = new SubredditWatcher(info.SubReddit, client);
                watcher.NewUncommentedPostSubmittet += NewPost;
                watcher.Start();
                
                Console.Read();
            }
            catch (Exception e)
            {
                System.Threading.Thread.Sleep(2000);
                Logger.Logger.CreateLogEntry(e);
                StartBot();
            }
        }
    }
}
