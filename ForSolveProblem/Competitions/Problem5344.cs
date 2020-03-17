using System;
namespace ForSolveProblem
{
    public class Problem5344 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int[] SmallerNumbersThanCurrent(int[] nums)
        {
            var numDicArray = new int[101];
            foreach (var numItem in nums)
                numDicArray[numItem]++;

            var sum = 0;
            for (var i = 0; i < numDicArray.Length; i++)
            {
                sum += numDicArray[i];
                numDicArray[i] = sum;
            }

            var forReturn = new int[nums.Length];
            for (var i = 0; i < nums.Length; i++)
            {
                var curValue = nums[i];
                if (curValue == 0) continue;

                forReturn[i] = numDicArray[curValue - 1];
            }

            return forReturn;
        }
    }
}
