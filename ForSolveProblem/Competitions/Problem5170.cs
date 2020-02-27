using System;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem5170 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public bool ValidateBinaryTreeNodes(int n, int[] leftChild, int[] rightChild)
        {
            var visitedSet = new HashSet<int>();

            var queueTemp = new Queue<int>();
            queueTemp.Enqueue(0);

            while (queueTemp.Any())
            {
                var curIndex = queueTemp.Dequeue();

                if (visitedSet.Contains(curIndex))
                    return false;

                visitedSet.Add(curIndex);

                var leftIndex = leftChild[curIndex];
                if (leftIndex != -1)
                    queueTemp.Enqueue(leftIndex);

                var rightIndex = rightChild[curIndex];
                if (rightIndex != -1)
                    queueTemp.Enqueue(rightIndex);
            }

            return visitedSet.Count == n;
        }
    }
}
