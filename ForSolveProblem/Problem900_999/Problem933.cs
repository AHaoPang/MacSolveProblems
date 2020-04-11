using System;
using System.Collections.Generic;

namespace ForSolveProblem
{
    public class Problem933 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public class RecentCounter
        {
            private Queue<int> m_queue;

            public RecentCounter()
            {
                m_queue = new Queue<int>((int)1e4);
            }

            public int Ping(int t)
            {
                m_queue.Enqueue(t);

                while (m_queue.Peek() < t - 3000)
                    m_queue.Dequeue();

                return m_queue.Count;
            }
        }
    }
}
