using System;
using System.Collections.Generic;
using System.Text;

namespace ForSolveProblem
{
    public class Problem5495 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public IList<int> MostVisited(int n, int[] rounds)
        {
            var arr = new int[n + 1];
            for (var i = 0; i < rounds.Length - 1; i++)
            {
                var start = rounds[i];
                var stop = rounds[i + 1];
                while (start != stop)
                {
                    arr[start++]++;

                    if (start > n)
                        start = 1;
                }
            }
            arr[rounds[rounds.Length - 1]]++;

            var res = new List<int>();
            var max = 0;
            for (var i = 0; i < arr.Length; i++)
            {
                if (arr[i] < max) continue;

                if (arr[i] > max)
                {
                    max = arr[i];
                    res.Clear();
                }

                res.Add(i);
            }

            return res;
        }
    }
}
