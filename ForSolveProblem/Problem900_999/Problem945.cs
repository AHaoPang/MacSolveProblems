using System;
using System.Linq;
namespace ForSolveProblem
{
    public class Problem945 : IProblem
    {
        public void RunProblem()
        {
            var temp = MinIncrementForUnique(new int[] { 3, 2, 1, 2, 1, 7 });
        }

        public int MinIncrementForUnique(int[] A)
        {
            if (A.Length == 0) return 0;

            var orderA = A.OrderBy(i => i).ToArray();
            var forReturn = 0;
            var rightValue = orderA.First() + 1;
            for (var i = 1; i < orderA.Length; i++)
            {
                if (orderA[i] < rightValue)
                {
                    forReturn += rightValue - orderA[i];
                    rightValue++;
                }
                else
                    rightValue = orderA[i] + 1;
            }

            return forReturn;
        }

        public int MinIncrementForUnique1(int[] A)
        {
            var constNum = (int)4e5;
            var posArray = new bool[constNum];

            var forReturn = 0;
            foreach (var aItem in A)
            {
                if (!posArray[aItem])
                {
                    posArray[aItem] = true;
                    continue;
                }

                var curPos = aItem;
                while (posArray[curPos])
                    curPos++;

                posArray[curPos] = true;
                forReturn += curPos - aItem;
            }

            return forReturn;
        }
    }
}
