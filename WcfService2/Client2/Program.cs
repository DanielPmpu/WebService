using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client2
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();
            string str;
            string stringfileName = Console.ReadLine();
            StringBuilder line = new StringBuilder();
            StreamReader sr = new StreamReader(stringfileName, System.Text.Encoding.Default);
            while ((str = sr.ReadLine()) != null)
            {
                line.Append(str);
                using (var tryclient = new ServiceReference1.Service1Client())
                {
                    tryclient.Open();
                    result = tryclient.webParser(line);
                    string stringfileName1 = Console.ReadLine();
                    StreamWriter sw = new StreamWriter(stringfileName1);
                    foreach (KeyValuePair<string, int> Value in result)
                    {
                        sw.WriteLine(Value.Key + " " + Value.Value);
                    }

                    tryclient.Close();
                    Console.ReadLine();
                }
            }
        }
    }
}

