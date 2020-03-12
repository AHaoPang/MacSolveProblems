using System;
namespace ForSolveProblem
{
    public class Problem538 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public TreeNode ConvertBST(TreeNode root)
        {
            m_total = 0;
            Recursive(root);
            return root;
        }

        private int m_total;

        private void Recursive(TreeNode root)
        {
            if (root == null) return;

            Recursive(root.right);

            m_total += root.val;
            root.val = m_total;

            Recursive(root.left);
        }
    }
}
