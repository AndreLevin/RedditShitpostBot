using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            CommentBuilder comm = new CommentBuilder();
            while (true)
            {
                Console.WriteLine(comm.GetComment());
                Console.ReadLine();
            }

        }
    }
}
