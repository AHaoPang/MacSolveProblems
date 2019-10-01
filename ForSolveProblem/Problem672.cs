using System;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem672 : IProblem
    {
        public void RunProblem()
        {
            var temp = FlipLights(1, 1);
            if (temp != 2) throw new Exception();

            temp = FlipLights(2, 1);
            if (temp != 3) throw new Exception();

            temp = FlipLights(3, 1);
            if (temp != 4) throw new Exception();

            temp = FlipLights(100, 2);
            if (temp != 7) throw new Exception();
        }

        public int FlipLights(int n, int m)
        {
            /*
             * n 个灯泡，在 m 轮开关操作以后，会有多少种亮灯和灭灯的可能性
             * 思路：
             *  1. 查找可能性的问题，大概率是用到了“回溯”;
             *  2. 一个需要做 m 轮操作，每轮的可选方案有4个;
             *  3. 使用6个整数的数组来表示好了;
             *  4. 使用备忘录的方式来优化算法;
             *
             * 时间复杂度：O(n^2)
             * 空间复杂度：O(n^2)
             */

            n = n > 6 ? 6 : n;
            var intArray = Enumerable.Repeat(1, n).ToArray();
            var hashSetResult = new HashSet<string>();
            var memoryResult = new HashSet<string>();

            BackTrack(intArray, 0, m, hashSetResult, memoryResult);

            return hashSetResult.Count;
        }

        /// <summary>
        /// 回溯方法
        /// </summary>
        private void BackTrack(int[] intArray, int curTime, int m, ISet<string> sets, ISet<string> memorySets)
        {
            if (m == curTime)
            {
                sets.Add(string.Join(',', intArray));
                return;
            }

            for (int i = 0; i < 4; i++)
            {
                ChangeArrayContent(intArray, i);

                var strTemp = curTime + string.Join(',', intArray);
                if (!memorySets.Contains(strTemp))
                {
                    BackTrack(intArray, curTime + 1, m, sets, memorySets);
                    memorySets.Add(strTemp);
                }

                ChangeArrayContent(intArray, i);
            }
        }

        /// <summary>
        /// 依据4种规则，来改变数组的内容
        /// </summary>
        private void ChangeArrayContent(int[] intArray, int i)
        {
            //对数组做修改
            switch (i)
            {
                case 0:
                    for (int j = 0; j < intArray.Length; j++) intArray[j] = intArray[j] == 0 ? 1 : 0;
                    break;

                case 1:
                    for (int j = 0; j < intArray.Length; j += 2) intArray[j] = intArray[j] == 0 ? 1 : 0;
                    break;

                case 2:
                    for (int j = 1; j < intArray.Length; j += 2) intArray[j] = intArray[j] == 0 ? 1 : 0;
                    break;

                case 3:
                    for (int j = 0; j < intArray.Length; j += 3) intArray[j] = intArray[j] == 0 ? 1 : 0;
                    break;
            }
        }
    }
}
