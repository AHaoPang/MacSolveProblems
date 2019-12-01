using System;
using System.Collections.Generic;
using System.Text;

namespace ForSolveProblem
{
    public class Problem5264 : IProblem
    {
        public void RunProblem()
        {
        }

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

        public class FindElements
        {
            private TreeNode m_root;

            public FindElements(TreeNode root)
            {
                m_root = root;
                Recursion(m_root, 0);
            }

            private void Recursion(TreeNode node, int curValue)
            {
                if (node == null) return;

                node.val = curValue;

                Recursion(node.left, 2 * curValue + 1);
                Recursion(node.right, 2 * curValue + 2);
            }

            public bool Find(int target)
            {
                return RecursionFind(m_root, target);
            }

            private bool RecursionFind(TreeNode node, int target)
            {
                if (node == null || node.val > target) return false;

                if (node.val == target) return true;

                return RecursionFind(node.left, target) || RecursionFind(node.right, target);
            }
        }
    }
}
