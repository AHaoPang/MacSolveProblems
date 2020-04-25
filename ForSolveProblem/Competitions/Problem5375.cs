using System;
using System.Collections.Generic;

namespace ForSolveProblem
{
    public class Problem5375 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int NumberOfArrays(string s, int k)
        {
            m_dic = new Dictionary<int, int>();
            return Recursive(s, k, 0);
        }

        private Dictionary<int, int> m_dic;

        private int Recursive(string s, int k, int curIndex)
        {
            var constNum = (int)(1e9 + 7);

            if (m_dic.ContainsKey(curIndex))
                return m_dic[curIndex];

            if (s.Length == curIndex)
                return 1;

            if (s[curIndex] == '0')
                return 0;

            var res = 0;
            for (var i = curIndex; i < s.Length; i++)
            {
                var subStr = s.Substring(curIndex, i - curIndex + 1);
                if (long.Parse(subStr) > k)
                    break;

                res += Recursive(s, k, i + 1);
                res %= constNum;
            }

            m_dic[curIndex] = res;
            return res;
        }
    }
}
