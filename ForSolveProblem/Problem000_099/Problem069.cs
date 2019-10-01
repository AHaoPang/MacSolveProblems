using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem069 : IProblem
    {
        public void RunProblem()
        {
            var temp = MySqrt(6);
        }

        public int MySqrt(int x)
        {
            /*使用二分法，逐步逼近*/

            if (x <= 1) return x;

            int left = 0;
            int right = x;
            int mid = -1;
            int tempInt = 0;

            while (left + 1 < right)
            {
                mid = left + (right - left) / 2;

                tempInt = x / mid;

                if (mid == tempInt) return mid;
                else if (mid < tempInt) left = mid;
                else right = mid;
            }

            return left;
        }
    }
}
