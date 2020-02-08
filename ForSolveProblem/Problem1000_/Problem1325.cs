using System;
using System.Collections.Generic;
using System.Text;

namespace ForSolveProblem
{
    public class Problem1325 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

        public TreeNode RemoveLeafNodes(TreeNode root, int target)
        {
            if (root == null) return root;

            root.left = RemoveLeafNodes(root.left, target);
            root.right = RemoveLeafNodes(root.right, target);

            if (root.left == null && root.right == null && root.val == target) return null;

            return root;
        }
    }
}
