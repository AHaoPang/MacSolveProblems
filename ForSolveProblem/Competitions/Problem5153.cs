using System;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem5153 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

        public int DeepestLeavesSum(TreeNode root)
        {
            var forReturn = 0;

            var queueStart = new Queue<TreeNode>();
            queueStart.Enqueue(root);
            var newQueue = new Queue<TreeNode>();

            while (queueStart.Any())
            {
                var curNode = queueStart.Dequeue();

                forReturn += curNode.val;

                if (curNode.left != null) newQueue.Enqueue(curNode.left);
                if (curNode.right != null) newQueue.Enqueue(curNode.right);

                if(queueStart.Count == 0 && newQueue.Any())
                {
                    forReturn = 0;
                    queueStart = newQueue;
                    newQueue = new Queue<TreeNode>();
                }
            }

            return forReturn;
        }
    }
}
