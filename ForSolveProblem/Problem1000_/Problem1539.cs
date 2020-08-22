using System;
namespace ForSolveProblem
{
    public class Problem1539 : IProblem
    {
        public void RunProblem()
        {
            var temp = FindKthPositive(new[] { 2, 3, 4, 7, 11 }, 5);
            if (temp != 9) throw new Exception();

            temp = FindKthPositive(new[] { 1, 2, 3, 4 }, 2);
            if (temp != 6) throw new Exception();
        }

        public int FindKthPositive(int[] arr, int k)
        {
            var c = 0;
            var arrIndex = 0;
            for (var i = 1; i <= 1000; i++)
            {
                if (arrIndex < arr.Length)
                {
                    if (i == arr[arrIndex])
                    {
                        arrIndex++;
                        continue;
                    }
                }

                c++;
                if (k == c) return i;
            }

            return -1;
        }
    }
}
