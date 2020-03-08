using System;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem5338 : IProblem
    {
        public void RunProblem()
        {
            var tree = ProblemHelper.MadeTreeV2(new int?[] { 1, null, 1, 1, 1, null, null, 1, 1, null, 1, null, null, null, 1, null, 1 });
            var temp = LongestZigZag(tree);

            tree = ProblemHelper.MadeTreeV2(new int?[] { 1, 1, 1, null, 1, null, null, 1, 1, null, 1 });
            temp = LongestZigZag(tree);

            tree = ProblemHelper.MadeTreeV2(new int?[] { 1 });
            temp = LongestZigZag(tree);
        }

        public int LongestZigZag(TreeNode root)
        {
            m_maxLength = 0;
            Recursive(root, new List<List<TreeNode>>(), new List<List<TreeNode>>());
            return m_maxLength;
        }

        private int m_maxLength;

        private void Recursive(TreeNode root, List<List<TreeNode>> rightList, List<List<TreeNode>> leftList)
        {
            if (root == null)
            {
                var v1 = rightList.Any() ? rightList.Max(i => i.Count) : 0;
                var v2 = leftList.Any() ? leftList.Max(i => i.Count) : 0;

                m_maxLength = Math.Max(m_maxLength, Math.Max(v1 - 1, v2 - 1));
                return;
            }

            rightList.ForEach(i => i.Add(root));
            rightList.Add(new List<TreeNode>() { root });
            Recursive(root.left, rightList, new List<List<TreeNode>>() { new List<TreeNode>() { root } });
            rightList.ForEach(i => i.RemoveAt(i.Count - 1));
            rightList.RemoveAll(i => i.Count == 0);

            leftList.ForEach(i => i.Add(root));
            leftList.Add(new List<TreeNode>() { root });
            Recursive(root.right, new List<List<TreeNode>>() { new List<TreeNode>() { root } }, leftList);
            leftList.ForEach(i => i.RemoveAt(i.Count - 1));
            leftList.RemoveAll(i => i.Count == 0);
        }
    }
}
