using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem104 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int MaxDepth(TreeNode root)
        {
            if (root == null) return 0;

            Queue<TreeNode> oneQueue = new Queue<TreeNode>();
            Queue<TreeNode> twoQueue = new Queue<TreeNode>();

            oneQueue.Enqueue(root);
            int maxDeepth = 1;

            while (oneQueue.Count > 0)
            {
                var nodeTemp = oneQueue.Dequeue();

                if (nodeTemp.left != null)
                    twoQueue.Enqueue(nodeTemp.left);

                if (nodeTemp.right != null)
                    twoQueue.Enqueue(nodeTemp.right);

                if(oneQueue.Count == 0 && twoQueue.Count != 0)
                {
                    var temp = oneQueue;
                    oneQueue = twoQueue;
                    twoQueue = temp;
                    maxDeepth++;
                }
            }

            return maxDeepth;
        }

        private int max = 0;
        public void DFS(TreeNode root,int deepth)
        {
            if (root == null)
            {
                max = max > deepth ? max : deepth;
                return;
            }

            DFS(root.left, deepth + 1);
            DFS(root.right, deepth + 1);
        }

        public class TreeNode
        {
            public int val;

            public TreeNode left;

            public TreeNode right;

            public TreeNode(int x) { val = x; }
        }

        private int Way1(TreeNode root)
        {
            //临界条件
            if (root == null) return 0;

            //递归条件
            int leftMax = MaxDepth(root.left) + 1;
            int rightMax = MaxDepth(root.right) + 1;

            //返回值
            return leftMax > rightMax ? leftMax : rightMax;
        }
    }
}
