using System;
namespace ForSolveProblem
{
    public class Problem230 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int KthSmallest(TreeNode root, int k)
        {
            Recursive(root, k);
            return m_res;
        }

        private int m_res = 0;
        private int m_i = 0;

        private void Recursive(TreeNode curNode, int k)
        {
            if (curNode == null || m_i >= k) return;

            Recursive(curNode.left, k);

            if (m_i++ == k)
            {
                m_res = curNode.val;
                return;
            }

            Recursive(curNode.right, k);
        }
    }
}
