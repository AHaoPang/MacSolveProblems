using System;
namespace ForSolveProblem
{
    public class Problem605 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public bool CanPlaceFlowers1(int[] flowerbed, int n)
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

        public bool CanPlaceFlowers(int[] flowerbed, int n)
        {
            var newArr = new int[flowerbed.Length + 2];
            Array.Copy(flowerbed, 0, newArr, 1, flowerbed.Length);

            var count = 0;
            var leftIndex = 0;
            var rightIndex = 2;
            for (var i = 1; i <= flowerbed.Length; i++, leftIndex++, rightIndex++)
            {
                if (newArr[i] == 1) continue;

                if (newArr[leftIndex] == 0 && newArr[rightIndex] == 0)
                {
                    newArr[i] = 1;
                    count++;

                    if (count == n) break;
                }
            }

            return count >= n;
        }
    }
}
