using System;
namespace ForSolveProblem
{
    public class Problem617 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public TreeNode MergeTrees(TreeNode t1, TreeNode t2)
        {
            if (t1 == null || t2 == null) return t1 ?? t2;

            t1.val += t2.val;
            t1.left = MergeTrees(t1.left, t2.left);
            t1.right = MergeTrees(t1.right, t2.right);

            return t1;
        }
    }
}
