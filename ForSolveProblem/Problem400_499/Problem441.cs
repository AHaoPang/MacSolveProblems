using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem441 : IProblem
    {
        public void RunProblem()
        {
            var temp = ArrangeCoins(2147483647);
        }

        public int ArrangeCoins(int n)
        {
            /*
             * 使用二分法吧
             * 目标是，找到一个位置，当前行<=n 下一行>n
             * 时间复杂度：O(n);
             * 空间复杂度：O(1);
             */

            int leftPoint = 1;
            int rightPoint = (int)Math.Sqrt(n) + 1;
            int midPoint = 0;
            long totalSum = 0;

            if (n == 0 || n == 1) return 1;

            while(leftPoint < rightPoint)
            {
                midPoint = leftPoint + (rightPoint - leftPoint) / 2;
                totalSum = (1 + midPoint) * (midPoint / 2);

                //满足条件后的返回
                if (totalSum == n) return midPoint;

                //特殊条件的返回
                if (leftPoint + 1 == rightPoint) break;

                if (totalSum < n) leftPoint = midPoint;
                else rightPoint = midPoint;
            }

            return leftPoint;
        }

        public int ArrangeCoins1(int n)
        {
            /*
             * 循环遍历不断累加的方法
             * 时间复杂度：O(n)；
             * 空间复杂度：O(1)；
             */

            int forReturn = 1;

            while (n > 0)
            {
                n -= forReturn;
                forReturn++;

                if (n < forReturn) return forReturn - 1;
            }

            return 0;
        }
    }
}
