using System;
using System.Threading;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem1116:IProblem
    {
        public void RunProblem()
        {
            var oddTemp = new ZeroEvenOdd(2);

            Action a1 = () => oddTemp.Zero((i) => Console.WriteLine($"{i}"));
            Action a2 = () => oddTemp.Even((i) => Console.WriteLine($"{i}"));
            Action a3 = () => oddTemp.Odd((i) => Console.WriteLine($"{i}"));

            Task.Run(a1);
            Task.Run(a2);
            Task.Run(a3);

            Console.ReadKey();
        }

        public class ZeroEvenOdd
        {
            AutoResetEvent atEven = new AutoResetEvent(false);
            AutoResetEvent atOdd = new AutoResetEvent(false);
            AutoResetEvent atZero = new AutoResetEvent(false);

            private int n;
            private int initNum;

            public ZeroEvenOdd(int n)
            {
                this.n = n;
                initNum = 1;
                atZero.Set();
            }

            // printNumber(x) outputs "x", where x is an integer.
            public void Zero(Action<int> printNumber)
            {
                while (initNum <= n)
                {
                    atZero.WaitOne();
                    if (initNum > n)
                    {
                        atEven.Set();
                        atOdd.Set();
                        break;
                    }

                    printNumber(0);
                    if (initNum % 2 == 0)
                        atEven.Set();
                    else
                        atOdd.Set();
                }
            }

            public void Even(Action<int> printNumber)
            {
                while (initNum <= n)
                {
                    atEven.WaitOne();
                    if (initNum > n) break;

                    printNumber(initNum);
                    initNum++;

                    atZero.Set();
                }
            }

            public void Odd(Action<int> printNumber)
            {
                while (initNum <= n)
                {
                    atOdd.WaitOne();
                    if (initNum > n) break;

                    printNumber(initNum);
                    initNum++;

                    atZero.Set();
                }
            }
        }
    }
}
