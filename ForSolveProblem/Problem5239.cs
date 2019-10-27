using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForSolveProblem
{
    public class Problem5239 : IProblem
    {
        public void RunProblem()
        {
            var temp = CircularPermutation(2, 3);
            if (!ProblemHelper.ArrayIsEqual(temp.ToArray(), new int[] { 3, 2, 0, 1 })) throw new Exception();

            temp = CircularPermutation(3, 2);
            if (!ProblemHelper.ArrayIsEqual(temp.ToArray(), new int[] { 2, 6, 7, 5, 4, 0, 1, 3 })) throw new Exception();
        }

        public IList<int> CircularPermutation(int n, int start)
        {
            var intArray = new int[16];
            intArray[0] = 1;
            for (int i = 1; i < 16; i++)
                intArray[i] = intArray[i - 1] * 2;

            var intValue = (int)Math.Pow(2, n);
            var forReturn = new HashSet<int>(intValue);
            forReturn.Add(start);

            Backtrace(n, 0, start, forReturn, intArray);

            return forReturn.ToList();
        }

        private bool Backtrace(int n, int times, int curNum, ISet<int> nums, int[] intArray)
        {
            if ((int)Math.Pow(2, n) - 1 == times)
                return true;

            for (int i = 0; i < intArray.Length; i++)
            {
                var tempValue = curNum ^ intArray[i];
                if (nums.Contains(tempValue)) continue;

                nums.Add(tempValue);
                var resultTemp = Backtrace(n, times + 1, tempValue, nums, intArray);
                if (resultTemp) return true;

                nums.Remove(tempValue);
            }

            return false;
        }
    }
}
