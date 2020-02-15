using System;
using System.Collections;
using System.Collections.Generic;

namespace ForSolveProblem
{
    public class Problem5312 : IProblem
    {
        public void RunProblem()
        {
            var temp = NumOfSubarrays(new int[] { 2, 2, 2, 2, 5, 5, 5, 8 }, 3, 4);
            if (temp != 3) throw new Exception();

            temp = NumOfSubarrays(new int[] { 1, 1, 1, 1, 1 }, 1, 0);
            if (temp != 5) throw new Exception();

            temp = NumOfSubarrays(new int[] { 11, 13, 17, 23, 29, 31, 7, 5, 2, 3 }, 3, 5);
            if (temp != 6) throw new Exception();

            temp = NumOfSubarrays(new int[] { 7, 7, 7, 7, 7, 7, 7 }, 7, 7);
            if (temp != 1) throw new Exception();

            temp = NumOfSubarrays(new int[] { 4, 4, 4, 4 }, 4, 1);
            if (temp != 1) throw new Exception();
        }

        public int NumOfSubarrays(int[] arr, int k, int threshold)
        {
            var forReturn = 0;

            var sumTemp = 0;
            var queueTemp = new Queue<int>();
            foreach (var arrItem in arr)
            {
                queueTemp.Enqueue(arrItem);
                sumTemp += arrItem;

                if (queueTemp.Count == k)
                {
                    var avgTemp = sumTemp / k;

                    if (avgTemp >= threshold)
                        forReturn++;

                    var tempValue = queueTemp.Dequeue();
                    sumTemp -= tempValue;
                }
            }

            return forReturn;
        }
    }
}
