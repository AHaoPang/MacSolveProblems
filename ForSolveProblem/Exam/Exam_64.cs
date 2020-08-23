using System;
using System.Linq;

namespace ForSolveProblem
{
    public class Exam_64 : IProblem
    {

        public void RunProblem()
        {
            var temp = SumNums(3);
            if (temp != 6) throw new Exception();

            temp = SumNums(9);
            if (temp != 45) throw new Exception();
        }

        public int SumNums(int n)
        {
            var v = new SolutionCount(n);
            return v.GetSum();
        }

        private class SolutionCount
        {
            private bool isOk = true;
            private int totalNum;

            public SolutionCount(int n)
            {
                Dfs(n);
            }

            public bool Dfs(int n)
            {
                isOk = n > 1;
                totalNum += n;

                return isOk && Dfs(n - 1);
            }

            public int GetSum()
            {
                return totalNum;
            }
        }
    }
}
