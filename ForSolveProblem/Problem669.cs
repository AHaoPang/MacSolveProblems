using System;
namespace ForSolveProblem
{
    public class Problem669 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public TreeNode TrimBST(TreeNode root, int L, int R)
        {
            if (root == null) return root;

            if (root.val < L)
                return TrimBST(root.right, L, R);

            if (root.val > R)
                return TrimBST(root.left, L, R);

            root.left = TrimBST(root.left, L, R);
            root.right = TrimBST(root.right, L, R);
            return root;
        }
    }
}
