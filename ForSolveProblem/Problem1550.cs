using System;
using System.Collections.Generic;
using System.Text;

namespace ForSolveProblem
{
    public class Problem1550 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public bool ThreeConsecutiveOdds(int[] arr)
        {
            var count = 0;
            foreach (var arrItem in arr)
            {
                if ((arrItem & 1) == 1)
                    count++;
                else
                    count = 0;

                if (count == 3) 
                    return true;
            }

            return false;
        }
    }
}
