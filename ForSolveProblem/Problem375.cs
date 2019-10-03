using System;
using System.Collections.Generic;

namespace ForSolveProblem
{
    public class Problem375 : IProblem
    {
        public void RunProblem()
        {
            var temp = GetMoneyAmount(10);
            if (temp != 16) throw new Exception();
        }

        public int GetMoneyAmount(int n)
        {
            return BackTrace(1, n, new Dictionary<string, int>());
        }

        private int BackTrace(int i, int j, IDictionary<string, int> dic)
        {
            var dicKey = $"{i}-{j}";
            if (dic.ContainsKey(dicKey)) return dic[dicKey];

            if (i == j) return 0;
            if (i + 1 == j) return i;

            var forReturn = int.MaxValue;
            for (int a = i + (j - i) / 2; a < j; a++)
            {
                var leftValue = BackTrace(i, a - 1, dic);
                var rightValue = BackTrace(a + 1, j, dic);
                var curValue = a + Math.Max(leftValue, rightValue);

                forReturn = Math.Min(forReturn, curValue);
            }

            dic[dicKey] = forReturn;
            return forReturn;
        }

        public int GetMoneyAmount1(int n)
        {
            /*
             * 题目概述：最少需要多少钱，才能赢得游戏
             * 
             * 思路：
             *  1. 越快猜对，需要支付的就越少
             *  2. 最快猜对的方式，就是使用二分法，可以在 O(logn)时间内找到
             *  3. 那么就是把层猜测过的数字加起来，就是需要准备的最少的钱
             *
             * 关键点：
             *
             * 时间复杂度： O(logn)
             * 空间复杂度： O(1)
             */

            var forReturn = 0;

            var left = 1;
            var right = n;
            while (left <= right)
            {
                var middle = left + (right - left) / 2;
                if (middle == n) break;

                if (middle < n) left = middle + 1;

                forReturn += middle;
            }

            return forReturn;
        }
    }
}
