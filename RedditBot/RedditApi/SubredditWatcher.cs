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
        public event NewPostDelegate NewPost;

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
                _CheckInterval = Math.Min(5, _CheckInterval);
                checkTimeSpan = new TimeSpan(0, 0, _CheckInterval);
            }
        }
        
        private TimeSpan checkTimeSpan;

        public SubredditWatcher(string subredditName, RedditClient watcherClient)
        {
            _CheckInterval = 30;
            Client = watcherClient;
            isActive = false;
            subname = subredditName;
        }

        private async void Check()
        {
            while (isActive)
            {
                var newPosts = await Client.GetSubbredditNew(subname);
                if (IsPostNew(newPosts.Data.Children[0]))
                    NewPost.Invoke(newPosts.Data.Children[1]);
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

        private bool IsPostNew(Thing Post)
        {
            return true;
        }
    }
}
