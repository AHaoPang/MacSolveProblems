using System;
namespace ForSolveProblem
{
    public class Problem896 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public bool IsMonotonic(int[] A)
        {
            var curSub = int.MinValue;
            for (var i = 0; i < A.Length - 1; i++)
            {
                var sub = A[i] - A[i + 1];
                if (sub == 0) continue;

                if (curSub == int.MinValue)
                {
                    curSub = sub;
                    continue;
                }

                if (curSub * sub < 0)
                    return false;
            }

            return true;
        }
    }
}
