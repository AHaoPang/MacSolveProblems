using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem235 : IProblem
    {
        public void RunProblem()
        {
            // root = [6,2,8,0,4,7,9,null,null,3,5]

            var t0 = new TreeNode(6);
            var t1 = new TreeNode(2);
            var t2 = new TreeNode(8);
            var t3 = new TreeNode(0);
            var t4 = new TreeNode(4);
            var t5 = new TreeNode(7);
            var t6 = new TreeNode(9);
            var t7 = new TreeNode(3);
            var t8 = new TreeNode(5);

            t0.left = t1;
            t0.right = t2;
            t1.left = t3;
            t1.right = t4;
            t2.left = t5;
            t2.right = t6;
            t4.left = t7;
            t4.right = t8;

            var temp = LowestCommonAncestor(t0, t1, t4);
        }

        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root.val > p.val && root.val > q.val)
                return LowestCommonAncestor(root.left, p, q);
            else if (root.val < p.val && root.val < q.val)
                return LowestCommonAncestor(root.right, p, q);
            else
                return root;
        }

        private TreeNode Solution1(TreeNode root, TreeNode p, TreeNode q)
        {
            //自己为Null,或者自己就是p或者q，那就直说好了~
            if (root == null || root.val == p.val || root.val == q.val) return root;

            //分别询问左右子节点，是否找到了
            var leftNode = LowestCommonAncestor(root.left, p, q);
            var rightNode = LowestCommonAncestor(root.right, p, q);

            if (leftNode != null && rightNode != null)
                return root;      //左右子树都有结果，那么就是自己了~
            else if (leftNode != null)
                return leftNode;  //以左子树的结果为准
            else
                return rightNode;//以右子树的结果为准
        }

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }
    }
}
