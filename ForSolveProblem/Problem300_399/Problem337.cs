using System;
namespace ForSolveProblem
{
    public class Problem337 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int Rob(TreeNode root)
        {
            var res = Dfs(root);
            return Math.Max(res[0], res[1]);
        }

        private int[] Dfs(TreeNode root)
        {
            if (root == null)
                return new[] { 0, 0 };

            var left = Dfs(root.left);
            var right = Dfs(root.right);

            var y = root.val + left[1] + right[1];
            var n = Math.Max(left[0], left[1]) + Math.Max(right[0], right[1]);

            return new[] { y, n };
        }
    }
}
