using System;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem993 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public bool IsCousins(TreeNode root, int x, int y)
        {
            var targetSet = new HashSet<int>() { x, y };
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Any())
            {
                var nextQueue = new Queue<TreeNode>();
                var curValueSet = new HashSet<int>(queue.Count);
                while (queue.Any())
                {
                    var curNode = queue.Dequeue();
                    curValueSet.Add(curNode.val);

                    if (curNode.left != null)
                        nextQueue.Enqueue(curNode.left);

                    if (curNode.right != null)
                        nextQueue.Enqueue(curNode.right);

                    if (curNode.left != null && curNode.right != null && targetSet.Contains(curNode.left.val) && targetSet.Contains(curNode.right.val))
                        return false;
                }

                if (curValueSet.Contains(x) && curValueSet.Contains(y))
                    return true;

                if (nextQueue.Any())
                    queue = nextQueue;
            }

            return false;
        }
    }
}
