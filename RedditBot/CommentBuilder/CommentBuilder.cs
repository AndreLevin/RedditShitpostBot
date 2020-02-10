using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CommentBuilder
{
    public class CommentBuilder
    {
        string folder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\RedditBot\";
        List<string> adjectives;
        List<string> pp;
        List<string> bro;
        List<string> end;
        Random rand;

        public CommentBuilder()
        {
            UpdateList("nice");
            UpdateList("pp");
            UpdateList("bro");
            UpdateList("end");
            rand = new Random();
        }
        void UpdateList(string identifier)
        {
            switch (identifier.ToUpper())
            {
                case "NICE":
                case "ADJECTIVES":
                    adjectives = File.ReadAllLines(folder + "adjectives.pp").ToList();
                    break;
                case "PP":
                    pp = File.ReadAllLines(folder + "pp.pp").ToList();
                    break;
                case "BRO":
                    bro = File.ReadAllLines(folder + "bro.pp").ToList();
                    break;
                case "END":
                    end = File.ReadAllLines(folder + "end.pp").ToList();
                    break;
                default:
                    Console.WriteLine("Unknown List?????");
                    break;
            }
        }
        public string GetComment()
        {
            string ret = adjectives[rand.Next(adjectives.Count)];
            ret += " ";
            ret += pp[rand.Next(pp.Count)];
            if (!(rand.Next(10)<4))
            {
                ret += rand.Next(10) < 4 ? ", " : " ";
                ret += bro[rand.Next(bro.Count)];
            }
            ret += rand.Next(10) < 3 ? (Environment.NewLine + "not gonna lie") : end[rand.Next(end.Count)];
            return ret;
        }
    }
}
