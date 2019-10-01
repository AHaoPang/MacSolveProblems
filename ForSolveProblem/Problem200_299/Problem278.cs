using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem278 : IProblem
    {
        public void RunProblem()
        {
            var temp = FirstBadVersion(5);
            if (temp != 4) throw new Exception();
        }

        bool IsBadVersion(int version)
        {
            if (version >= 4) return true;

            return false;
        }

        public int FirstBadVersion(int n)
        {
            /*
             * 查找版本中，第一个错误的版本
             * 思路：
             *  1.是二分查找的一种变体
             *  2.双指针都有职责划分，leftPoint指向正确的版本，rightPoint指向错误的版本，退出的条件是leftPoint < rightPoint
             *  3.交错前，必然是重合的
             *      3.1 若他们在“正确的版本”重合，显然结果一定是leftPoint指向后一个版本，即错误版本
             *      3.2 若他们在“错误的版本”重合，显然结果一定是rigthPoint指向前一个版本，即正确的版本
             *      3.3 综上，我们只要在循环结束后，看leftPoint指向的版本，就是第一个错误的版本了
             *  4.找到答案，靠的是循环中止    
             *  
             * 时间复杂度：O(logn)，二分查找的复杂度
             * 空间复杂度：O(1)，使用的额外空间是稳定的
             */

            int leftPoint = 1;
            int rightPoint = n;

            while (leftPoint <= rightPoint)
            {
                var middlePoint = leftPoint + (rightPoint - leftPoint) / 2;

                if (!IsBadVersion(middlePoint))
                    leftPoint = middlePoint + 1;
                else
                    rightPoint = middlePoint - 1;
            }

            return leftPoint;
        }
    }
}
