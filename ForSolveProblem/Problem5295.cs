using System;
namespace ForSolveProblem
{
    public class Problem5295 : IProblem
    {
        public void RunProblem()
        {
            var temp = SumZero(5);
            temp = SumZero(3);
            temp = SumZero(1);
            temp = SumZero(4);
        }

        public int[] SumZero(int n)
        {
            var numCount = n / 2;

            var forReturn = new int[n];
            for (int i = 1; i <= numCount; i++)
            {
                forReturn[i - 1] = i;
                forReturn[n - i] = i * -1;
            }

            return forReturn;
        }
    }
}
