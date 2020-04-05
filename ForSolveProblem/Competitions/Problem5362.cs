using System;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem5362 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public bool CanConstruct(string s, int k)
        {
            var minNum = s
                .GroupBy(i => i)
                .Count(i => i.Count() % 2 == 1);
            return k >= minNum && k <= s.Length;
        }
    }
}
