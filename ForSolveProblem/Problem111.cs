using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem111 : IProblem
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

        public int MinDepth(TreeNode root)
        {
            return BFS(root);
        }

        private int BFS(TreeNode root)
        {
            //临界条件判断
            if (root == null)
                return 0;

            //开始广度遍历
            int min = 1;
            Queue<TreeNode> q1 = new Queue<TreeNode>();
            q1.Enqueue(root);
            Queue<TreeNode> q2 = new Queue<TreeNode>();

            while (q1.Count > 0)
            {
                var item = q1.Dequeue();

                //提早结束遍历，这是BFS的优势
                if (item.left == null && item.right == null)
                    break;

                if (item.left != null)
                    q2.Enqueue(item.left);

                if (item.right != null)
                    q2.Enqueue(item.right);

                if(q1.Count == 0 && q2.Count != 0)
                {
                    var tempQueue = q2;
                    q2 = q1;
                    q1 = tempQueue;

                    min++;
                }
            }

            return min;
        }

        int min = int.MaxValue;

        private void DFS(TreeNode root,int deep)
        {
            //中止条件
            if(root == null)
            {
                min = 0;
                return;
            }

            //深入条件
            if (root.left == null && root.right == null)
                min = Math.Min(min, deep + 1);

            if (root.left != null)
                DFS(root.left, deep + 1);

            if (root.right != null)
                DFS(root.right, deep + 1);
        }

        private int Way1(TreeNode root)
        {
            if (root == null) return 0;

            int min1 = 0;
            int min2 = 0;

            if (root.left != null)
                min1 = MinDepth(root.left) + 1;

            if (root.right != null)
                min2 = MinDepth(root.right) + 1;

            if (min1 != 0 && min2 != 0)
                return Math.Min(min1, min2);
            else if (min1 != 0)
                return min1;
            else if (min2 != 0)
                return min2;
            else
                return 1;
        }
    }
}
