using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem094 : IProblem
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

        public IList<int> InorderTraversal(TreeNode root)
        {
            /*
             * 使用栈的方式，来实现一个中序遍历
             * 1.节点不为空，就压栈，当前指针指向新的left
             * 2.从栈中取出来的数据，首先收集值，然后指针指向新的right；
             * 3.进入新的一轮检查；
             */

            IList<int> forReturn = new List<int>();

            Stack<TreeNode> col = new Stack<TreeNode>();
            TreeNode cur = root;

            while (cur != null || col.Count > 0)
            {
                if(cur != null)
                {
                    col.Push(cur);
                    cur = cur.left;
                }
                else
                {
                    cur = col.Pop();
                    forReturn.Add(cur.val);
                    cur = cur.right;
                }
            }

            return forReturn;
        }

        public IList<int> InorderTraversal2(TreeNode root)
        {
            /*
             * 使用递归的方式，实现 inOrder Recursive
             * 时间复杂度：O(n)
             * 空间复杂度：O(n)
             */

            Recursive(root);
            return treeNodes;
        }

        private IList<int> treeNodes = new List<int>();

        private void Recursive(TreeNode root)
        {
            if (root == null) return;

            Recursive(root.left);
            treeNodes.Add(root.val);
            Recursive(root.right);
        }
    }
}
