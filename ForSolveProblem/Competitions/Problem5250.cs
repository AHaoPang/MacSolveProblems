using System;
using System.Collections.Generic;
using System.Text;

namespace ForSolveProblem
{
    public class Problem5250 : IProblem
    {
        public void RunProblem()
        {
            var temp = IsGoodArray(new int[] { 12, 5, 7, 23 });
            if (temp != true) throw new Exception();

            temp = IsGoodArray(new int[] { 29, 6, 10 });
            if (temp != true) throw new Exception();

            temp = IsGoodArray(new int[] { 3, 6 });
            if (temp != false) throw new Exception();

            temp = IsGoodArray(new int[] { 1 });
            if (temp != true) throw new Exception();
        }

        public bool IsGoodArray(int[] nums)
        {
            var num = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                num = gcd(num, nums[i]);

                if (num == 1) return true;
            }

            return num == 1;
        }

        private int gcd(int a, int b)
        {
            if (b == 0) return a;
            return gcd(b, a % b);
        }
    }
}
