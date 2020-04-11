using System;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem976 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int LargestPerimeter(int[] A)
        {
            var orderArr = A.OrderByDescending(i => i).ToList();

            for (var i = 0; i < A.Length - 2; i++)
                if (orderArr[i] < orderArr[i + 1] + orderArr[i + 2])
                    return orderArr[i] + orderArr[i + 1] + orderArr[i + 2];

            return 0;
        }
    }
}
