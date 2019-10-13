using System;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem5224 : IProblem
    {
        public class calcEntity
        {
            public calcEntity(long lastNum)
            {
                this.totalNum = lastNum;
                queueMem = new Queue<long>();
                queueMem.Enqueue(lastNum);
            }

            public long totalNum;

            public long newNum;

            public long subNum;

            public Queue<long> queueMem;
        }

        public int DieSimulator(int n, int[] rollMax)
        {
            var constNum = unchecked((int)(1E9 + 7));

            var numQueueArray = new List<calcEntity>();
            for (int i = 0; i < 6; i++)
                numQueueArray.Add(new calcEntity(1));

            for (int i = 1; i < n; i++)
            {
                for (int a = 0; a < 6; a++)
                {
                    var sumTemp = 0L;
                    for (int b = 0; b < 6; b++)
                    {
                        if (a == b) continue;

                        sumTemp += numQueueArray[b].totalNum;
                        sumTemp %= constNum;
                    }

                    numQueueArray[a].queueMem.Enqueue(sumTemp);
                    numQueueArray[a].newNum = sumTemp;

                    if (numQueueArray[a].queueMem.Count > rollMax[a])
                    {
                        var v = numQueueArray[a].queueMem.Dequeue();
                        numQueueArray[a].subNum = v;
                    }
                }

                for (int c = 0; c < 6; c++)
                {
                    numQueueArray[c].totalNum += numQueueArray[c].newNum;
                    numQueueArray[c].totalNum -= numQueueArray[c].subNum;
                    numQueueArray[c].subNum = 0;
                }
            }

            var forReturn = 0L;
            foreach (var arrayItem in numQueueArray)
            {
                var tempValue = 0L;
                while (arrayItem.queueMem.Any())
                {
                    tempValue += arrayItem.queueMem.Dequeue();
                    tempValue %= constNum;
                }

                forReturn += tempValue;
                forReturn %= constNum;
            }

            return (int)forReturn;
        }

        public int DieSimulator1(int n, int[] rollMax)
        {
            var constNum = unchecked((int)(1E9 + 7));
            var countArray = new int[] { 1, 1, 1, 1, 1, 1 };

            var totalArray = new long[] { 1, 1, 1, 1, 1, 1 };

            for (int i = 1; i < n; i++)
            {
                var newArray = new long[6];

                for (int j = 0; j < 6; j++)
                {
                    for (int k = 0; k < 6; k++)
                    {
                        if (j == k) countArray[j]++;

                        if (countArray[j] > rollMax[j])
                        {
                            countArray[j] = 1;
                            continue;
                        }

                        newArray[j] += totalArray[k];
                        newArray[j] %= constNum;
                    }
                }

                totalArray = newArray;
            }

            long forReturn = 0;
            for (int i = 0; i < totalArray.Length; i++)
            {
                forReturn += totalArray[i];
                forReturn %= constNum;
            }

            return (int)forReturn;
        }

        public void RunProblem()
        {
            var temp = DieSimulator(2, new int[] { 1, 1, 2, 2, 2, 3 });
            if (temp != 34) throw new Exception();

            temp = DieSimulator(2, new int[] { 1, 1, 1, 1, 1, 1 });
            if (temp != 30) throw new Exception();

            temp = DieSimulator(3, new int[] { 1, 1, 1, 2, 2, 3 });
            if (temp != 181) throw new Exception();
        }
    }
}
