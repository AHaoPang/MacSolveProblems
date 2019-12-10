using System;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem842 : IProblem
    {
        public void RunProblem()
        {
            var temp = SplitIntoFibonacci("123456579");
            if (!ProblemHelper.ArrayIsEqual(temp.ToArray(), new int[] { 123, 456, 579 })) throw new Exception();

            temp = SplitIntoFibonacci("11235813");
            if (!ProblemHelper.ArrayIsEqual(temp.ToArray(), new int[] { 1, 1, 2, 3, 5, 8, 13 })) throw new Exception();

            temp = SplitIntoFibonacci("112358130");
            if (!ProblemHelper.ArrayIsEqual(temp.ToArray(), new int[] { })) throw new Exception();

            temp = SplitIntoFibonacci("0123");
            if (!ProblemHelper.ArrayIsEqual(temp.ToArray(), new int[] { })) throw new Exception();

            temp = SplitIntoFibonacci("1101111");
            if (!ProblemHelper.ArrayIsEqual(temp.ToArray(), new int[] { 110, 1, 111 })) throw new Exception();
        }

        public IList<int> SplitIntoFibonacci(string S)
        {
            var numArray = S.Select(i => int.Parse(i.ToString())).ToArray();

            var prevValue = 0L;
            var iLimit = numArray.Length - 1;
            if (numArray[0] == 0 && iLimit > 1) iLimit = 1;
            for (int i = 0; i < iLimit; i++)
            {
                prevValue = prevValue * 10 + numArray[i];
                if (prevValue > int.MaxValue) break;

                var nextValue = 0L;
                var jLimit = numArray.Length;
                if (numArray[i + 1] == 0 && jLimit > i + 2) jLimit = i + 2;
                for (int j = i + 1; j < jLimit; j++)
                {
                    nextValue = nextValue * 10 + numArray[j];
                    if (nextValue > int.MaxValue) break;

                    var queueTemp = new Queue<long>();
                    queueTemp.Enqueue(prevValue);
                    queueTemp.Enqueue(nextValue);
                    var resultTemp = Recursion(numArray, j, prevValue, nextValue, queueTemp);
                    if (resultTemp && queueTemp.Count >= 3) return queueTemp.Select(item => (int)item).ToList();
                }
            }

            return new List<int>();
        }

        private bool Recursion(int[] numArray, int lastIndex, long prev, long next, Queue<long> queueTemp)
        {
            if (numArray.Length - 1 == lastIndex) return true;

            var expectNum = prev + next;
            var initValue = 0;
            var limitNum = numArray.Length;
            if (numArray[lastIndex + 1] == 0 && limitNum > lastIndex + 2) limitNum = lastIndex + 2;
            for (int i = lastIndex + 1; i < limitNum; i++)
            {
                initValue = initValue * 10 + numArray[i];
                if (initValue > int.MaxValue) break;
                if (initValue > expectNum) break;

                if (initValue == expectNum)
                {
                    queueTemp.Enqueue(initValue);
                    return Recursion(numArray, i, next, initValue, queueTemp);
                }
            }

            return false;
        }
    }
}
