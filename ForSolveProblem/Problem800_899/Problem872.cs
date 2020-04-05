using System;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem872 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public bool LeafSimilar(TreeNode root1, TreeNode root2)
        {
            var e1 = GetLeafArray(root1);
            var e2 = GetLeafArray(root2);

            return e1.SequenceEqual(e2);
        }

        private IEnumerable<int> GetLeafArray(TreeNode root)
        {
            if (root == null) return new int[0];

            if (root.left == null && root.right == null)
                return new int[] { root.val };

            var a1 = GetLeafArray(root.left);
            var a2 = GetLeafArray(root.right);
            return a1.Concat(a2).ToArray();
        }
    }
}
