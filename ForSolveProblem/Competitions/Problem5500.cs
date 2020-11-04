using System;
using System.Collections.Generic;
using System.Text;

namespace ForSolveProblem
{
    public class Problem5500 : IProblem
    {
        public void RunProblem()
        {
            var t = GetMaxLen(new[] { 1, -2, -3, 4 });
            if (t != 4) throw new Exception();

            t = GetMaxLen(new[] { 0, 1, -2, -3, -4 });
            if (t != 3) throw new Exception();

            t = GetMaxLen(new[] { -1, -2, -3, 0, 1 });
            if (t != 2) throw new Exception();

            t = GetMaxLen(new[] { -1, 2 });
            if (t != 1) throw new Exception();

            t = GetMaxLen(new[] { 1, 2, 3, 5, -6, 4, 0, 10 });
            if (t != 4) throw new Exception();
        }

        public int GetMaxLen(int[] nums)
        {
            var res = 0;

            var lIndex = 0;
            var arr = new[] { -1, -1 };
            var neCount = 0;

            for (var i = 0; i < nums.Length; i++)
            {
                var curNum = nums[i];
                if (curNum == 0)
                {
                    var r = MaxLen(arr, lIndex, i - 1, neCount, nums.Length);
                    res = Math.Max(res, r);

                    lIndex = i + 1;
                    arr = new[] { -1, -1 };
                    neCount = 0;
                }
                else if (curNum < 0)
                {
                    neCount++;

                    if (arr[0] == -1)
                        arr[0] = i;
                    else
                        arr[1] = i;
                }
            }

            var rt = MaxLen(arr, lIndex, nums.Length - 1, neCount, nums.Length);
            res = Math.Max(res, rt);

            return res;
        }

        private int MaxLen(int[] arr, int lIndex, int rIndex, int neCount, int maxLength)
        {
            if (lIndex >= maxLength) return 0;
            if (lIndex > rIndex) return 0;

            if (neCount % 2 == 0)
                return rIndex - lIndex + 1;

            if (arr[1] == -1)
                return Math.Max(rIndex - arr[0], arr[0] - lIndex);
            else
                return Math.Max(rIndex - arr[0], arr[1] - lIndex);
        }
    }
}
