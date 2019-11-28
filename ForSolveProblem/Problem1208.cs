using System;
using System.Collections.Generic;

namespace ForSolveProblem
{
    public class Problem1208 : IProblem
    {
        public void RunProblem()
        {
            var temp = EqualSubstring("abcd", "bcdf", 3);
            if (temp != 3) throw new Exception();

            temp = EqualSubstring("abcd", "cdef", 3);
            if (temp != 1) throw new Exception();

            temp = EqualSubstring("abcd", "acde", 0);
            if (temp != 1) throw new Exception();
        }

        public int EqualSubstring(string s, string t, int maxCost)
        {
            var maxLength = 0;

            var queueTemp = new Queue<int>();
            var curCost = 0;
            for (int endIndex = 0; endIndex < t.Length; endIndex++)
            {
                var costTemp = Math.Abs(s[endIndex] - t[endIndex]);

                queueTemp.Enqueue(costTemp);
                curCost += costTemp;

                while (curCost > maxCost)
                {
                    var costSubTemp = queueTemp.Dequeue();
                    curCost -= costSubTemp;
                }

                maxLength = Math.Max(maxLength, queueTemp.Count);
            }

            return maxLength;
        }
    }
}
