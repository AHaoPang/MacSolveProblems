using System;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem124 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int MaxPathSum(TreeNode root)
        {
            m_re = int.MinValue;
            GetRes(root);

            return m_re;
        }

        private int m_re;

        private int GetRes(TreeNode root)
        {
            if (root == null)
                return 0;

            var leftValue = Math.Max(0, GetRes(root.left));
            var rightValue = Math.Max(0, GetRes(root.right));

            var r = root.val + leftValue + rightValue;
            m_re = Math.Max(m_re, r);

            var m = Math.Max(leftValue, rightValue);
            return Math.Max(m + root.val, root.val);
        }

        public int MaxPathSum2(TreeNode root)
        {
            m_r = root.val;
            var r = Recursive(root);
            m_r = Math.Max(m_r, r);

            return m_r;
        }

        private int m_r;

        public int Recursive(TreeNode root)
        {
            if (root.left == null && root.right == null)
            {
                m_r = Math.Max(m_r, root.val);
                return root.val;
            }

            if (root.left == null || root.right == null)
            {
                if (root.left != null)
                {
                    var leftV = Recursive(root.left);
                    var m = new[] { root.val, leftV + root.val }.Max();
                    m_r = Math.Max(m, m_r);
                    return m;
                }
                else
                {
                    var rightV = Recursive(root.right);
                    var m = new[] { root.val, rightV + root.val }.Max();
                    m_r = Math.Max(m, m_r);
                    return m;
                }
            }

            var leftValue = Recursive(root.left);
            var rightValue = Recursive(root.right);
            var arr = new[] { root.val, root.val + leftValue, root.val + rightValue, root.val + leftValue + rightValue };
            m_r = Math.Max(m_r, arr.Max());

            return new[] { root.val, root.val + leftValue, root.val + rightValue }.Max();
        }

        public int MaxPathSum1(TreeNode root)
        {
            m_res = root.val;
            var r = Dfs(root);
            if (root.left == null || root.right == null)
                m_res = Math.Max(m_res, r);

            return m_res;
        }

        private int m_res;

        private int Dfs(TreeNode root)
        {
            if (root == null)
                return 0;

            var leftValue = Dfs(root.left);
            var rightValue = Dfs(root.right);

            if (root.left != null && root.right != null)
                m_res = Math.Max(m_res, leftValue + rightValue + root.val);
            else if (root.left == null && root.right == null)
                m_res = Math.Max(m_res, root.val);

            return Math.Max(leftValue, rightValue) + root.val;
        }
    }
}
