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
                    adjectives = GetList(folder + "adjectives.pp");
                    break;
                case "PP":
                    pp = GetList(folder + "pp.pp");
                    break;
                case "BRO":
                    bro = GetList(folder + "bro.pp");
                    break;
                case "END":
                    end = GetList(folder + "end.pp");
                    break;
                default:
                    Console.WriteLine("Unknown List?????");
                    break;
            }
        }
        List <string> GetList(string file)
        {
            List<string> ret = new List<string>();
            string[] linesFromFile = File.ReadAllLines(file);
            foreach (string line in linesFromFile)
            {
                if (line.Contains(":"))
                {
                    if ((line.Length > (line.IndexOf(":") + 1)) && ContainsNumber(line.Substring(line.IndexOf(":") + 1)))
                    {
                        int multiplier = 1;

                        try 
                        {
                            multiplier = Convert.ToInt32(line.Substring(line.IndexOf(":") + 1).Trim());
                        }
                        catch
                        {
                            multiplier = 1;
                        }

                        for (int i = 0; i<multiplier; i++)
                        {
                            ret.Add(line.Substring(0, line.IndexOf(":")));
                        }
                    }
                    else
                    {
                        ret.Add(line.Substring(0, line.IndexOf(":")));
                    }
                }
                else
                {
                    ret.Add(line);
                }
            }
            return ret;
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
        bool ContainsNumber(string str)
        {
            if (str.Contains("2") || str.Contains("3") || str.Contains("4") || str.Contains("5") || str.Contains("6") || str.Contains("7") || str.Contains("8") || str.Contains("9") || str.Contains("10") || str.Contains("11"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
