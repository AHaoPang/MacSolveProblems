using System;
namespace ForSolveProblem
{
    public class Problem5398 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int GoodNodes(TreeNode root)
        {
            m_res = 0;
            Dfs(root, int.MinValue);
            return m_res;
        }

        private int m_res;

        private void Dfs(TreeNode root, int max)
        {
            if (root == null)
                return;

            if (root.val >= max)
                m_res++;

            max = Math.Max(max, root.val);

            Dfs(root.left, max);
            Dfs(root.right, max);
        }
    }
}
