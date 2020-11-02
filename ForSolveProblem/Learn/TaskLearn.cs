using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ForSolveProblem
{
    public class TaskLearn : IProblem
    {
        public async void RunProblem()
        {
            ComputeUsage2();

            //AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
            //{
            //    Console.ForegroundColor = ConsoleColor.Cyan;
            //    Console.WriteLine(e.ExceptionObject.ToString());
            //};

            //try
            //{
            //    var t = await ThrowExceptionFunc();
            //    Console.WriteLine($"t = {t}");
            //}
            //catch (Exception e) when (LogMessage(e))
            //{
            //}
        }


        private static void Example1()
        {
            var tasks = new List<Task<int>>();
            var source = new CancellationTokenSource();
            var token = source.Token;
            int completedIterations = 0;

            for (int n = 0; n <= 19; n++)
                tasks.Add(Task.Run(() =>
                {
                    int iterations = 0;
                    for (int ctr = 1; ctr <= 2000000; ctr++)
                    {
                        token.ThrowIfCancellationRequested();
                        iterations++;
                    }

                    Interlocked.Increment(ref completedIterations);
                    if (completedIterations >= 10)
                        source.Cancel();

                    return iterations;
                }, token));

            Console.WriteLine("Waiting for the first 10 tasks to complete...\n");
            try
            {
                Task.WaitAll(tasks.ToArray());
            }
            catch (AggregateException)
            {
                Console.WriteLine("Status of tasks:\n");
                Console.WriteLine("{0,10} {1,20} {2,14:N0}", "Task Id",
                                  "Status", "Iterations");
                foreach (var t in tasks)
                    Console.WriteLine("{0,10} {1,20} {2,14}",
                    t.Id, t.Status,
                    t.Status != TaskStatus.Canceled ? t.Result.ToString("N0") : "n/a");
            }
        }

        private static void Example2()
        {
            Task[] tasks = new Task[2];
            String[] files = null;
            String[] dirs = null;
            String docsDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            tasks[0] = Task.Factory.StartNew(() => files = Directory.GetFiles(docsDirectory));
            tasks[1] = Task.Factory.StartNew(() => dirs = Directory.GetDirectories(docsDirectory));

            Task.Factory.ContinueWhenAll(tasks, completedTasks =>
            {
                Console.WriteLine("{0} contains: ", docsDirectory);
                Console.WriteLine("   {0} subdirectories", dirs.Length);
                Console.WriteLine("   {0} files", files.Length);
            });
        }

        private static async Task<int> ThrowExceptionFunc()
        {
            Func<int, int> f = i =>
            {
                Console.WriteLine("In SomeThing.");
                throw new ArgumentNullException("SomeThing Wrong.");
                return 100;
            };

            var r = await Task.Run(() => f(10));

            return r;
        }

        private bool LogMessage(Exception e)
        {
            Console.WriteLine(e);
            return false;
        }


        private async Task<int> GetLeftValue() => throw new KeyNotFoundException();

        private async Task<int> GetRightValue() => throw new KeyNotFoundException();

        private async Task<int> ComputeUsageAsync()
        {
            try
            {
                var v1 = await GetLeftValue();
                var v2 = await GetRightValue();

                return v1 + v2;
            }
            catch (KeyNotFoundException e)
            {
                return 0;
            }
        }

        public int ComputeUsage()
        {
            try
            {
                var v1 = GetLeftValue().Result;
                var v2 = GetRightValue().Result;

                return v1 + v2;
            }
            catch (AggregateException e)
            when (e.InnerExceptions.FirstOrDefault().GetType() == typeof(KeyNotFoundException))
            {
                return 0;
            }
        }

        public int ComputeUsage2()
        {
            try
            {
                var t1 = GetLeftValue();
                var t2 = GetRightValue();

                Task.WaitAll(t1, t2);

                return t1.Result;
            }
            catch (AggregateException e)
            when (e.InnerExceptions.FirstOrDefault().GetType() == typeof(KeyNotFoundException))
            {
                return 0;
            }
        }

        private static async Task SimulatedWorkAsync()
        {
            await Task.Delay(1000);
        }

        public static void SyncOverAsyncDeadlock()
        {
            var delayTask = SimulatedWorkAsync();

            delayTask.Wait();
        }
    }
}
