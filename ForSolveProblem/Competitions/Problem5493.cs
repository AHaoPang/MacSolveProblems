using System;
namespace ForSolveProblem
{
    public class Problem5493 : IProblem
    {
        public Problem5493()
        {
        }

        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int FindLengthOfShortestSubarray(int[] arr)
        {
            var l = -1;
            for (var i = 1; i < arr.Length; i++)
            {
                if (arr[i] < arr[i - 1])
                {
                    l = i;
                    break;
                }
            }
            if (l == -1)
                return 0;

            var r = arr.Length;
            for (var j = arr.Length - 2; j >= 0; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    r = j;
                    break;
                }
            }

            while (true)
            {
                if (l == 0 || r == arr.Length - 1)
                    return r - l;

                if (arr[l] > arr[r] && arr[l - 1] > arr[r])
                    r++;

                if (arr[r] < arr[l] && arr[r + 1] < arr[l])
                    l++;

                if (arr[l] <= arr[r])
                    return r - l - 1;
            }
        }
    }
}
