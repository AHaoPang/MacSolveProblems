using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem107 : IProblem
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

            var temp = LevelOrderBottom(t1);

            temp = LevelOrderBottom(null);
        }

        public IList<IList<int>> LevelOrderBottom(TreeNode root)
        {
            /*
             * 还是队列的方式，但是这次想让递归返回列表值
             */

            Queue<TreeNode> queueTemp = new Queue<TreeNode>();
            queueTemp.Enqueue(root);
            return Recursive(queueTemp);
        }

        private IList<IList<int>> Recursive(Queue<TreeNode> queue)
        {
            if (!queue.Any()) return new List<IList<int>>();

            Queue<TreeNode> queueTemp = new Queue<TreeNode>();
            var numList = new List<int>();
            while (queue.Any())
            {
                var treeTemp = queue.Dequeue();
                if (treeTemp == null) continue;

                numList.Add(treeTemp.val);
                queueTemp.Enqueue(treeTemp.left);
                queueTemp.Enqueue(treeTemp.right);
            }

            var listTemp = Recursive(queueTemp);

            if (numList.Any()) listTemp.Add(numList);
            return listTemp;
        }

        public IList<IList<int>> LevelOrderBottom1(TreeNode root)
        {
            /*
             * 按层递增遍历每一层的值
             * 思路：
             *  1.树，给的就是根，所以正常情况下，应该是递减得到遍历结果，然后题目相反，因此想到使用栈的方式
             *  2.我还是递减的遍历，但是把值存在栈中，等到需要结果的时候，再从栈中取出来就好了
             *  3.按层做遍历，通常就是 BFS 了
             *  4.每一层做的事情基本上是相同的，因此考虑使用 递归
             *  
             * 时间复杂度：O(n)，需要把树从根到子递归一遍，然后再输出得到结果
             * 空间复杂度：O(n)，为了构造结果而不得不使用的额外空间
             */

            //1.进入递归的过程
            Stack<IList<int>> stackResult = new Stack<IList<int>>();
            Queue<TreeNode> queueTemp = new Queue<TreeNode>();
            queueTemp.Enqueue(root);
            Recursive1(stackResult, queueTemp);

            return stackResult.ToList();
        }

        private void Recursive1(Stack<IList<int>> stackResult, Queue<TreeNode> queue)
        {
            if (!queue.Any()) return;

            Queue<TreeNode> queueTemp = new Queue<TreeNode>();
            var numList = new List<int>();
            while (queue.Any())
            {
                var treeTemp = queue.Dequeue();
                if (treeTemp == null) continue;

                numList.Add(treeTemp.val);
                queueTemp.Enqueue(treeTemp.left);
                queueTemp.Enqueue(treeTemp.right);
            }

            if (numList.Any())
                stackResult.Push(numList);

            Recursive1(stackResult, queueTemp);
        }
    }
}
