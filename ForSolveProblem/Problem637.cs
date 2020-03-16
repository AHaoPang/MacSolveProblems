using System;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem637 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public IList<double> AverageOfLevels(TreeNode root)
        {
            var forReturn = new List<double>();
            if (root == null) return forReturn;

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Any())
            {
                var newQueue = new Queue<TreeNode>();
                var sum = 0L;
                var count = queue.Count;
                while (queue.Any())
                {
                    var curNode = queue.Dequeue();
                    sum += curNode.val;

                    if (curNode.left != null)
                        newQueue.Enqueue(curNode.left);
                    if (curNode.right != null)
                        newQueue.Enqueue(curNode.right);
                }

                forReturn.Add(1.0 * sum / count);

                if (newQueue.Any())
                    queue = newQueue;
            }

            return forReturn;
        }
    }
}
