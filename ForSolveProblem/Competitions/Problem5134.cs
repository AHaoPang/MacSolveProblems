using System;
namespace ForSolveProblem
{
    public class Problem5134 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int[] ReplaceElements(int[] arr)
        {
            var forReturn = new int[arr.Length];

            var maxNum = -1;
            for(int i = arr.Length - 1;i >= 0; i--)
            {
                forReturn[i] = maxNum;

                maxNum = Math.Max(maxNum, arr[i]);
            }

            return forReturn;
        }
    }
}
