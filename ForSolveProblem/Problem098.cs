using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem098 : IProblem
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
            TreeNode t1 = new TreeNode(2);
            TreeNode t2 = new TreeNode(1);
            TreeNode t3 = new TreeNode(3);

            t1.left = t2;
            t1.right = t3;

            var temp = IsValidBST(t1);
            if (temp != true) throw new Exception();

            t1 = new TreeNode(5);
            t2 = new TreeNode(1);
            t3 = new TreeNode(4);
            TreeNode t4 = new TreeNode(3);
            TreeNode t5 = new TreeNode(6);

            t1.left = t2;
            t1.right = t3;

            t3.left = t4;
            t3.right = t5;

            temp = IsValidBST(t1);
            if (temp != false) throw new Exception();
        }

        public bool IsValidBST(TreeNode root)
        {
            /*
             * 校验一棵树是否是二叉搜索树
             * 思路：
             *  1.判断的条件应该是：左值 < 根 < 有值 且 左子树 和 右子树 同样满足条件
             *  2.从判断条件应该不难发现这是一个递归判断的问题
             *  3.递归终止条件有：已经到达叶子了、中间发现了不满足要求的部分
             *  
             * 时间复杂度：O(n)，无论如何要判断满足，所有节点都是要检查一遍的
             * 空间复杂度：O(n)，就是递归函数的栈空间了
             */

            return IsValidBSTRecursive(root, null, null);
        }

        public bool IsValidBSTRecursive(TreeNode root, int? leftRange, int? rigthRange)
        {
            if (root == null) return true;

            if (root.left != null)
            {
                if (root.left.val >= root.val) return false;
                if (leftRange.HasValue) if (root.left.val <= leftRange.Value) return false;
            }

            if (root.right != null)
            {
                if (root.right.val <= root.val) return false;
                if (rigthRange.HasValue) if (root.right.val >= rigthRange.Value) return false;
            }

            return IsValidBSTRecursive(root.left, leftRange, root.val) && IsValidBSTRecursive(root.right, root.val, rigthRange);
        }
    }
}
