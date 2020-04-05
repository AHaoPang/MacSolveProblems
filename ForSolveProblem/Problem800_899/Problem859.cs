using System;
using System.Collections.Generic;

namespace ForSolveProblem
{
    public class Problem859 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public bool BuddyStrings(string A, string B)
        {
            if (A.Length != B.Length) return false;

            var list = new int[2];
            var disCount = 0;
            for (var i = 0; i < A.Length; i++)
            {
                if (A[i] == B[i]) continue;

                if (disCount >= 2) return false;
                list[disCount++] = i;
            }

            if (disCount == 1)
                return false;
            else if (disCount == 0)
                return new HashSet<char>(A).Count != A.Length;
            else
                return A[list[0]] == B[list[1]] && A[list[1]] == B[list[0]];
        }
    }
}
