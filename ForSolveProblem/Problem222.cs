using System;
namespace ForSolveProblem
{
    public class Problem222 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int CountNodes(TreeNode root)
        {
            m_res = 0;
            Dfs(root);
            return m_res;
        }

        private int m_res;

        private void Dfs(TreeNode root)
        {
            if (root == null) return;

            m_res++;
            Dfs(root.left);
            Dfs(root.right);
        }
    }
}
