using System;
using System.Collections.Generic;

namespace ForSolveProblem
{
    public class Problem873 : IProblem
    {
        public void RunProblem()
        {
            var temp = LenLongestFibSubseq(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 });
            if (temp != 5) throw new Exception();

            temp = LenLongestFibSubseq(new int[] { 1, 3, 7, 11, 12, 14, 18 });
            if (temp != 3) throw new Exception();
        }

        public int LenLongestFibSubseq(int[] A)
        {
            var forReturn = 0;
            var hashSets = new HashSet<int>(A);

            for (int i = 0; i < A.Length - 1; i++)
            {
                for (int j = i + 1; j < A.Length; j++)
                {
                    var count = 2;
                    var prev = A[i];
                    var next = A[j];
                    while (hashSets.Contains(prev + next))
                    {
                        count++;
                        var temp = prev + next;
                        prev = next;
                        next = temp;
                    }

                    if (count > 2)
                        forReturn = Math.Max(forReturn, count);
                }
            }

            return forReturn;
        }
    }
}
