using System;
using System.Collections.Generic;

namespace ForSolveProblem
{
    public class Problem650 : IProblem
    {
        public int MinSteps(int n)
        {
            var dp = new int[n + 1];
            var h = (int)Math.Sqrt(n);
            for (int i = 2; i <= n; i++)
            {
                dp[i] = i;
                for (int j = 2; j <= h; j++)
                {
                    if (i % j == 0)
                    {
                        dp[i] = dp[j] + dp[i / j];
                        break;
                    }
                }
            }

            return dp[n];
        }

        public int MinSteps1(int n)
        {
            /*
             * 题目概述：用最少的步数，构造目标串
             * 
             * 思路：
             *  1. 回溯法，也没什么好说的
             *
             * 关键点：
             *  1. 回溯时，优先尝试能最快到达目标的值，然后快速中断继续尝试，一旦找到目标，就马上返回
             *
             * 时间复杂度：
             * 空间复杂度：
             */

            return Recursive(n, 1, 0, 0, new Dictionary<string, int>());
        }

        private int Recursive(int targetInt, int curInt, int pasteInt, int operaNum, IDictionary<string, int> dic)
        {
            var keyStr = $"{curInt}_{pasteInt}";
            if (dic.ContainsKey(keyStr)) return dic[keyStr];

            if (curInt + pasteInt > targetInt) return -1;
            if (curInt + pasteInt == targetInt) return operaNum;

            //直接粘贴后，拷贝当前值
            var resultOne = Recursive(targetInt, curInt + pasteInt, curInt + pasteInt, operaNum + 2, dic);
            if (resultOne != -1) return resultOne;

            //直接粘贴后，复用之前提供的粘贴值
            var resultTemp = Recursive(targetInt, curInt + pasteInt, pasteInt, operaNum + 1, dic);
            dic[keyStr] = resultTemp;
            return resultTemp;
        }

        public void RunProblem()
        {
            var temp = MinSteps(3);
            if (temp != 3) throw new Exception();

            temp = MinSteps(50);
            if (temp != 12) throw new Exception();
        }
    }
}
