using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem144 : IProblem
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public IList<int> PreorderTraversal(TreeNode root)
        {
            /*
             * 使用栈来解决问题的思路：
             * 1.拿到一个节点，首先需要收集值；
             * 2.收集完值以后，就压栈，因为需要检测left是否为空；
             * 3.从栈取出的元素，需要指向右节点；
             */

            IList<int> forReturn = new List<int>();

            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode curTree = root;

            while (curTree != null || stack.Count > 0)
            {
                while (curTree != null)
                {
                    forReturn.Add(curTree.val);

                    stack.Push(curTree);
                    curTree = curTree.left;
                }

                curTree = stack.Pop();
                curTree = curTree.right;
            }

            return forReturn;
        }

        public IList<int> PreorderTraversal2(TreeNode root)
        {
            /*
             * 使用递归来实现 PreOrder 遍历
             */

            Recursive(root);
            return forReturn;
        }

        private IList<int> forReturn = new List<int>();

        private void Recursive(TreeNode tree)
        {
            if (tree == null) return;

            forReturn.Add(tree.val);
            Recursive(tree.left);
            Recursive(tree.right);
        }
    }
}
