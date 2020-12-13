using System;
using System.Threading;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class MonitorLearn : IProblem
    {
        public MonitorLearn()
        {
        }

        public void RunProblem()
        {
            Example1();
        }

        private void Example1()
        {
            var cvp = new ConditionVariablePattern();

            Parallel.Invoke(cvp.Thread1, cvp.Thread2);

            Console.WriteLine("Example1 done.");
        }

        internal sealed class ConditionVariablePattern
        {
            private readonly object m_lock = new object();
            private bool m_condition = false;

            public void Thread1()
            {
                Monitor.Enter(m_lock);

                while (!m_condition)
                {
                    Console.WriteLine("Thread1 wait Before.");
                    Monitor.Wait(m_lock);
                }

                Console.WriteLine("Thread1 done!");

                Monitor.Exit(m_lock);
            }

            public void Thread2()
            {
                Monitor.Enter(m_lock);

                m_condition = true;

                Console.WriteLine("Thread2 pulse Before.");
                Monitor.Pulse(m_lock);

                Console.WriteLine("Thread2 done!");

                Monitor.Exit(m_lock);
            }
        }
    }
}
