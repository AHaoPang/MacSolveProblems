using System;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem821 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int[] ShortestToChar(string S, char C)
        {
            var res = new int[S.Length];
            var prev = -1;
            for (var i = 0; i < S.Length; i++)
            {
                if (S[i] == C)
                    prev = i;
                else if (prev != -1)
                    res[i] = i - prev;
                else
                    res[i] = int.MaxValue;
            }

            var last = S.Length;
            for (var j = S.Length - 1; j >= 0; j--)
            {
                if (S[j] == C)
                    last = j;
                else if (last != S.Length)
                    res[j] = Math.Min(res[j], last - j);
            }

            return res;
        }

        public int[] ShortestToChar1(string S, char C)
        {
            var res = Enumerable.Repeat(-1, S.Length).ToArray();
            var queue = new Queue<int[]>();
            for (var i = 0; i < S.Length; i++)
            {
                if (S[i] != C) continue;

                res[i] = 0;
                queue.Enqueue(new[] { i, 0 });
            }

            var numArray = new[] { -1, 1 };
            while (queue.Any())
            {
                var curArray = queue.Dequeue();
                var curIndex = curArray[0];
                var curValue = curArray[1];
                foreach (var v in numArray)
                {
                    var newPos = curIndex + v;
                    if (newPos >= 0 && newPos < S.Length && res[newPos] == -1)
                    {
                        res[newPos] = curValue + 1;
                        queue.Enqueue(new[] { newPos, curValue + 1 });
                    }
                }
            }

            return res;
        }
    }
}
