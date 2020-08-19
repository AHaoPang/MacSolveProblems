using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForSolveProblem
{
    public class Problem1552 : IProblem
    {
        public void RunProblem()
        {
            var temp = MaxDistance(new[] { 1, 2, 3, 4, 7 }, 3);
        }

        public int MaxDistance(int[] position, int m)
        {
            var orderPosArr = position.OrderBy(i => i).ToArray();

            var left = 1;
            var right = (orderPosArr[orderPosArr.Length - 1] - orderPosArr[0]) / (m - 1);

            var res = 1;
            while (left < right)
            {
                var mid = left + (right - left) / 2;
                if (Check(orderPosArr, mid, m))
                {
                    res = mid;
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return res;
        }

        private bool Check(int[] orderPosArr, int mid, int m)
        {
            var count = 1;
            var curPos = 0;
            for (var i = 1; i < orderPosArr.Length; i++)
            {
                if (orderPosArr[i] - orderPosArr[curPos] >= mid)
                {
                    count++;
                    curPos = i;

                    if (count >= m) return true;
                }
            }

            return false;
        }
    }
}
