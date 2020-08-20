using System;
using System.Collections.Generic;
using System.Text;

namespace ForSolveProblem
{
    public class Problem1535 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int GetWinner(int[] arr, int k)
        {
            var c = 0;
            var cMax = arr[0];
            for(var i = 1;i < arr.Length; i++)
            {
                if (cMax > arr[i])
                    c++;
                else
                {
                    cMax = arr[i];
                    c = 1;
                }

                if (c == k)
                    return cMax;
            }

            return cMax;
        }
    }
}
