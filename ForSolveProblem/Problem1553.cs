﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ForSolveProblem
{
    public class Problem1553 : IProblem
    {
        public void RunProblem()
        {
            var temp = MinDays(6);

            temp = MinDays(10);
        }

        public int MinDays(int n)
        {
            m_Dic = new Dictionary<int, int>();
            return Dfs(n);
        }

        private Dictionary<int, int> m_Dic;

        private int Dfs(int n)
        {
            if (m_Dic.ContainsKey(n))
                return m_Dic[n];

            var res = 0;
            if (n == 0)
                res = -1;
            else if (n == 1)
                res = 0;
            else if (n == 2 || n == 3)
                res = 1;
            else
                res = Math.Min(Dfs(n / 2) + n % 2, Dfs(n / 3) + n % 3);

            m_Dic[n] = res + 1;
            return m_Dic[n];
        }
    }
}
