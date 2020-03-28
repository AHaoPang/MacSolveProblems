using System;
using System.Collections.Generic;

namespace ForSolveProblem
{
    public class Problem830 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public IList<IList<int>> LargeGroupPositions(string S)
        {
            var res = new List<IList<int>>();
            var leftIndex = 0;
            var rightIndex = 1;
            while (rightIndex <= S.Length)
            {
                if (rightIndex == S.Length || S[rightIndex] != S[leftIndex])
                {
                    if (rightIndex - leftIndex >= 3)
                        res.Add(new[] { leftIndex, rightIndex - 1 });

                    leftIndex = rightIndex;
                }

                rightIndex++;
            }

            return res;
        }
    }
}
