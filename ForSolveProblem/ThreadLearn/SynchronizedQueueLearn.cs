using System;
using System.Collections.Generic;
using System.Threading;

namespace ForSolveProblem
{
    public class SynchronizedQueueLearn : IProblem
    {
        public SynchronizedQueueLearn()
        {
        }

        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        internal sealed class SynchronizedQueue<T>
        {
            private readonly object m_lock = new object();
            private readonly Queue<T> m_queue = new Queue<T>();

            public void Enqueue(T item)
            {
                Monitor.Enter(m_lock);

                m_queue.Enqueue(item);
                Monitor.PulseAll(m_lock);

                Monitor.Exit(m_lock);
            }

            public T Dequeue()
            {
                Monitor.Enter(m_lock);

                while (m_queue.Count == 0)
                    Monitor.Wait(m_lock);

                var item = m_queue.Dequeue();
                Monitor.Exit(m_lock);
                return item;
            }
        }
    }
}
