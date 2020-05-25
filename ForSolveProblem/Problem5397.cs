using System;
using System.Collections.Generic;

namespace ForSolveProblem
{
    public class Problem5397 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public IList<string> SimplifiedFractions(int n)
        {
            var res = new List<string>();

            var sets = new HashSet<double>();

            for (var i = 1; i < n; i++)
            {
                for (var j = i + 1; j <= n; j++)
                {
                    var r = 1.0 * i / j;
                    if (sets.Contains(r))
                        continue;

                    sets.Add(r);
                    res.Add($"{i}/{j}");
                }
            }

            return res;
        }
    }
}
