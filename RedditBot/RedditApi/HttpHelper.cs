using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedditApi
{
    public class HttpHelper
    {
        public static string StringToBase64String(string orig) => Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(orig));
    }
}
