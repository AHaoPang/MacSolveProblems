using System;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem5480 : IProblem
    {
        public void RunProblem()
        {
            var temp = FindSmallestSetOfVertices(6, new List<IList<int>>()
            {
                new List<int>(){0,1},
                new List<int>(){0,2},
                new List<int>(){2,5},
                new List<int>(){3,4},
                new List<int>(){4,2},
            });

            if (ProblemHelper.ArrayEqual(new[] { 0, 3 }, temp)) throw new Exception();
        }

        public IList<int> FindSmallestSetOfVertices(int n, IList<IList<int>> edges)
        {
            var numArr = new int[n];
            foreach (var edgeItem in edges)
                numArr[edgeItem[1]]++;

            var res = new List<int>();
            for (var i = 0; i < numArr.Length; i++)
                if (numArr[i] == 0) res.Add(i);

            return res;
        }
    }
}
