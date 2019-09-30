using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem112 : IProblem
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
            TreeNode t1 = new TreeNode(5);
            TreeNode t2 = new TreeNode(4);
            TreeNode t3 = new TreeNode(8);
            TreeNode t4 = new TreeNode(11);
            TreeNode t5 = new TreeNode(13);
            TreeNode t6 = new TreeNode(4);
            TreeNode t7 = new TreeNode(7);
            TreeNode t8 = new TreeNode(2);
            TreeNode t9 = new TreeNode(1);

            t1.left = t2;
            t1.right = t3;

            t2.left = t4;
            t4.left = t7;
            t4.right = t8;

            t3.left = t5;
            t3.right = t6;

            t6.right = t9;

            var temp = HasPathSum(t1, 22);
        }

        public bool HasPathSum(TreeNode root, int sum)
        {
            /*
             * 查看是否存在这样的路径和，与目标值一致
             * 思路：
             *  1.DFS的一种，从根到叶的路径，刚好满足前序遍历的场景
             *  2.每深入一层，就减小一次目标值，当深入到最底层了，而且值为0时，表明存在此路径
             *  
             * 时间复杂度：O(n)，最坏情况下，遍历了所有的路径，才知道是否存在
             * 空间复杂度：O(n)，就是递归函数栈占用的空间
             */

            if (root == null) return false;

            sum -= root.val;
            if (root.left == null && root.right == null) return sum == 0;

            return HasPathSum(root.left, sum) || HasPathSum(root.right, sum);
        }
    }
}
