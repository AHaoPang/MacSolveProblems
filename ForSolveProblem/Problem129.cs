using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem129 : IProblem
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

        public int SumNumbers(TreeNode root)
        {
            /*
             * 求得树所有路径之和
             * 思路：
             *  1.肯定是要先找出路径，然后再汇总求和的
             *  2.能遍历所有路径的算法，是“前序遍历”
             *  
             * 时间复杂度：O(n)，将所有节点都遍历一遍
             * 空间复杂度：O(logn)，存储空间与树的高度相关
             */

            Recursive(0, root);
            return treePathSum;
        }

        private int treePathSum = 0;

        private void Recursive(int curPathSum, TreeNode treeNode)
        {
            if (treeNode == null) return;

            curPathSum = curPathSum * 10 + treeNode.val;
            if (treeNode.left == null && treeNode.right == null)
            {
                treePathSum += curPathSum;
                return;
            }

            Recursive(curPathSum, treeNode.left);
            Recursive(curPathSum, treeNode.right);
        }
    }
}
