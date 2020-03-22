using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class Exam_40 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int[] GetLeastNumbers(int[] arr, int k)
        {
            var pq = new PriorityQueue<int>(true, k);
            foreach (var arrItem in arr)
            {
                if (pq.Count < k)
                {
                    pq.AddData(arrItem);
                }
                else if (pq.PeekData() > arrItem)
                {
                    pq.GetData();
                    pq.AddData(arrItem);
                }
            }

            var forReturn = new int[k];
            var i = 0;
            while (pq.HasData())
                forReturn[i++] = pq.GetData();
            return forReturn;
        }

        public int[] GetLeastNumbers1(int[] arr, int k)
        {
            return arr.OrderBy(i => i).Take(k).ToArray();
        }
    }
}
