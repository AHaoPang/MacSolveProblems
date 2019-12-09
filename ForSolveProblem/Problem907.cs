using System;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem907 : IProblem
    {
        public void RunProblem()
        {
            var temp = SumSubarrayMins(new int[] { 3, 1, 2, 4 });
            if (temp != 17) throw new Exception();
        }

        public int SumSubarrayMins(int[] A)
        {
            var limitNum = (int)1e9 + 7;

            var stackTemp = new Stack<StackItem>();
            var forReturn = 0;
            var preSum = 0;
            for (int i = 0; i < A.Length; i++)
            {
                var valItemTemp = new StackItem(A[i], 1);
                while (stackTemp.Any() && stackTemp.Peek().Val >= valItemTemp.Val)
                {
                    var popItem = stackTemp.Pop();

                    preSum -= popItem.Val * popItem.Count;
                    valItemTemp.Count += popItem.Count;
                }
                stackTemp.Push(valItemTemp);
                preSum += valItemTemp.Count * valItemTemp.Val;
                forReturn += preSum;
                forReturn %= limitNum;
            }

            return forReturn;
        }

        public class StackItem
        {
            public int Val { get; set; }

            public int Count { get; set; }

            public StackItem(int val, int count)
            {
                Val = val;
                Count = count;
            }
        }

        public int SumSubarrayMins1(int[] A)
        {
            var forReturn = 0;

            var dp = new int[A.Length];
            for (int i = 0; i < A.Length; i++)
            {
                var curValue = A[i];
                for (int j = i; j > 0; j--)
                {
                    dp[j] = Math.Min(dp[j - 1], curValue);
                    forReturn = AddTemp(forReturn, dp[j]);
                }

                dp[0] = curValue;
                forReturn = AddTemp(forReturn, dp[0]);
            }

            return forReturn;
        }

        private int AddTemp(int forReturn, int addValue)
        {
            var limit = (int)1e9 + 7;

            forReturn += addValue;
            if (forReturn >= limit) forReturn %= limit;

            return forReturn;
        }
    }
}
