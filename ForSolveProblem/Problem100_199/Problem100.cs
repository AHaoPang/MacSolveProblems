using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem100 : IProblem
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

        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == null && q == null) return true;

            if (p != null && q != null && p.val == q.val)
                return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);

            return false;
        }

        public bool IsSameTree2(TreeNode p, TreeNode q)
        {
            /*
             * 判断两棵树，在结构和节点值上是否完全一致，也就是说，是两颗相同的树
             * 解决思路：
             * 1.判断两个树相同的条件
             *      1.1 根上的值相同
             *      1.2 左子节点存在/不存在
             *      1.3 右子节点存在/不存在
             * 2.反复检查以上3个条件，若中间有不满足，则说明不相同；反之，则说明相同；
             * 3.因为每个阶段考虑的问题是一致的，因此可以考虑使用递归的方式来解决问题；
             * 
             * 时间复杂度：O(n)-->当两个树完全相同，那么就需要全部遍历一遍了；
             * 空间复杂度：O(1)
             * 
             * 考察点：
             * 1.树节点本身，分为：值、左子树、右子树，即对树的理解
             * 2.递归
             */

            //针对节点本身的判断
            if (p == null && q == null) return true;
            if (p == null || q == null) return false;

            //针对节点值的判断
            if (p.val != q.val) return false;

            return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
        }
    }
}
