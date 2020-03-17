using System;
namespace ForSolveProblem
{
    public class Problem605 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public bool CanPlaceFlowers(int[] flowerbed, int n)
        {
            for (var i = 0; i < flowerbed.Length; i++)
            {
                if (n == 0)
                    break;

                if (flowerbed[i] == 1)
                    continue;

                var leftOk = true;
                if (i - 1 >= 0 && flowerbed[i - 1] != 0)
                    leftOk = false;

                var rightOk = true;
                if (i + 1 < flowerbed.Length && flowerbed[i + 1] != 0)
                    rightOk = false;

                if (leftOk && rightOk)
                {
                    n--;
                    flowerbed[i] = 1;
                }
            }

            return n == 0;
        }
    }
}
