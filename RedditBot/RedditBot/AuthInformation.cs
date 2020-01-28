using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedditBot
{
    class AuthInformation
    {
        public static string RedditUser { get; private set;}
        public static string RedditPassword { get; private set; }
        public static string RedditAppId { get; private set; }
        public static string RedditAppSecret { get; private set; }
        static string[] CfgLines;
        static string CfgLocation = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\RedditBot.cfg";
        public bool Refresh(string fileLocation)
        {
            RedditUser = StringExtractor("User", fileLocation);
            RedditPassword = StringExtractor("Password", fileLocation);
            RedditAppId = StringExtractor("AppId", fileLocation);
            RedditAppSecret = StringExtractor("Secret", fileLocation);

            if (RedditAppId == "" || RedditPassword == "" || RedditAppId == "" || RedditAppSecret == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool Refresh()
        {
            return Refresh(CfgLocation);
        }
        private string StringExtractor(string id, string fileLocation)
        {
            if (CfgLines == null || CfgLines.Length == 0)
            {
                CfgLines = File.ReadAllLines(fileLocation);
            }
            foreach (string line in CfgLines)
            {
                if (line.Contains(id + ":"))
                {
                    return line.Substring(line.IndexOf(":")).Replace(" ", "");
                }
            }
            return "";
        }
    }
}
