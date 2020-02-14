using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedditBot
{
    public class BotInformation
    {
        public string RedditUser { get; private set; }
        public string RedditPassword { get; private set; }
        public string RedditAppId { get; private set; }
        public string RedditAppSecret { get; private set; }
        public string RedirectUri { get; private set; }
        public string SubReddit { get; private set; }
        public string AuthCode { get; private set; }
        string[] CfgLines;
        string CfgLocation = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\RedditBot.cfg";
        public BotInformation()
        {
            Refresh();
        }
        public bool Refresh(string fileLocation)
        {
            RedditUser = StringExtractor("User", fileLocation);
            RedditPassword = StringExtractor("Password", fileLocation);
            RedditAppId = StringExtractor("AppId", fileLocation);
            RedditAppSecret = StringExtractor("Secret", fileLocation);
            AuthCode = StringExtractor("Code", fileLocation);
            RedirectUri = StringExtractor("Uri", fileLocation);
            SubReddit = StringExtractor("SubReddit", fileLocation);

            if (RedditUser == "" || RedditPassword == "" || RedditAppId == "" || RedditAppSecret == "" || RedirectUri == "" || AuthCode == "" || SubReddit == "")
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
                    return line.Substring(line.IndexOf(":") + 1).Replace(" ", "");
                }
            }
            return "";
        }
    }
}
