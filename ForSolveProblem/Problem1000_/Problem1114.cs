using System;
namespace ForSolveProblem
{
    public class Problem1114
    {
        public Problem1114()
        {
        }

        public class Foo
        {

            private bool startSecond;
            private bool startThird;

            public Foo()
            {
                startSecond = false;
                startThird = false;
            }

            public void First(Action printFirst)
            {

                // printFirst() outputs "first". Do not change or remove this line.
                printFirst();
                startSecond = true;
            }

            public void Second(Action printSecond)
            {
                while (!startSecond) { }

                // printSecond() outputs "second". Do not change or remove this line.
                printSecond();
                startThird = true;
            }

            public void Third(Action printThird)
            {
                while (!startThird) { }

                // printThird() outputs "third". Do not change or remove this line.
                printThird();
            }
        }

        public class Foo2
        {

            public Foo2()
            {

            }

            private System.Threading.Semaphore sem1 = new System.Threading.Semaphore(0, 1);
            private System.Threading.Semaphore sem2 = new System.Threading.Semaphore(0, 1);

            public void First(Action printFirst)
            {

                // printFirst() outputs "first". Do not change or remove this line.
                printFirst();
                sem1.Release(1);
            }

            public void Second(Action printSecond)
            {

                // printSecond() outputs "second". Do not change or remove this line.

                sem1.WaitOne();

                printSecond();
                sem2.Release(1);
            }

            public void Third(Action printThird)
            {

                // printThird() outputs "third". Do not change or remove this line.
                sem2.WaitOne();
                printThird();
            }
        }

        public class Foo3
        {
            public Foo3()
            {

            }
            System.Threading.AutoResetEvent _waitHandle = new System.Threading.AutoResetEvent(false);
            System.Threading.AutoResetEvent _waitHandle2 = new System.Threading.AutoResetEvent(false);
            public void First(Action printFirst)
            {

                // printFirst() outputs "first". Do not change or remove this line.
                printFirst();
                _waitHandle.Set();
            }

            public void Second(Action printSecond)
            {

                _waitHandle.WaitOne();


                // printSecond() outputs "second". Do not change or remove this line.
                printSecond();
                _waitHandle2.Set();
            }

            public void Third(Action printThird)
            {
                _waitHandle2.WaitOne();
                // printThird() outputs "third". Do not change or remove this line.
                printThird();
            }
        }
    }
}
