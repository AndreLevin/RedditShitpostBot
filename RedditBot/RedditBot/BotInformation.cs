using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedditBot
{
    static class BotInformation
    {
        public static string RedditUser { get; private set;}
        public static string RedditPassword { get; private set; }
        public static string RedditAppId { get; private set; }
        public static string RedditAppSecret { get; private set; }
        static string RedditSub;
        static string[] CfgLines;
        static string CfgLocation = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\RedditBot.cfg";
        public static bool Refresh(string fileLocation)
        {
            RedditUser = StringExtractor("User", fileLocation);
            RedditPassword = StringExtractor("Password", fileLocation);
            RedditAppId = StringExtractor("AppId", fileLocation);
            RedditAppSecret = StringExtractor("Secret", fileLocation);

            if (RedditUser == "" || RedditPassword == "" || RedditAppId == "" || RedditAppSecret == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static string GetSub()
        {
            RedditSub = StringExtractor("Sub", CfgLocation);
            return RedditSub;
        }
        public static bool Refresh()
        {
            return Refresh(CfgLocation);
        }
        private static string StringExtractor(string id, string fileLocation)
        {
            if (CfgLines == null || CfgLines.Length == 0)
            {
                CfgLines = File.ReadAllLines(fileLocation);
            }
            foreach (string line in CfgLines)
            {
                if (line.Contains(id + ":"))
                {
                    return line.Substring(line.IndexOf(":") + 1).Replace(" ", "");
                }
            }
            return "";
        }
    }
}
