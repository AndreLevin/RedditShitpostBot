using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Logger
{
    public static class Logger
    {
        static string Location = Directory.GetCurrentDirectory() + "\\RedditBot Exceptions.log";
        public static void CreateLogEntry(Exception e)
        {
            using (StreamWriter file = new StreamWriter(Location))
            {
                file.WriteLine(Environment.NewLine + "Exception thrown at " + DateTime.Now.ToString());
                file.WriteLine(e.Message);
            }
        }
    }
}
