using System;
using System.Threading;

namespace ForSolveProblem
{
    public class Problem1117 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public class H2O
        {
            public H2O()
            {
                totalNum = 0;
            }

            private int totalNum;
            private AutoResetEvent atH = new AutoResetEvent(true);
            private AutoResetEvent atO = new AutoResetEvent(false);

            public void Hydrogen(Action releaseHydrogen)
            {
                atH.WaitOne();

                // releaseHydrogen() outputs "H". Do not change or remove this line.
                releaseHydrogen();
                totalNum++;

                if (totalNum % 2 == 0)
                    atO.Set();
                else
                    atH.Set();
            }

            public void Oxygen(Action releaseOxygen)
            {
                atO.WaitOne();

                // releaseOxygen() outputs "O". Do not change or remove this line.
                releaseOxygen();

                atH.Set();
            }
        }
    }
}
