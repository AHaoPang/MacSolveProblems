using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem103 : IProblem
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
            TreeNode t1 = new TreeNode(3);
            TreeNode t2 = new TreeNode(9);
            TreeNode t3 = new TreeNode(20);
            TreeNode t4 = new TreeNode(15);
            TreeNode t5 = new TreeNode(7);

            t1.left = t2;
            t1.right = t3;

            t3.left = t4;
            t3.right = t5;

            var temp = ZigzagLevelOrder(t1);
        }

        public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {
            /*
             * 锯齿形层次遍历一颗二叉树
             * 思路：
             *  1.算是BFS的一种变体，从遍历过程可以看出，加入节点的顺序和输出节点的数序是相反的，满足栈的特性，所以是可以使用栈的
             *  1.两个栈交替做输入和输出
             *  
             * 时间复杂度：O(n)，要把所有的节点都过一遍
             * 空间复杂度：O(n)，要输出所有的节点值
             */

            IList<IList<int>> forReturn = new List<IList<int>>();
            var forOdd = new Stack<TreeNode>();
            forOdd.Push(root);
            Recursive(forReturn, 1, forOdd, new Stack<TreeNode>());

            return forReturn;
        }

        private void Recursive(IList<IList<int>> forReturn, int line, Stack<TreeNode> forOdd, Stack<TreeNode> forEven)
        {
            if (!forOdd.Any() && !forEven.Any()) return;

            var returnTemp = new List<int>();

            if ((line & 1) == 1)
            {
                //odd
                while (forOdd.Any())
                {
                    var temp = forOdd.Pop();
                    if (temp == null) continue;

                    returnTemp.Add(temp.val);

                    forEven.Push(temp.left);
                    forEven.Push(temp.right);
                }
            }
            else
            {
                //even
                while (forEven.Any())
                {
                    var temp = forEven.Pop();
                    if (temp == null) continue;

                    returnTemp.Add(temp.val);

                    forOdd.Push(temp.right);
                    forOdd.Push(temp.left);
                }
            }

            if (returnTemp.Any()) forReturn.Add(returnTemp);

            Recursive(forReturn, line + 1, forOdd, forEven);
        }
    }
}
