using System;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem229 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public IList<int> MajorityElement(int[] nums)
        {
            var num1 = int.MinValue;
            var num1Count = 0;
            var num2 = int.MinValue;
            var num2Count = 0;

            foreach (var numItem in nums)
            {
                if (numItem == num1)
                {
                    num1Count++;
                    continue;
                }

                if (numItem == num2)
                {
                    num2Count++;
                    continue;
                }

                if (num1Count == 0)
                {
                    num1 = numItem;
                    num1Count++;
                    continue;
                }

                if (num2Count == 0)
                {
                    num2 = numItem;
                    num2Count++;
                    continue;
                }

                num1Count--;
                num2Count--;
            }

            num1Count = 0;
            num2Count = 0;
            var forReturn = new HashSet<int>();
            foreach (var numItem in nums)
            {
                if (numItem == num1) num1Count++;
                if (numItem == num2) num2Count++;
            }

            if (num1Count > nums.Length / 3) forReturn.Add(num1);
            if (num2Count > nums.Length / 3) forReturn.Add(num2);

            return forReturn.ToList();
        }

        public IList<int> MajorityElement1(int[] nums)
        {
            var numCount = nums.ToLookup(i => i, j => j).ToDictionary(i => i.Key, j => j.Count());

            var forReturn = new List<int>();
            foreach (var dicItem in numCount)
                if (dicItem.Value > nums.Length / 3) forReturn.Add(dicItem.Key);

            return forReturn;
        }
    }
}
