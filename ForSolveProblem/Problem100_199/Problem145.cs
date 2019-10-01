using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem145 : IProblem
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

        public IList<int> PostorderTraversal(TreeNode root)
        {
            IList<int> forReturn = new List<int>();

            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode curNode = root;

            while(curNode != null || stack.Count > 0)
            {
                while(curNode != null)
                {
                    stack.Push(curNode);
                    curNode = curNode.left;
                }

                curNode = stack.Pop();
                if (curNode.right == null) forReturn.Add(curNode.val);
                else stack.Push(curNode);

                curNode = curNode.right;
            }

            return forReturn;
        }

        public IList<int> PostorderTraversal2(TreeNode root)
        {
            /*
             * 使用递归的方式来实现 Post Order
             */

            IList<int> forReturn = new List<int>();
            Recursive(root, forReturn);
            return forReturn;
        }

        private void Recursive(TreeNode node,IList<int> list)
        {
            if (node == null) return;

            Recursive(node.left, list);
            Recursive(node.right, list);
            list.Add(node.val);
        }
    }
}
