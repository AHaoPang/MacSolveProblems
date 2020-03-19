using System;
using System.Collections.Generic;

namespace ForSolveProblem
{
    public class Problem5357 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public class CustomStack
        {
            private int m_maxSize;
            private int m_curSize;
            private LinkedList<int> m_linked;

            public CustomStack(int maxSize)
            {
                m_maxSize = maxSize;
                m_curSize = 0;
                m_linked = new LinkedList<int>();
            }

            public void Push(int x)
            {
                if (m_curSize == m_maxSize) return;

                m_curSize++;
                m_linked.AddLast(x);
            }

            public int Pop()
            {
                if (m_curSize == 0) return -1;

                m_curSize--;
                var forReturn = m_linked.Last.Value;
                m_linked.RemoveLast();

                return forReturn;
            }

            public void Increment(int k, int val)
            {
                if (m_curSize == 0) return;

                var firstNode = m_linked.First;
                for (var i = 1; i <= k && i <= m_curSize; i++)
                {
                    firstNode.Value += val;

                    firstNode = firstNode.Next;
                }
            }
        }
    }
}
