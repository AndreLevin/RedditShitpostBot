﻿using System;
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
        public event NewPostDelegate NewUncommentedPostSubmittet;

        private bool isActive;
        private RedditClient Client;
        private string subname;
        private int _CheckInterval;
        private TimeSpan checkTimeSpan;

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

        public SubredditWatcher(string subredditName, RedditClient watcherClient)
        {
            CheckInterval = 15;
            Client = watcherClient;
            isActive = false;
            subname = subredditName;
        }

        private async void Check()
        {
            while (isActive)
            {
                var newPosts = await Client.GetSubredditNew(subname, 4);
                foreach(Thing post in newPosts.Data.Children)
                {
                    if (post.Data.Over18 && await IsPostUncommented(post))
                        NewUncommentedPostSubmittet.Invoke(post);
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
            var commentListings = await Client.GetListing(Post.Data.Permalink);
            var allComments = commentListings.SelectMany(commentlisting => commentlisting.Data.Children);
            return !allComments.Any(comment => comment.Data.Author == Client.Me.Name);
        }
    }
}
