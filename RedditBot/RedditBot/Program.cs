using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedditBot
{
    class Program
    {
        public static string AuthInfoLocation;
        static void Main(string[] args)
        {
            AuthInfoLocation = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\RedditBot.cfg";
            Console.ReadLine();
        }
    }
}
