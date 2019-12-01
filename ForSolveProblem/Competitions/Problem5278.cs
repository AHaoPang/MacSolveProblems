using System;
using System.Collections.Generic;

namespace ForSolveProblem
{
    public class Problem5278 : IProblem
    {
        public void RunProblem()
        {
            var temp = PalindromePartition("abc", 2);
            if (temp != 1) throw new Exception();

            temp = PalindromePartition("aabbc", 3);
            if (temp != 0) throw new Exception();

            temp = PalindromePartition("leetcode", 8);
            if (temp != 0) throw new Exception();

            temp = PalindromePartition("fyhowoxzyrincxivwarjuwxrwealesxsimsepjdqsstfggjnjhilvrwwytbgsqbpnwjaojfnmiqiqnyzijfmvekgakefjaxryyml", 32);
        }

        public int PalindromePartition(string s, int k)
        {
            m_cache = new Dictionary<string, int>();
            return Recursion(s, 0, s.Length - 1, k);
        }

        private Dictionary<string, int> m_cache;

        private int Recursion(string s, int startIndex, int stopIndex, int k)
        {
            var str = $"{startIndex}_{stopIndex}_{k}";
            if (m_cache.ContainsKey(str)) return m_cache[str];

            if (k == 1)
            {
                var count = 0;
                while (startIndex < stopIndex)
                {
                    if (s[startIndex] != s[stopIndex]) count++;

                    startIndex++;
                    stopIndex--;
                }
                m_cache[str] = count;
                return count;
            }

            var forReturn = int.MaxValue;
            for (int i = startIndex; i <= stopIndex - k + 1; i++)
            {
                var v1 = Recursion(s, startIndex, i, 1);
                var v2 = Recursion(s, i + 1, stopIndex, k - 1);

                forReturn = Math.Min(forReturn, v1 + v2);
            }

            m_cache[str] = forReturn;
            return forReturn;
        }
    }
}
