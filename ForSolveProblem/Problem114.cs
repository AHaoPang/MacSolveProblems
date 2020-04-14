using System;
namespace ForSolveProblem
{
    public class Problem114 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public void Flatten(TreeNode root)
        {
            GetNode(root);
        }

        private TreeNode GetNode(TreeNode root)
        {
            if (root == null) return root;
            if (root.left == null && root.right == null) return root;

            var left = GetNode(root.left);
            var right = GetNode(root.right);

            if (left != null && right != null)
            {
                left.right = root.right;
                root.right = root.left;
                root.left = null;
                return right;
            }

            if (right != null)
                return right;

            root.right = root.left;
            root.left = null;
            return left;
        }
    }
}
