using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Reader
    {

        private ConcurrentDictionary<string, int> reader3(string[] line)
        {

            ConcurrentDictionary<string, int> myDict = new ConcurrentDictionary<string, int>();
            char[] ch = { '.', '"', ',', '!', '?', ':', ';', '-', '(', ')' }; 
            foreach (string stringLine in line)
            {
                if (stringLine != "")
                {
                    string[] str = stringLine.Split(new char[] { ' ' }); 
                    foreach (string word in str)
                    {
                        string s = word;
                        s = s.Trim(ch);
                        if (!myDict.ContainsKey(s)) 
                        {
                            myDict.TryAdd(s, 1);
                        }
                        else
                        {
                            myDict[s]++; 
                        }
                    }
                }
            }

            return myDict;
        }


        public Dictionary<string, int> reader3(StringBuilder sb)
        {
            var wordsArray = sb.ToString().
                 Split(' ', ',', '.', '-', '!', '?', ':', ';', '"', '[', ']', '(', ')');
            ConcurrentDictionary<string, int> conWordsArray = new ConcurrentDictionary<string, int>();
            Dictionary<string, int> sorted = null;

            Parallel.ForEach(wordsArray, item =>
            {
                conWordsArray.AddOrUpdate(item, 1, (key, oldval) => oldval + 1);
            }
            );
            sorted = conWordsArray.OrderByDescending(w => w.Value).ToDictionary(w => w.Key, w => w.Value);
            return sorted;

        }
    }
}
