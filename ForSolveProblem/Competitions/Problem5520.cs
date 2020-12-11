using System;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem5520 : IProblem
    {
        public void RunProblem()
        {
            var s = "miadceddlamda";
            var t = MaxUniqueSplit(s);
        }

        public int MaxUniqueSplit(string s)
        {
            m_res = 0;
            Recursive(s, 0, new HashSet<string>());
            return m_res;
        }

        private int m_res;

        private void Recursive(string s, int curIndex, ISet<string> set)
        {
            if (s.Length == curIndex)
            {
                m_res = Math.Max(m_res, set.Count);
                return;
            }

            var curStr = "";
            for (var i = curIndex; i < s.Length; i++)
            {
                curStr += s[i];
                if (set.Contains(curStr)) continue;

                set.Add(curStr);
                Recursive(s, i + 1, set);
                set.Remove(curStr);
            }
        }
    }
}
