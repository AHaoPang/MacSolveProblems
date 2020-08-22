using System;
using System.Collections.Generic;
using System.Text;

namespace ForSolveProblem
{
    public class Problem1534 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int CountGoodTriplets(int[] arr, int a, int b, int c)
        {
            var res = 0;

            for (var i = 0; i < arr.Length - 2; i++)
            {
                for (var j = i + 1; j < arr.Length - 1; j++)
                {
                    var at = Math.Abs(arr[i] - arr[j]);
                    if (at > a) continue;

                    for (var k = j + 1; k < arr.Length; k++)
                    {
                        var bt = Math.Abs(arr[j] - arr[k]);
                        var ct = Math.Abs(arr[i] - arr[k]);

                        if (bt <= b && ct <= c)
                            res++;
                    }
                }
            }

            return res;
        }
    }
}
