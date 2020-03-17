using System;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem559 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int MaxDepth(Node root)
        {
            var forReturn = 0;
            if (root == null) return forReturn;

            var queue = new Queue<Node>();
            queue.Enqueue(root);
            while (queue.Any())
            {
                forReturn++;
                var newQueue = new Queue<Node>();
                while (queue.Any())
                {
                    var curNode = queue.Dequeue();

                    if (curNode != null && curNode.children != null)
                        foreach (var nodeItem in curNode.children)
                            newQueue.Enqueue(nodeItem);
                }

                if (newQueue.Any())
                    queue = newQueue;
            }

            return forReturn;
        }
    }
}
