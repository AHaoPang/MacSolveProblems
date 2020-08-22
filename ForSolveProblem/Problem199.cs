using System;
using System.Collections.Generic;
using System.Text;

namespace ForSolveProblem
{
    public class Problem_199 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public IList<int> RightSideView(TreeNode root)
        {
            m_nums = new List<int>();
            m_maxLevel = -1;

            Dfs(0, root);

            return m_nums;
        }

        private List<int> m_nums;
        private int m_maxLevel;

        private void Dfs(int level, TreeNode root)
        {
            if (root == null) return;

            if (level > m_maxLevel)
            {
                m_maxLevel = level;
                m_nums.Add(root.val);
            }

            level++;
            Dfs(level, root.right);
            Dfs(level, root.left);
        }
    }
}
