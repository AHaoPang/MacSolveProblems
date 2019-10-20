using System;
using System.Collections.Generic;

namespace ForSolveProblem
{
    public class Problem5214 : IProblem
    {
        public void RunProblem()
        {
            var temp = LongestSubsequence(new int[] { 1, 2, 3, 4 }, 1);
            if (temp != 4) throw new Exception();

            temp = LongestSubsequence(new int[] { 1, 3, 5, 7 }, 1);
            if (temp != 1) throw new Exception();

            temp = LongestSubsequence(new int[] { 1, 5, 7, 8, 5, 3, 4, 2, 1 }, -2);
            if (temp != 4) throw new Exception();
        }

        public int LongestSubsequence(int[] arr, int difference)
        {
            var forReturn = 0;
            var dicValueCount = new Dictionary<int, int>(arr.Length);

            for(int i = 0;i < arr.Length; i++)
            {
                var keyTemp = arr[i] - difference;
                if (dicValueCount.ContainsKey(keyTemp))
                    dicValueCount[arr[i]] = dicValueCount[keyTemp] + 1;
                else
                    dicValueCount[arr[i]] = 1;

                forReturn = Math.Max(forReturn, dicValueCount[arr[i]]);
            }

            return forReturn;
        }
    }
}
