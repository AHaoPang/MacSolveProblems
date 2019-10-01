using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem898 : IProblem
    {
        public void RunProblem()
        {
            var temp = SubarrayBitwiseORs(new int[] { 0 });
            if (temp != 1) throw new Exception();

            temp = SubarrayBitwiseORs(new int[] { 1, 1, 2 });
            if (temp != 3) throw new Exception();

            temp = SubarrayBitwiseORs(new int[] { 1, 2, 4 });
            if (temp != 6) throw new Exception();
        }

        public int SubarrayBitwiseORs(int[] A)
        {
            /*
             * 求得数组中，子数组按位或后可能的结果的数量
             * 思路：
             *  1.老老实实做或操作好了
             *  2.需要找一种能很好借用之前或操作结果的方式
             */

            HashSet<int> resNums = new HashSet<int>();
            HashSet<int> curNums = new HashSet<int>() { 0 };
            for (int i = 0; i < A.Length; i++)
            {
                HashSet<int> nextNums = new HashSet<int>();
                foreach (var curItem in curNums)
                    nextNums.Add(curItem | A[i]);
                nextNums.Add(A[i]);

                curNums = nextNums;
                foreach (var nextItem in nextNums) resNums.Add(nextItem);
            }

            return resNums.Count;
        }
    }
}
