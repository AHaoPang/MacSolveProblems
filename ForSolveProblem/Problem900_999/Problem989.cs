using System;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem989 : IProblem
    {
        public void RunProblem()
        {
            var temp = AddToArrayForm(new[] { 1, 2, 0, 0 }, 34);
        }

        public IList<int> AddToArrayForm(int[] A, int K)
        {
            var kArr = K.ToString().Select(i => int.Parse(i.ToString())).Reverse().ToArray();
            var aArr = A.Reverse().ToArray();

            var res = Enumerable.Repeat(0, Math.Max(A.Length, kArr.Length)).ToList();
            var f = 0;
            var i = 0;
            while(i < kArr.Length || i < aArr.Length)
            {
                var a = i < aArr.Length ? aArr[i] : 0;
                var k = i < kArr.Length ? kArr[i] : 0;

                var s = k + a + f;
                f = s / 10;
                res[i] = s % 10;

                i++;
            }

            if (f > 0)
                res.Add(f);

            return res.Reverse<int>().ToList();
        }
    }
}
