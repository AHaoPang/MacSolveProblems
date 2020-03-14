using System;
namespace ForSolveProblem
{
    public class Problem563 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int FindTilt(TreeNode root)
        {
            m_total = 0;
            Dfs(root);
            return m_total;
        }

        private int m_total;

        private int Dfs(TreeNode root)
        {
            if (root == null) return 0;

            var leftValue = Dfs(root.left);
            var rightValue = Dfs(root.right);

            m_total += Math.Abs(leftValue - rightValue);

            return root.val + leftValue + rightValue;
        }
    }
}
