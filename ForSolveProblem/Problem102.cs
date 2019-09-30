using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem102 : IProblem
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

            var temp = LevelOrder(t1);

            temp = LevelOrder(null);
        }

        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            /*
             * 按层遍历一棵树，并返回每一行的结果
             * 递归向下依次获取结果的过程
             */

            var forReturn = new List<IList<int>>();
            var queueTemp = new Queue<TreeNode>();
            queueTemp.Enqueue(root);
            Recursive(forReturn, queueTemp);

            return forReturn;
        }

        private void Recursive(IList<IList<int>> forReturn, Queue<TreeNode> queue)
        {
            if (!queue.Any()) return;

            var numList = new List<int>();
            var queueTemp = new Queue<TreeNode>();
            while (queue.Any())
            {
                var treeTemp = queue.Dequeue();
                if (treeTemp == null) continue;

                numList.Add(treeTemp.val);
                queueTemp.Enqueue(treeTemp.left);
                queueTemp.Enqueue(treeTemp.right);
            }

            if (numList.Any()) forReturn.Add(numList);

            Recursive(forReturn, queueTemp);
        }
    }
}
