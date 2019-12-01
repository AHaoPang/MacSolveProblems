using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForSolveProblem
{
    public class Problem5265 : IProblem
    {
        public void RunProblem()
        {
            var temp = MaxSumDivThree(new int[] { 3, 6, 5, 1, 8 });
            if (temp != 18) throw new Exception();

            temp = MaxSumDivThree(new int[] { 4 });
            if (temp != 0) throw new Exception();

            temp = MaxSumDivThree(new int[] { 1, 2, 3, 4, 4 });
            if (temp != 12) throw new Exception();

            temp = MaxSumDivThree(new int[] { 3, 1, 2 });
            if (temp != 6) throw new Exception();

            temp = MaxSumDivThree(new int[] { 2, 19, 6, 16, 5, 10, 7, 4, 11, 6 });
            if (temp != 84) throw new Exception();

            temp = MaxSumDivThree(new int[] { 5, 2, 2, 2 });
            if (temp != 9) throw new Exception();
        }

        public int MaxSumDivThree(int[] nums)
        {
            var modNum = 3;
            var dp = new int[nums.Length, modNum];
            dp[0, nums[0] % modNum] = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                var curNum = nums[i];
                var curMod = curNum % modNum;

                for (int j = 0; j < modNum; j++)
                {
                    dp[i, j] = dp[i - 1, j];

                    var another = (modNum + j - curMod) % 3;
                    if ((dp[i - 1, another] + curNum) % 3 == j)
                        dp[i, j] = Math.Max(dp[i, j], dp[i - 1, another] + curNum);
                }
            }

            return dp[nums.Length - 1, 0];
        }

        public int MaxSumDivThree1(int[] nums)
        {
            var sumTemp = 0;
            var oneMinNums = new int[2] { -1, -1 };
            var twoMinNums = new int[2] { -1, -1 };

            for (int i = 0; i < nums.Length; i++)
            {
                sumTemp += nums[i];

                var modValue = nums[i] % 3;
                switch (modValue)
                {
                    case 1:
                        UpdateNums(oneMinNums, nums[i]);
                        break;

                    case 2:
                        UpdateNums(twoMinNums, nums[i]);
                        break;
                }
            }

            if (sumTemp % 3 == 0) return sumTemp;

            var subvalue = -1;
            if (sumTemp % 3 == 1)
            {
                if (oneMinNums[0] != -1)
                    subvalue = oneMinNums[0];

                if (twoMinNums[0] != -1 && twoMinNums[1] != -1)
                {
                    if (subvalue == -1) subvalue = twoMinNums[0] + twoMinNums[1];
                    else subvalue = Math.Min(subvalue, twoMinNums[0] + twoMinNums[1]);
                }
            }
            else
            {
                if (twoMinNums[0] != -1)
                    subvalue = twoMinNums[0];

                if (oneMinNums[0] != -1 && oneMinNums[1] != -1)
                {
                    if (subvalue == -1) subvalue = oneMinNums[0] + oneMinNums[1];
                    else subvalue = Math.Min(subvalue, oneMinNums[0] + oneMinNums[1]);
                }
            }

            if (subvalue == -1) return 0;
            return sumTemp - subvalue;
        }

        private void UpdateNums(int[] oneTwoNum, int curValue)
        {
            if (oneTwoNum[0] == -1)
            {
                oneTwoNum[0] = curValue;
                return;
            }

            if (oneTwoNum[1] == -1)
            {
                oneTwoNum[1] = curValue;
                return;
            }

            if (oneTwoNum[0] > oneTwoNum[1])
            {
                var temp = oneTwoNum[0];
                oneTwoNum[0] = oneTwoNum[1];
                oneTwoNum[1] = temp;
            }

            if (oneTwoNum[1] <= curValue) return;

            if (oneTwoNum[0] > curValue)
            {
                oneTwoNum[1] = oneTwoNum[0];
                oneTwoNum[0] = curValue;
            }
            else
                oneTwoNum[1] = curValue;
        }
    }
}
