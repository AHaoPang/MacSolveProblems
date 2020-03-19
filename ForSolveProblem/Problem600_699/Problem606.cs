using System;
using System.Text;

namespace ForSolveProblem
{
    public class Problem606 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public string Tree2str(TreeNode t)
        {
            if (t == null) return "";

            if (t.left != null || t.right != null)
            {
                var leftStr = Tree2str(t.left);
                var str = $"{t.val.ToString()}({leftStr})";

                if (t.right != null)
                {
                    var rightStr = Tree2str(t.right);
                    str = $"{str}({rightStr})";
                }

                return str;
            }

            return t.val.ToString();
        }
    }
}
