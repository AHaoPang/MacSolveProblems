using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem077 : IProblem
    {
        public void RunProblem()
        {
            var temp = Combine(4, 2);
        }

        public IList<IList<int>> Combine(int n, int k)
        {
            /*
             * 从n个数中，取出k个数的组合，有多少种情况
             * 思路：
             *  1.主要是为了能有序的遍历出来期望的结果
             * 
             * 时间复杂度：O(k*n)
             * 空间复杂度：O(k)
             */

            Recursive(new List<int>(), 1, n, 0, k);

            return forReturn;
        }

        private IList<IList<int>> forReturn = new List<IList<int>>();

        private void Recursive(IList<int> curList, int startNum, int stopNum, int kth, int k)
        {
            if (kth == k)
            {
                forReturn.Add(curList.ToList());
                return;
            }

            for (int i = startNum; i <= stopNum; i++)
            {
                curList.Add(i);
                Recursive(curList, i + 1, stopNum, kth + 1, k);
                curList.RemoveAt(curList.Count - 1);
            }
        }
    }
}
