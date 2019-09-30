using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem110 : IProblem
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

        public bool IsBalanced(TreeNode root)
        {
            /*
             * 判断一棵树是否是平衡二叉树
             * 思路：
             *  1.依据对平衡二叉树的定义：左右子树的高度差，不超过1
             *  2.那么这样好了
             *      2.1 跟去问左子树的高度，再问右子树的高度
             *      2.2 根去比较两个子树的高度就好了
             *      2.3 子树还要接下往下问，若一个节点是叶子，那么叶子是知道自己位于最底层的，然后再层层向上汇报
             *  3.比较典型的递归求解问题
             *  
             * 时间复杂度：O(n)，最坏情况下，所有的节点肯定是要遍历一遍的
             * 空间复杂度：O(n)
             */

            var result = IsBalancedAndDeepth(root);

            return result.Item1;
        }

        private Tuple<bool, int> IsBalancedAndDeepth(TreeNode root)
        {
            if (root == null) return Tuple.Create(true, 0);

            var leftResult = IsBalancedAndDeepth(root.left);
            if (!leftResult.Item1) return Tuple.Create(false, 0);

            var rightResult = IsBalancedAndDeepth(root.right);
            if (!rightResult.Item1) return Tuple.Create(false, 0);

            if (Math.Abs(leftResult.Item2 - rightResult.Item2) <= 1) return Tuple.Create(true, Math.Max(leftResult.Item2, rightResult.Item2) + 1);

            return Tuple.Create(false, 0);
        }
    }
}
