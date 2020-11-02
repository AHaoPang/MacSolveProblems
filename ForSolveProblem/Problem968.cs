using System;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace ForSolveProblem
{
    public class Problem968 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int MinCameraCover(TreeNode root)
        {
            var res = Recursive(root);
            return Math.Min(res.no, res.yes);
        }

        private (int no, int yes) Recursive(TreeNode root)
        {
            if (root.left == null && root.right == null) return (0, 1);

            if (root.left == null)
            {
                var right = Recursive(root.right);

                var noCount = right.yes;
                var yesCount = Math.Min(right.no, right.yes) + 1;

                return (noCount, yesCount);
            }
            else if (root.right == null)
            {
                var left = Recursive(root.left);

                var noCount = left.yes;
                var yesCount = Math.Min(left.no, left.yes) + 1;

                return (noCount, yesCount);
            }
            else
            {
                var left = Recursive(root.left);
                var right = Recursive(root.right);

                var v1 = left.yes + right.no;
                var v2 = left.no + right.yes;
                var v3 = left.yes + right.yes;
                var noCount = new[] { v1, v2, v3 }.Min();

                var yesCount = left.no + right.no + 1;

                return (noCount, yesCount);
            }
        }
    }
}
