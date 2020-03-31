using System;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem5368 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int FindLucky(int[] arr)
        {
            var group = arr
                .GroupBy(i => i)
                .Where(i => i.Key == i.Count())
                .ToList();
            return group.Any() ? group.Max(i => i.Key) : -1;
        }
    }
}
