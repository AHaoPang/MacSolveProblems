using System;
namespace ForSolveProblem
{
    public class Problem700 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public TreeNode SearchBST(TreeNode root, int val)
        {
            /*
             * 算法复杂度:
             *  1.时间复杂度:O(n)
             *  2.空间复杂度:O(h)
             */
            if (root == null) return null;

            if (root.val == val) return root;

            return root.val > val ? SearchBST(root.left, val) : SearchBST(root.right, val);
        }
    }
}
