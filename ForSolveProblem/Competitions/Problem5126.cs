using System;
namespace ForSolveProblem
{
    public class Problem5126 : IProblem
    {
        public void RunProblem()
        {
            var temp = FindSpecialInteger(new int[] { 1, 2, 2, 6, 6, 6, 6, 7, 10 });
            if (temp != 6) throw new Exception();
        }

        public int FindSpecialInteger(int[] arr)
        {
            var target = arr.Length / 4;

            var curNum = -1;
            var curCount = 0;
            foreach (var arrItem in arr)
            {
                if (arrItem != curNum)
                {
                    curNum = arrItem;
                    curCount = 1;
                }
                else
                    curCount++;

                if (curCount > target) return curNum;
            }

            return curNum;
        }
    }
}
