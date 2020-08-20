using System;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class ConcurrentExclusiveSchedulerPairLearn : IProblem
    {
        public ConcurrentExclusiveSchedulerPairLearn()
        {
        }

        public void RunProblem()
        {
            Example1();
        }

        public void Example1()
        {
            var cesp = new ConcurrentExclusiveSchedulerPair();
            var tfExclusive = new TaskFactory(cesp.ExclusiveScheduler);
            var tfConcurrent = new TaskFactory(cesp.ConcurrentScheduler);

            for (var i = 0; i < 100; i++)
            {
                if (i > 50)
                    tfExclusive.StartNew(() => Console.WriteLine("excluesive access"));
                else
                    tfConcurrent.StartNew(() => Console.WriteLine("concurrent access"));
            }
        }
    }
}
