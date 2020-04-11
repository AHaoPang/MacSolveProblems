using System;
using System.Collections.Generic;

namespace ForSolveProblem
{
    public class Problem1009 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int BitwiseComplement(int N)
        {
            if (N == 0) return 1;

            var nBit = new List<int>();
            while(N > 0)
            {
                if ((N & 1) == 1)
                    nBit.Add(0);
                else
                    nBit.Add(1);

                N >>= 1;
            }

            var res = 0;
            for(var i = nBit.Count - 1; i >= 0; i--)
            {
                res <<= 1;
                res += nBit[i];
            }

            return res;
        }
    }
}
