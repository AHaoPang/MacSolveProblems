using System;
using System.Collections.Generic;

namespace ForSolveProblem
{
    public class Problem5400 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public string DestCity(IList<IList<string>> paths)
        {
            var dic = new Dictionary<string, string>();
            for (var i = 0; i < paths.Count; i++)
            {
                var s = paths[i][0];
                var t = paths[i][1];

                dic[s] = t;
            }

            var r = paths[0][0];
            while (dic.ContainsKey(r))
                r = dic[r];

            return r;
        }
    }
}
