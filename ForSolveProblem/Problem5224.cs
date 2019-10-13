using System;
namespace ForSolveProblem
{
    public class Problem5224 : IProblem
    {
        public int DieSimulator(int n, int[] rollMax)
        {
            var constNum = unchecked((int)(1E9 + 7));
            var countArray = new int[] { 1, 1, 1, 1, 1, 1 };

            var totalArray = new long[] { 1, 1, 1, 1, 1, 1 };

            for (int i = 1; i < n; i++)
            {
                var newArray = new long[6];

                for (int j = 0; j < 6; j++)
                {
                    for (int k = 0; k < 6; k++)
                    {
                        if (j == k) countArray[j]++;

                        if (countArray[j] > rollMax[j])
                        {
                            countArray[j] = 1;
                            continue;
                        }

                        newArray[j] += totalArray[k];
                        newArray[j] %= constNum;
                    }
                }
                 
                totalArray = newArray;
            }

            long forReturn = 0;
            for (int i = 0; i < totalArray.Length; i++)
            {
                forReturn += totalArray[i];
                forReturn %= constNum;
            }

            return (int)forReturn;
        }

        public void RunProblem()
        {
            var temp = DieSimulator(2, new int[] { 1, 1, 2, 2, 2, 3 });
            if (temp != 34) throw new Exception();

            temp = DieSimulator(2, new int[] { 1, 1, 1, 1, 1, 1 });
            if (temp != 30) throw new Exception();

            temp = DieSimulator(3, new int[] { 1, 1, 1, 2, 2, 3 });
            if (temp != 181) throw new Exception();
        }
    }
}
