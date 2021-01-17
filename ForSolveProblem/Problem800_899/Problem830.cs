using System;
using System.Collections.Generic;
using System.Text;

namespace ForSolveProblem
{
    public class Problem830 : IProblem
    {
        public void RunProblem()
        {

        }

        public IList<IList<int>> LargeGroupPositions1(string S)
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

        public IList<IList<int>> LargeGroupPositions(string s)
        {
            var res = new List<IList<int>>();

            var sb = new StringBuilder(s);
            sb.Insert(0, '1');
            sb.Append('1');

            var newS = sb.ToString();
            var curChar = ' ';
            var firstIndex = -1;
            for (var i = 0; i < newS.Length; i++)
            {
                if (curChar != newS[i])
                {
                    if (i - firstIndex >= 3)
                        res.Add(new[] { firstIndex - 1, i - 2 });

                    curChar = newS[i];
                    firstIndex = i;
                }
            }

            return res;
        }
    }
}
