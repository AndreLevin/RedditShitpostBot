using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedditBot
{
    class Program
    {
        static void Main(string[] args)
        {
            AuthInformation.Refresh();
            string test = AuthInformation.RedditAppId;
            Console.ReadLine();
        }
    }
}
