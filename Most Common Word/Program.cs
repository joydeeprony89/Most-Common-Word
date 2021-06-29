using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Most_Common_Word
{
    class Program
    {
        static void Main(string[] args)
        {
            string paragraph = "Bob hit a ball, the hit BALL flew far after it was hit.";
            //string paragraph = "a, a, a, a, b,b,b,c, c";
            var banned = new string[] { "hit" };
            Console.WriteLine(MostCommonWord(paragraph, banned));
        }

        static string MostCommonWord(string paragraph, string[] banned)
        {
            Dictionary<string, int> hash = new Dictionary<string, int>();
            string remove = Regex.Replace(paragraph, @"[\W_]$", "");
            string result = Regex.Replace(remove, @"[\W_]+", " ");
            result = result.ToLower();
            var arr = result.Split(' ');
            foreach (var item in arr)
            {
                if (hash.ContainsKey(item))
                {
                    hash[item] += 1;
                }
                else
                {
                    hash[item] = 1;
                }
            }

            return hash.Where(x=>!banned.Contains(x.Key))
                .ToDictionary(x=>x.Key,x=>x.Value)
                .OrderByDescending(x => x.Value)
                .ToDictionary(x=>x.Key,x=>x.Value)
                .FirstOrDefault().Key;

        }
    }
}
