using System;
namespace ForSolveProblem
{
    public class Problem897 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public TreeNode IncreasingBST(TreeNode root)
        {
            m_head = new TreeNode(0);
            GetNode(m_head, root);

            return m_head.right;
        }

        private TreeNode m_head;

        private TreeNode GetNode(TreeNode curTail, TreeNode curNode)
        {
            if (curNode == null) return curTail;

            var l = GetNode(curTail, curNode.left);
            l.right = curNode;
            curNode.left = null;

            return GetNode(curNode, curNode.right);
        }
    }
}
