using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RedditApi.Reddit;
using System.Threading;
using Newtonsoft.Json;

namespace RedditApi
{
    public class SubredditWatcher
    {
        public delegate void NewPostDelegate(Thing post);
        public event NewPostDelegate UncommentedPostSubmittet;

        private bool isActive;
        private RedditClient Client;
        private string subname;
        private int _CheckInterval;
        /// <summary>
        /// interval of the watcher checking for new posts in seconds. everything under 5 will be set to 5.
        /// </summary>
        public int CheckInterval
        {
            get => _CheckInterval;
            set
            {
                _CheckInterval = Math.Min(5, value);
                checkTimeSpan = new TimeSpan(0, 0, value);
            }
        }
        
        private TimeSpan checkTimeSpan;

        public SubredditWatcher(string subredditName, RedditClient watcherClient)
        {
            CheckInterval = 30;
            Client = watcherClient;
            isActive = false;
            subname = subredditName;
        }

        private async void Check()
        {
            while (isActive)
            {
                var newPosts = await Client.GetSubbredditNew(subname);
                foreach (Thing post in newPosts.Data.Children)
                {
                    if (await IsPostUncommented(post))
                        UncommentedPostSubmittet.Invoke(post);
                }
                Thread.Sleep(checkTimeSpan);
            }
        }

        public void Start()
        {
            isActive = true;
            Check();
        }

        public void Stop()
        {
            isActive = false;
        }

        private async Task<bool> IsPostUncommented(Thing Post)
        {
            var thingsListings = await Client.GetEndpoint<Listing[]>(Post.Data.Permalink + "?limit=20");
            var comments = thingsListings.SelectMany(listing=>listing.GetChildrenOfKind(Thing.ThingKind.Comment)).ToArray();
            var me = await Client.GetMe();
            string myname = me.Name;
            return !comments.Any(comment => comment.Data.Author == myname);
        }
    }
}
