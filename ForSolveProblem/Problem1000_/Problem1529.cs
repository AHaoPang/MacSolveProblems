using System;
using System.Collections.Generic;
using System.Text;

namespace ForSolveProblem
{
    public class Problem1529 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int MinFlips(string target)
        {
            var res = 0;

            var curChar = ' ';
            for (var i = 0; i < target.Length; i++)
            {
                if (curChar != target[i])
                {
                    res++;
                    curChar = target[i];
                }
            }

            if (target[0] == '0')
                res--;

            return res;
        }
    }
}
