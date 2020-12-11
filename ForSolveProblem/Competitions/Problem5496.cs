using System;
using System.Collections.Generic;
using System.Text;

namespace ForSolveProblem
{
    public class Problem5496 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int MaxCoins(int[] piles)
        {
            Array.Sort(piles);

            var minIndex = 0;
            var secondMaxIndex = piles.Length - 2;
            var res = 0;
            while(minIndex < secondMaxIndex)
            {
                res += piles[secondMaxIndex];

                minIndex++;
                secondMaxIndex -= 2;
            }

            return res;
        }
    }
}
