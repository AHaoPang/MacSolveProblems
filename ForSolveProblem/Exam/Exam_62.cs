using System;
namespace ForSolveProblem
{
    public class Exam_62 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int LastRemaining(int n, int m)
        {
            var res = 0;
            for (var i = 2; i <= n; i++)
                res = (res + m) % i;

            return res;
        }
    }
}
