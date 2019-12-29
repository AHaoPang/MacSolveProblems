using System;
using System.Threading;

namespace ForSolveProblem
{
    public class Problem1115
    {
        public Problem1115()
        {
        }

        public class FooBar
        {
            private int n;
            private SemaphoreSlim semapBar;
            private SemaphoreSlim semapFoo;

            public FooBar(int n)
            {
                this.n = n;
                semapFoo = new SemaphoreSlim(1, 1);
                semapBar = new SemaphoreSlim(0, 1);
            }

            public void Foo(Action printFoo)
            {

                for (int i = 0; i < n; i++)
                {
                    semapFoo.Wait();
                    // printFoo() outputs "foo". Do not change or remove this line.
                    printFoo();
                    semapBar.Release();
                }
            }

            public void Bar(Action printBar)
            {

                for (int i = 0; i < n; i++)
                {
                    semapBar.Wait();
                    // printBar() outputs "bar". Do not change or remove this line.
                    printBar();
                    semapFoo.Release();
                }
            }
        }

        public class FooBar2
        {
            private int n;
            Semaphore foos = new Semaphore(1, 1);
            Semaphore bars = new Semaphore(0, 1);

            public FooBar2(int n)
            {
                this.n = n;
            }

            public void Foo(Action printFoo)
            {

                for (int i = 0; i < n; i++)
                {
                    foos.WaitOne();
                    // printFoo() outputs "foo". Do not change or remove this line.
                    printFoo();
                    bars.Release(1);

                }
            }

            public void Bar(Action printBar)
            {

                for (int i = 0; i < n; i++)
                {

                    // printBar() outputs "bar". Do not change or remove this line.
                    bars.WaitOne();
                    printBar();
                    foos.Release(1);
                }
            }
        }
    }
}
