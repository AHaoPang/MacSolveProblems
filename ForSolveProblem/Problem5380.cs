using System;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem5380 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public IList<string> StringMatching(string[] words)
        {
            var res = new List<string>();
            var orderWords = words.OrderBy(i => i.Length).ToArray();

            for (var i = 0; i < orderWords.Length; i++)
            {
                var isSub = false;
                for (var j = i + 1; j < orderWords.Length; j++)
                {
                    if (-1 != orderWords[j].IndexOf(orderWords[i]))
                    {
                        isSub = true;
                        break;
                    }
                }

                if (isSub)
                    res.Add(orderWords[i]);
            }

            return res;
        }
    }
}
