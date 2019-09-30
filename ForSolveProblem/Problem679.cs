using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem679 : IProblem
    {
        public void RunProblem()
        {
            var temp = JudgePoint24(new int[] { 4, 1, 8, 7 });
        }

        public bool JudgePoint24(int[] nums)
        {
            /*
             * 采用回溯的办法，依次遍历所有可能性，知道有一种满足条件
             * 时间复杂度：可能性是有上限的，所以是 O(1)；
             * 空间复杂度：O(1)；
             */

            List<double> numLists = new List<double>(nums.Select(i => (double)i));

            return ReverseSolve(numLists);
        }

        public bool ReverseSolve(List<double> numLists)
        {
            //end point
            if (numLists.Count == 0) return false;//不太可能出现这种情况
            if (numLists.Count == 1) return Math.Abs(numLists[0] - 24) < 0.00001;//小于一定的精度，就可以认为是相等的

            //从数组中取出两个数字
            for (int i = 0; i < numLists.Count; i++)
            {
                for (int j = 0; j < numLists.Count; j++)
                {
                    if (i == j) continue;

                    //把剩余的数字加到数组中
                    List<double> newNumLists = new List<double>();
                    for (int k = 0; k < numLists.Count; k++) if (k != i && k != j) newNumLists.Add(numLists[k]);

                    //开始将取出的数字与运算符组合
                    for (int l = 0; l < 4; l++)
                    {
                        if (l < 2 && j > i) continue;
                        else if (l == 0) newNumLists.Add(numLists[i] + numLists[j]);
                        else if (l == 1) newNumLists.Add(numLists[i] * numLists[j]);
                        else if (l == 2) newNumLists.Add(numLists[i] - numLists[j]);
                        else
                        {
                            if (numLists[j] == 0) continue;
                            newNumLists.Add(numLists[i] / numLists[j]);
                        }

                        if (ReverseSolve(newNumLists)) return true;
                        newNumLists.RemoveAt(newNumLists.Count - 1);
                    }
                }
            }

            return false;//没有任何可能性了，所以就返回false
        }
    }
}
