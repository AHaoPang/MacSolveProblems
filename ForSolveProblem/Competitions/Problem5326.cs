using System;
namespace ForSolveProblem
{
    public class Problem5326 : IProblem
    {
        public void RunProblem()
        {
            var temp = CountOrders(1);
            if (temp != 1) throw new Exception();

            temp = CountOrders(2);
            if (temp != 6) throw new Exception();

            temp = CountOrders(3);
            if (temp != 90) throw new Exception();
        }

        public int CountOrders(int n)
        {
            var forReturn = 1L;
            var constNum = (int)1e9 + 7;

            for (var i = 2; i <= n; i++)
            {
                var lastPosCount = (i - 1) * 2 + 1;
                long possibleNum = GetTotalCount(lastPosCount);

                forReturn = possibleNum * forReturn % constNum;
            }

            return (int)forReturn;
        }

        private int GetTotalCount(int i)
        {
            return (i + 1) * i / 2;
        }
    }
}
