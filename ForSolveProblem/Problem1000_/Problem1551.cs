using System;
using System.Collections.Generic;
using System.Text;

namespace ForSolveProblem
{
    public class Problem1551 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int MinOperations(int n)
        {
            if ((n & 1) == 1)
                return OddCount(n);
            else
                return EvenCount(n);
        }

        private int OddCount(int n)
        {
            var targetIndex = n / 2;
            var indexValue = 2 * targetIndex + 1;
            var count = targetIndex;

            return (2 + indexValue - 1) * count / 2;
        }

        private int EvenCount(int n)
        {
            var targetIndex = n / 2 - 1;
            var indexValue = 2 * targetIndex + 1 + 1;
            var count = targetIndex + 1;

            return (1 + indexValue - 1) * count / 2;
        }
    }
}
