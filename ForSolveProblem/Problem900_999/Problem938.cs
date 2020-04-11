using System;
namespace ForSolveProblem
{
    public class Problem938 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int RangeSumBST(TreeNode root, int L, int R)
        {
            if (root == null) return 0;

            var leftValue = RangeSumBST(root.left, L, R);
            var rightValue = RangeSumBST(root.right, L, R);

            if (root.val >= L && root.val <= R)
                return root.val + leftValue + rightValue;
            else if (root.val < L)
                return rightValue;
            else
                return leftValue;
        }

        public int RangeSumBST1(TreeNode root, int L, int R)
        {
            m_sum = 0;
            Recursive(root, L, R);
            return m_sum;
        }

        private int m_sum;

        private void Recursive(TreeNode root, int L, int R)
        {
            if (root == null) return;

            if (root.val >= L && root.val <= R)
            {
                m_sum += root.val;
                Recursive(root.left, L, R);
                Recursive(root.right, L, R);
            }
            else if (root.val < L)
                Recursive(root.right, L, R);
            else if (root.val > R)
                Recursive(root.left, L, R);
        }
    }
}
