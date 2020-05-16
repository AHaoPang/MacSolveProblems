using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem354 : IProblem
    {
        public void RunProblem()
        {
            var temp = MaxEnvelopes(new int[][]
            {
                new[]{1, 2},
                new[]{2, 3},
                new[]{3, 4},
                new[]{3, 5},
                new[]{4, 5},
                new[]{5, 5},
                new[]{5, 6},
                new[]{6, 7},
                new[]{7, 8 }
            });
        }

        public int MaxEnvelopes(int[][] envelopes)
        {
            var descArr = envelopes
                .OrderBy(i => i, new CompareArr())
                .Select(i => i[1])
                .ToArray();

            var res = 0;
            var list = new List<int>();
            for (var i = 0; i < descArr.Length; i++)
            {
                var curNum = descArr[i];

                var l = 0;
                var r = res;
                while (l < r)
                {
                    var mid = l + (r - l) / 2;

                    if (list[mid] >= curNum)
                        r = mid;
                    else
                        l = mid + 1;
                }

                if (l == res)
                {
                    list.Add(curNum);
                    res++;
                }
                else
                    list[l] = curNum;
            }

            return res;
        }

        public class CompareArr : IComparer<int[]>
        {
            public int Compare(int[] x, int[] y)
            {
                if (x[0] != y[0])
                    return x[0].CompareTo(y[0]);

                return y[1].CompareTo(x[1]);
            }
        }
    }
}
