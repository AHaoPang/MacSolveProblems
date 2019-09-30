using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem367 : IProblem
    {
        public void RunProblem()
        {
            var temp = IsPerfectSquare(16);
            if (temp != true) throw new Exception();

            temp = IsPerfectSquare(14);
            if (temp != false) throw new Exception();

            temp = IsPerfectSquare(1);
            if (temp != true) throw new Exception();

            temp = IsPerfectSquare(2147483647);
            if (temp != false) throw new Exception();

            temp = IsPerfectSquare(808201);
            if (temp != true) throw new Exception();
        }

        public bool IsPerfectSquare(int num)
        {
            /*
             * 验证一个数，是否是有效的完全平方数
             * 思路：
             *  1.依据题目意思，这个数是“正整数”
             *  2.考虑使用“二分法”，这个相当于在有序的可能性中，找到标准答案
             *  
             * 时间复杂度：O(logn)
             * 空间复杂度：O(1)
             */

            var leftPoint = 1;
            var rightPoint = num / 2 + 1;
            var limited = Math.Sqrt(int.MaxValue);
            if (rightPoint > limited) rightPoint = (int)limited;

            while (leftPoint <= rightPoint)
            {
                var midPoint = leftPoint + (rightPoint - leftPoint) / 2;

                long sqrtTemp = midPoint * midPoint;
                if (sqrtTemp == num) return true;

                if (sqrtTemp < num) leftPoint = midPoint + 1;
                else if (sqrtTemp > num) rightPoint = midPoint - 1;
            }

            return false;
        }
    }
}
