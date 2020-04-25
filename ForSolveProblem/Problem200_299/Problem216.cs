using System;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem216 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public IList<IList<int>> CombinationSum3(int k, int n)
        {
            Recursive(new List<int>(), k, n, 1);
            return m_res;
        }

        private IList<IList<int>> m_res = new List<IList<int>>();

        private void Recursive(List<int> curList, int k, int n, int curStart)
        {
            if (k == 0)
            {
                if (n == 0)
                    m_res.Add(new List<int>(curList));
                return;
            }

            if (n < curStart) return;

            for (var i = curStart; i < 10 - k + 1; i++)
            {
                curList.Add(i);
                Recursive(curList, k - 1, n - i, i + 1);
                curList.RemoveAt(curList.Count - 1);
            }
        }
    }
}
