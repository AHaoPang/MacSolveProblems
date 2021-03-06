﻿using System;
using System.Collections.Generic;

namespace ForSolveProblem
{
    public class Problem509 : IProblem
    {
        public void RunProblem()
        {
            var temp = Fib(2);
            if (temp != 1) throw new Exception();

            temp = Fib(3);
            if (temp != 2) throw new Exception();

            temp = Fib(4);
            if (temp != 3) throw new Exception();
        }

        public int Fib2(int N)
        {
            if (m_dic.ContainsKey(N)) return m_dic[N];

            if (N <= 1) return N;

            m_dic[N] = Fib(N - 1) + Fib(N - 2);
            return m_dic[N];
        }

        private Dictionary<int, int> m_dic = new Dictionary<int, int>();

        public int Fib1(int N)
        {
            if (N <= 1) return N;

            int prevOne = 0;
            int prevTwo = 1;
            for (int i = 2; i <= N; i++)
            {
                var temp = prevOne + prevTwo;
                prevOne = prevTwo;
                prevTwo = temp;
            }

            return prevTwo;
        }

        public int Fib(int n)
        {
            if (n <= 1) return n;

            var resArr = new int[n + 1];
            resArr[0] = 0;
            resArr[1] = 1;

            for (var i = 2; i <= n; i++)
                resArr[i] = resArr[i - 1] + resArr[i - 2];

            return resArr[n];
        }
    }
}
