using System;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem819 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public string MostCommonWord(string paragraph, string[] banned)
        {
            var wordArray = paragraph.Split(new[] { " ","!", "?", "'", ",", ";", "." }, StringSplitOptions.RemoveEmptyEntries);
            var set = new HashSet<string>(banned);
            var wordDic = new Dictionary<string, int>();
            foreach(var wordItem in wordArray)
            {
                var str = wordItem.ToLower();
                if (set.Contains(str)) continue;

                if (!wordDic.ContainsKey(str))
                    wordDic[str] = 0;

                wordDic[str]++;
            }

            return wordDic.Aggregate((a, i) => a = a.Value < i.Value ? i : a).Key;
        }
    }
}
