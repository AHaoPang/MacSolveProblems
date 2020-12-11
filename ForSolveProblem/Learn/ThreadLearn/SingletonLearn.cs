using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class SingletonLearn : IProblem
    {
        public SingletonLearn()
        {
        }

        public void RunProblem()
        {
            _ = Example2();
        }

        private async Task Example1()
        {
            var numArr = Enumerable.Range(0, 5).ToList();
            var singleArr = new Singleton[numArr.Count];
            var taskList = new List<Task>();
            foreach (var numitem in numArr)
            {
                var t = Task.Run(() => singleArr[numitem] = Singleton.GetSingleton());
                taskList.Add(t);
            }

            await Task.WhenAll(taskList.ToArray());

            Console.WriteLine("All done.");
        }

        public sealed class Singleton
        {
            private static object s_lock = new object();

            private static Singleton s_value;

            private Singleton() { }

            public static Singleton GetSingleton()
            {
                Console.WriteLine("come in");
                if (s_value != null) return s_value;

                Monitor.Enter(s_lock);
                Console.WriteLine("enter");
                if (s_value == null)
                {
                    Console.WriteLine("set");
                    var singleton = new Singleton();
                    Volatile.Write(ref s_value, singleton);
                }
                Monitor.Exit(s_lock);

                return s_value;
            }
        }

        private async Task Example2()
        {
            var numArr = Enumerable.Range(0, 5).ToList();
            var singleArr = new Singleton2[numArr.Count];
            var taskList = new List<Task>();
            foreach (var numitem in numArr)
            {
                var t = Task.Run(() => singleArr[numitem] = Singleton2.Instance);
                taskList.Add(t);
            }

            await Task.WhenAll(taskList.ToArray());

            //Singleton2.Instance = null;

            Console.WriteLine("All done.");
        }

        internal sealed class Singleton2
        {
            //private static Singleton2 s_value = new Singleton2();

            private DateTime m_dt;
            private Singleton2()
            {
                Console.WriteLine("concor.");
                m_dt = DateTime.Now;
            }

            public static readonly Singleton2 Instance = new Singleton2();
        }

        internal sealed class Singleton3
        {
            private Singleton3 m_value;
            private Singleton3() { }

            private Singleton3 GetSingleton()
            {
                if (m_value != null) return m_value;

                var v = new Singleton3();
                Interlocked.CompareExchange(ref m_value, v, null);

                return m_value;
            }
        }
    }
}
