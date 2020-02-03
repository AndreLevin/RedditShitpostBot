using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedditApi
{
    /*
    
    */
    public class RedditClient
    {
        public RedditClient()
        {
            string at = Authenticator.GetAccessTokenAsync().Result;
        }


        public void SubmitComment(string comment)
        {

        }
    }
}
