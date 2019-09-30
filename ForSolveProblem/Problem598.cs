using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem598 : IProblem
    {
        public void RunProblem()
        {
            var temp = MaxCount(3, 3, new int[][] { new int[] { 2, 2 }, new int[] { 3, 3 } });
            if (temp != 4) throw new Exception();

            temp = MaxCount(3, 3, new int[][] { });
            if (temp != 9) throw new Exception();
        }

        public int MaxCount(int m, int n, int[][] ops)
        {
            /*
             * 范围求和
             * 思路：
             *  1. 长为m 宽为n 的一个矩阵，里面按照左上角对齐的方式，放置了多个小的矩形
             *  2. 那么问题就可以转换为，这些小矩形重合的地方有多大
             *  3. 也就是求得交集的过程，那么只要找到最短的边就可以了
             *  
             * 时间复杂度：O(n)
             * 空间复杂度：O(1)
             */

            int minM = m;
            int minN = n;
            for(int i = 0;i < ops.GetLength(0); i++)
            {
                minM = Math.Min(minM, ops[i][0]);
                minN = Math.Min(minN, ops[i][1]);
            }

            return minM * minN;
        }
    }
}
