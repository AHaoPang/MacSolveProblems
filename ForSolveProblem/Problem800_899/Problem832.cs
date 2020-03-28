using System;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem832 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int[][] FlipAndInvertImage(int[][] A)
        {
            return A.Select(i => i.Reverse().Select(j => j ^ 1).ToArray()).ToArray();
        }

        public int[][] FlipAndInvertImage1(int[][] A)
        {
            var res = new int[A.Length][];
            for(var r = 0;r < A.Length; r++)
                res[r] = A[r].Reverse().Select(i => i ^ 1).ToArray();

            return res;
        }
    }
}
