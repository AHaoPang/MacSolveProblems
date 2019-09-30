using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem941 : IProblem
    {
        public void RunProblem()
        {
            int[] A = new int[] {2,1 };
            var temp = ValidMountainArray(A);
            if (temp != false) throw new Exception();

            A = new int[] { 3, 5, 5 };
            temp = ValidMountainArray(A);
            if (temp != false) throw new Exception();

            A = new int[] { 0, 3, 2, 1 };
            temp = ValidMountainArray(A);
            if (temp != true) throw new Exception();
        }

        public bool ValidMountainArray(int[] A)
        {
            /*
             * 校验一个数组，是否是山脉形的数组，也就是一个依次递增+一个依次递减序列
             * 思路：
             *  1.依据此种类型数组的特征；
             *  2.可以尝试从左边爬山，到一个高峰；再从右边爬山，到一个高峰；
             *  3.若两个高峰一致，那么就是山脉行的数组了；
             *  4.在爬山的过程中还可以做检测，看看是不是有平地啥的；
             *  
             * 时间复杂度：O(n)，最坏情况下，就是整座山都爬完了，确定是满足条件的山脉形数组
             * 空间复杂度：O(1)
             */

            if (A.Length < 3) return false;

            int leftPoint = 0;
            while (leftPoint < A.Length - 1)
            {
                if (A[leftPoint] == A[leftPoint + 1]) return false;

                if (A[leftPoint] > A[leftPoint + 1]) break;

                leftPoint++;
            }

            if (leftPoint == 0 || leftPoint == A.Length - 1) return false;

            int rightPoint = A.Length - 1;
            while (rightPoint > 0)
            {
                if (A[rightPoint] == A[rightPoint - 1]) return false;

                if (A[rightPoint] > A[rightPoint - 1]) break;

                rightPoint--;
            }

            if (rightPoint == 0 || rightPoint == A.Length - 1) return false;

            return leftPoint == rightPoint;
        }
    }
}
