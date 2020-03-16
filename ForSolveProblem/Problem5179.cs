using System;
using System.Collections.Generic;

namespace ForSolveProblem
{
    public class Problem5179 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public TreeNode BalanceBST(TreeNode root)
        {
            m_list = new List<int>(100);

            Dfs(root);

            return GetMiddleNode(m_list, 0, m_list.Count - 1);
        }

        private List<int> m_list;

        private void Dfs(TreeNode root)
        {
            if (root == null) return;

            Dfs(root.left);

            m_list.Add(root.val);

            Dfs(root.right);
        }

        private TreeNode GetMiddleNode(List<int> list, int leftIndex, int rightIndex)
        {
            if (leftIndex > rightIndex) return null;

            var curIndex = leftIndex + (rightIndex - leftIndex) / 2;
            var curNode = new TreeNode(list[curIndex])
            {
                left = GetMiddleNode(list, leftIndex, curIndex - 1),
                right = GetMiddleNode(list, curIndex + 1, rightIndex)
            };

            return curNode;
        }
    }
}
