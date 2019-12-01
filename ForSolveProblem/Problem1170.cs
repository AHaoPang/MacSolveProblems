using System;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem1170 : IProblem
    {
        public void RunProblem()
        {
            var temp = NumSmallerByFrequency(new string[]
            {
                "cbd",
            }, new string[]
            {
                "zaaaz"
            });
            if (!ProblemHelper.ArrayIsEqual(new int[] { 1 }, temp, false)) throw new Exception();

            temp = NumSmallerByFrequency(new string[]
            {
                "bbb",
                "cc"
            }, new string[]
            {
                "a",
                "aa",
                "aaa",
                "aaaa"
            });
            if (!ProblemHelper.ArrayIsEqual(new int[] { 1, 2 }, temp, false)) throw new Exception();

        }

        public int[] NumSmallerByFrequency(string[] queries, string[] words)
        {
            var wordSortArray = new int[11];
            for (int i = 0; i < words.Length; i++)
                wordSortArray[GetMinNumCount(words[i])]++;

            var sumArray = new int[11];
            var sum = 0;
            for (int j = wordSortArray.Length - 1; j > 0; j--)
            {
                sumArray[j] = sum;
                sum += wordSortArray[j];
            }

            var forReturn = new int[queries.Length];
            for (int i = 0; i < queries.Length; i++)
                forReturn[i] = sumArray[GetMinNumCount(queries[i])];

            return forReturn;
        }

        private int GetMinNumCount2(string s)
        {
            var charArray = s.ToCharArray();
            Array.Sort(charArray, StringComparer.Ordinal);

            var forReturn = 1;
            for (int i = 1; i < charArray.Length; i++)
            {
                if (charArray[i] != charArray[0]) break;
                forReturn++;
            }

            return forReturn;
        }

        private int GetMinNumCount(string s)
        {
            var charArray = new int[26];
            foreach (var sItem in s)
                charArray['a' - sItem]++;

            return charArray.First(i => i != 0);
        }
    }
}
