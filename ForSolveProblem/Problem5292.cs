using System;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem5292 : IProblem
    {
        public void RunProblem()
        {
            var temp = IsPossibleDivide(new int[] { 1, 2, 3, 3, 4, 4, 5, 6 }, 4);
            if (temp != true) throw new Exception();

            temp = IsPossibleDivide(new int[] { 3, 2, 1, 2, 3, 4, 3, 4, 5, 9, 10, 11 }, 3);
            if (temp != true) throw new Exception();

            temp = IsPossibleDivide(new int[] { 3, 3, 2, 2, 1, 1 }, 3);
            if (temp != true) throw new Exception();

            temp = IsPossibleDivide(new int[] { 1, 2, 3, 4 }, 3);
            if (temp != false) throw new Exception();

            temp = IsPossibleDivide(new int[] { 15, 16, 17, 18, 19, 16, 17, 18, 19, 20, 6, 7, 8, 9, 10, 3, 4, 5, 6, 20 }, 5);
            if (temp != false) throw new Exception();
        }

        public bool IsPossibleDivide(int[] nums, int k)
        {
            if (nums.Length % k != 0)
                return false;

            var maxNum = nums.Max();
            var numDic = new int[maxNum + 1];
            foreach (var numItem in nums)
                numDic[numItem]++;

            for (int i = 0; i < numDic.Length; i++)
            {
                if (numDic[i] == 0) continue;

                var subValue = numDic[i];
                for (int j = i; j < i + k; j++)
                {
                    numDic[j] -= subValue;
                    if (numDic[j] < 0) return false;
                }
            }

            return true;
        }
    }
}
