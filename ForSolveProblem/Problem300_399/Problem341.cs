using System;
using System.Collections.Generic;

namespace ForSolveProblem
{
    public class Problem341 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public interface NestedInteger
        {

            // @return true if this NestedInteger holds a single integer, rather than a nested list.
            bool IsInteger();

            // @return the single integer that this NestedInteger holds, if it holds a single integer
            // Return null if this NestedInteger holds a nested list
            int GetInteger();

            // @return the nested list that this NestedInteger holds, if it holds a nested list
            // Return null if this NestedInteger holds a single integer
            IList<NestedInteger> GetList();
        }

        public class NestedIterator
        {
            private IList<int> m_res;
            private int m_curIndex;

            public NestedIterator(IList<NestedInteger> nestedList)
            {
                m_res = new List<int>();
                m_curIndex = 0;

                foreach (var item in nestedList)
                    Dfs(item);
            }

            private void Dfs(NestedInteger ni)
            {
                if (ni.IsInteger())
                {
                    m_res.Add(ni.GetInteger());
                    return;
                }

                foreach (var item in ni.GetList())
                    Dfs(item);
            }

            public bool HasNext() => m_curIndex < m_res.Count;

            public int Next() => m_res[m_curIndex++];
        }
    }
}
