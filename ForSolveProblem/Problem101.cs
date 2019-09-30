using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem101 : IProblem
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public bool IsSymmetric(TreeNode root)
        {
            /*
             * 使用类似广度优先的思路来处理：
             * 队列的每一层，一定是偶数个，每次从队列中取出来2个做比较，镜像的前提是，值相等，然后把下一轮要比较的子树塞入到队列中
             * 
             * 时间复杂度：O(n)，就是把树都遍历一遍
             * 空间复杂度：O(n)，因为可能会把树的节点都存到队列一次，树越高，所需的存储空间就越大
             */

            if (root == null) return true;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root.left);
            queue.Enqueue(root.right);

            while (queue.Count > 0)
            {
                var nodeLeft = queue.Dequeue();
                var nodeRight = queue.Dequeue();

                if (nodeLeft == null && nodeRight == null) continue;
                if (nodeLeft == null || nodeRight == null) return false;
                if (nodeLeft.val != nodeRight.val) return false;

                queue.Enqueue(nodeLeft.left);
                queue.Enqueue(nodeRight.right);
                queue.Enqueue(nodeLeft.right);
                queue.Enqueue(nodeRight.left);
            }

            return true;
        }

        public bool IsSymmetric2(TreeNode root)
        {
            /*
             * 使用递归的方式，将大的问题逐渐的分解为小的问题
             * 
             * 时间复杂度：O(n)，即最多把树整个遍历了一遍
             * 空间复杂度：O(n)，调用栈的数据存储
             */

            if (root == null) return true;
            return IsMirror(root.left, root.right);
        }

        private bool IsMirror(TreeNode nodeFrom, TreeNode nodeTo)
        {
            if (nodeFrom == null && nodeTo == null) return true;
            if (nodeFrom == null || nodeTo == null) return false;

            return nodeFrom.val == nodeTo.val && IsMirror(nodeFrom.left, nodeTo.right) && IsMirror(nodeFrom.right, nodeTo.left);
        }
    }
}
