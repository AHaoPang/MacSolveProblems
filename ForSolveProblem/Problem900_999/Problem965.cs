using System;
namespace ForSolveProblem
{
    public class Problem965 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public bool IsUnivalTree(TreeNode root)
        {
            if (root == null) return true;

            if (root.left != null && root.left.val != root.val)
                return false;

            if (root.right != null && root.right.val != root.val)
                return false;

            return IsUnivalTree(root.left) && IsUnivalTree(root.right);
        }
    }
}
