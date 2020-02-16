using System;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem5333 : IProblem
    {
        public void RunProblem()
        {
            var temp = MinSteps("bab", "aba");
            if (temp != 1) throw new Exception();

            temp = MinSteps("leetcode", "practice");
            if (temp != 5) throw new Exception();

            temp = MinSteps("anagram", "mangaar");
            if (temp != 0) throw new Exception();

            temp = MinSteps("xxyyzz", "xxyyzz");
            if (temp != 0) throw new Exception();

            temp = MinSteps("friend", "family");
            if (temp != 4) throw new Exception();
        }

        public int MinSteps(string s, string t)
        {
            var sCount = GetCharCount(s);
            var tCount = GetCharCount(t);

            var forReturn = 0;
            foreach (var sItem in sCount)
            {
                var curChar = sItem.Key;

                var remainValue = sItem.Value;
                if (tCount.ContainsKey(curChar))
                {
                    remainValue -= tCount[curChar];

                    if (remainValue < 0)
                        remainValue = 0;
                }

                forReturn += remainValue;
            }

            return forReturn;
        }

        private Dictionary<char, int> GetCharCount(string s)
        {
            return s.ToCharArray().ToLookup(i => i, j => j).ToDictionary(i => i.Key, j => j.Count());
        }
    }
}
