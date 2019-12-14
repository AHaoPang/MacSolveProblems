using System;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem306 : IProblem
    {
        public void RunProblem()
        {
            var temp = IsAdditiveNumber("112358");
            if (!temp) throw new Exception();

            temp = IsAdditiveNumber("199100199");
            if (!temp) throw new Exception();

            temp = IsAdditiveNumber("10");
            if (temp != false) throw new Exception();
        }

        public bool IsAdditiveNumber(string num)
        {
            var numArray = num.Select(i => int.Parse(i.ToString())).ToArray();
            for (int i = 0; i < numArray.Length / 2; i++)
            {
                if (i != 0 && numArray[0] == 0) break;

                var j = i + 1;
                var limit = j + numArray.Length / 2;
                if (limit > numArray.Length) limit = numArray.Length;
                for (; j < limit; j++)
                {
                    if (numArray[i + 1] == 0 && j != i + 1) break;

                    var numPrev = numArray.Take(i + 1).ToArray();
                    var numNext = numArray.Skip(i + 1).Take(j - i).ToArray();

                    var resultTemp = Recursion(numArray, numPrev, numNext, j + 1, 2);
                    if (resultTemp) return true;
                }
            }

            return false;
        }

        private bool Recursion(int[] numArray, int[] prev, int[] next, int newStart, int readyCount)
        {
            if (newStart == numArray.Length && readyCount > 2) return true;

            var expectNum = SumTwoArray(prev, next);
            var realNum = numArray.Skip(newStart).Take(expectNum.Length).ToArray();
            if (!AreEqual(expectNum, realNum)) return false;

            return Recursion(numArray, next, realNum, newStart + expectNum.Length, readyCount + 1);
        }

        private int[] SumTwoArray(int[] prev, int[] next)
        {
            var length = Math.Max(prev.Length, next.Length);
            var sum = new int[length + 1];

            var prevIndex = prev.Length - 1;
            var nextIndex = next.Length - 1;
            var sumIndex = sum.Length - 1;
            var sumTemp = 0;
            while (prevIndex >= 0 || nextIndex >= 0)
            {
                var prevTemp = 0;
                if (prevIndex >= 0) prevTemp = prev[prevIndex--];

                var nextTemp = 0;
                if (nextIndex >= 0) nextTemp = next[nextIndex--];

                sumTemp += prevTemp + nextTemp;
                sum[sumIndex--] = sumTemp % 10;
                sumTemp /= 10;
            }
            if (sumTemp != 0) sum[0] = sumTemp;

            return sum[0] == 0 ? sum.Skip(1).Take(sum.Length - 1).ToArray() : sum;
        }

        private bool AreEqual(int[] one, int[] two)
        {
            if (one.Length != two.Length) return false;

            for (int i = 0; i < one.Length; i++)
                if (one[i] != two[i]) return false;

            return true;
        }
    }
}
