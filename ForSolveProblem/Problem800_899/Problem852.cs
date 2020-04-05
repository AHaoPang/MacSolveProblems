using System;
namespace ForSolveProblem
{
    public class Problem852 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int PeakIndexInMountainArray(int[] A)
        {
            var leftIndex = 0;
            var rightIndex = A.Length - 1;
            while (leftIndex < rightIndex)
            {
                var mid = leftIndex + (rightIndex - leftIndex) / 2;

                if (A[mid] < A[mid + 1])
                    leftIndex = mid + 1;
                else
                    rightIndex = mid;
            }

            return leftIndex;
        }
    }
}
