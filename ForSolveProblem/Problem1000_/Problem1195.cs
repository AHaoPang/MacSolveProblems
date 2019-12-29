using System;
using System.Threading;

namespace ForSolveProblem
{
    public class Problem1195 : IProblem
    {
        public void RunProblem()
        {
            SemaphoreSlim semapSlim = new SemaphoreSlim(1);

            semapSlim.Wait();

            semapSlim.Release();
        }

        public class FizzBuzz
        {
            private int n;
            private static readonly object lockObj = new object();
            private int startNum;

            public FizzBuzz(int n)
            {
                this.n = n;
                startNum = 1;
            }

            private void CommonPrint(Func<int, bool> canChange, Action ac)
            {
                while (startNum <= n)
                {
                    lock (lockObj)
                    {
                        if (startNum <= n && canChange(startNum))
                        {
                            ac();
                            startNum++;
                        }
                    }
                }
            }

            // printFizz() outputs "fizz".
            public void Fizz(Action printFizz) => CommonPrint((num) => num % 3 == 0 && num % 5 != 0, printFizz);

            // printBuzzz() outputs "buzz".
            public void Buzz(Action printBuzz) => CommonPrint((num) => num % 5 == 0 && num % 3 != 0, printBuzz);

            // printFizzBuzz() outputs "fizzbuzz".
            public void Fizzbuzz(Action printFizzBuzz) => CommonPrint((num) => num % 5 == 0 && num % 3 == 0, printFizzBuzz);

            // printNumber(x) outputs "x", where x is an integer.
            public void Number(Action<int> printNumber)
            {
                while (startNum <= n)
                {
                    lock (lockObj)
                    {
                        if (startNum <= n && startNum % 5 != 0 && startNum % 3 != 0)
                            printNumber(startNum++);
                    }
                }
            }
        }
    }
}
