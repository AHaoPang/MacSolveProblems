using System;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem448 : IProblem
    {
        public void RunProblem()
        {
            var temp = FindDisappearedNumbers(new int[] { 4, 3, 2, 7, 8, 2, 3, 1 });
            if (!ProblemHelper.ArrayIsEqual(temp.ToArray(), new int[] { 5, 6 }, false)) throw new Exception();
        }

        public IList<int> FindDisappearedNumbers(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
                Recursion(nums, nums[i] - 1);

            var forReturn = new List<int>();
            for (int i = 0; i < nums.Length; i++)
                if (nums[i] != i + 1) forReturn.Add(i + 1);

            return forReturn;
        }

        private void Recursion(int[] nums, int curIndex)
        {
            if (nums[curIndex] == curIndex + 1) return;

            var curValue = nums[curIndex];
            nums[curIndex] = curIndex + 1;

            Recursion(nums, curValue - 1);
        }

        public IList<int> FindDisappearedNumbers1(int[] nums)
        {
            var boolArray = new bool[nums.Length + 1];
            foreach (var numItem in nums)
                boolArray[numItem] = true;

            var forReturn = new List<int>(nums.Length);
            for (int i = 1; i < boolArray.Length; i++)
                if (!boolArray[i]) forReturn.Add(i);

            return forReturn;
        }
    }
}
