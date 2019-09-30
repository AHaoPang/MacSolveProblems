using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem113 : IProblem
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
            TreeNode t1 = new TreeNode(5);
            TreeNode t2 = new TreeNode(4);
            TreeNode t3 = new TreeNode(8);
            TreeNode t4 = new TreeNode(11);
            TreeNode t5 = new TreeNode(13);
            TreeNode t6 = new TreeNode(4);
            TreeNode t7 = new TreeNode(7);
            TreeNode t8 = new TreeNode(2);
            TreeNode t9 = new TreeNode(1);
            TreeNode t10 = new TreeNode(5);

            t1.left = t2;
            t1.right = t3;

            t2.left = t4;
            t4.left = t7;
            t4.right = t8;

            t3.left = t5;
            t3.right = t6;

            t6.left = t10;
            t6.right = t9;

            var temp = PathSum(t1, 22);
        }

        public IList<IList<int>> PathSum(TreeNode root, int sum)
        {
            /*
             * 找到所有总和为目标值的树的路径
             * 思路：
             *  1.依然是 前序遍历的一种应用
             *  2.递归的过程中，要记录的信息多了一些
             *  
             * 时间复杂度：O(n)，所有的节点都要遍历
             * 空间复杂度：O(n^2)，要存储返回的结果
             */

            IList<IList<int>> forReturn = new List<IList<int>>();

            Recursive(forReturn, root, sum, new List<int>());

            return forReturn;
        }

        private void Recursive(IList<IList<int>> forReturn, TreeNode root, int sum, IList<int> pathNums)
        {
            if (root == null) return;

            pathNums.Add(root.val);

            sum -= root.val;
            if (root.left == null && root.right == null)
            {
                if (sum == 0) forReturn.Add(pathNums.Select(i => i).ToList());
            }
            else
            {
                Recursive(forReturn, root.left, sum, pathNums);
                Recursive(forReturn, root.right, sum, pathNums);
            }

            pathNums.RemoveAt(pathNums.Count - 1);
        }
    }
}
