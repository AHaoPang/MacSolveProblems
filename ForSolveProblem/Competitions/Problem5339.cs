using System;
namespace ForSolveProblem
{
    public class Problem5339 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int MaxSumBST(TreeNode root)
        {
            m_max = 0;

            Recursive(root);

            return m_max;
        }

        private int m_max;

        private Tuple<bool, int> Recursive(TreeNode root)
        {
            if (root == null) return Tuple.Create(true, 0);

            var leftResult = Recursive(root.left);
            var rightResult = Recursive(root.right);

            if (leftResult.Item1 && rightResult.Item1)
            {
                var b = true;
                if (root.left != null && root.left.val >= root.val)
                    b = false;

                var c = true;
                if (root.right != null && root.right.val <= root.val)
                    c = false;

                if (b && c)
                {
                    var curSum = root.val + leftResult.Item2 + rightResult.Item2;
                    m_max = Math.Max(m_max, curSum);
                    return Tuple.Create(true, curSum);
                }
            }

            return Tuple.Create(false, 0);
        }
    }
}
