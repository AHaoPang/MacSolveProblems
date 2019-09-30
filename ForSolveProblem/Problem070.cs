using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem070 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }


        public int ClimbStairs(int n)
        {
            return RecurSive(n);
        }

        private Dictionary<int, int> cacheStairs = new Dictionary<int, int>();

        private int RecurSive(int n)
        {
            /*
             * 方法二：通过递归的方式来求解
             * 
             * 粗暴的使用递归，会存在大量的重复计算，因此时间空间复杂度较高
             * 时间复杂度：O(2^n)-->指数级的复杂度，在短时间内运算量急剧上升；
             * 空间复杂度：O(2^n)
             * 
             * 考虑到存在大量重复，因此引入了“缓存”的方式，基本就避免了重复计算
             * 时间复杂度：O(n)-->近似
             * 空间复杂度：O(2^n+n)-->O(2^n)
             */

            if (n < 2) return 1;

            if (cacheStairs.ContainsKey(n)) return cacheStairs[n];

            cacheStairs[n] = ClimbStairs(n - 1) + ClimbStairs(n - 2);

            return cacheStairs[n];
        }

        /// <summary>
        /// 方法一：通过动态规划，正向求解
        /// </summary>
        private static int DynamicProgram(int n)
        {
            /*
             * 方案一：通过递推公式来求解；
             * 主体思路：当前台阶的走法，来源于上两个台阶走法之和；
             * 时间复杂度：遍历了n次，所以是O(n)；
             * 空间复杂度：使用的临时变量是固定的，所以是O(1)；
             */

            if (n < 2) return 1;

            int zero = 1;
            int one = 1;
            int two = zero + one;

            for (int i = 2; i <= n; i++)
            {
                two = zero + one;
                zero = one;
                one = two;
            }

            return two;
        }
    }
}
