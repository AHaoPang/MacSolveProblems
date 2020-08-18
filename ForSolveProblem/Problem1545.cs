using System;
using System.Collections.Generic;
using System.Text;

namespace ForSolveProblem
{
    public class Problem1545 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public char FindKthBit(int n, int k)
        {
            var length = (int)Math.Pow(2, n) - 1;
            return Recursive(length, k, false);
        }

        private char Recursive(int totallength, int k, bool isRevert)
        {
            if (k == 1)
                return isRevert ? '1' : '0';

            var mid = totallength / 2 + 1;
            if (k == mid)
                return isRevert ? '0' : '1';

            if (k < mid)
                return Recursive(totallength / 2, k, isRevert);
            else
                return Recursive(totallength / 2, mid - (k - mid), !isRevert);
        }
    }
}
