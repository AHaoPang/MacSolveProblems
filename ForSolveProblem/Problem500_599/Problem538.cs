using System;
namespace ForSolveProblem
{
    public class Problem538 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public TreeNode ConvertBST1(TreeNode root)
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

        public TreeNode ConvertBST(TreeNode root)
        {
            m_sum = 0;
            RightRootLeft(root);
            return root;
        }

        private int m_sum;

        private void RightRootLeft(TreeNode root)
        {
            if (root == null) return;

            RightRootLeft(root.right);
            m_sum += root.val;
            root.val = m_sum;
            RightRootLeft(root.left);
        }
    }
}
