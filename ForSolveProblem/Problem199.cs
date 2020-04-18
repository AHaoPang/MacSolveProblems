using System;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem199 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public IList<int> RightSideView(TreeNode root)
        {
            var res = new List<int>();
            if (root == null) return res;

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Any())
            {
                var newQueue = new Queue<TreeNode>();
                var lastNum = 0;
                while (queue.Any())
                {
                    var curNode = queue.Dequeue();
                    lastNum = curNode.val;

                    if (curNode.left != null)
                        newQueue.Enqueue(curNode.left);
                    if (curNode.right != null)
                        newQueue.Enqueue(curNode.right);
                }

                res.Add(lastNum);
                if (newQueue.Any())
                    queue = newQueue;
            }

            return res;
        }
    }
}
