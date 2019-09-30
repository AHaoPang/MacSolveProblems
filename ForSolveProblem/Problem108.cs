using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem108 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

        public TreeNode SortedArrayToBST(int[] nums)
        {
            /*
             * 将有序数组转换为平衡二叉搜索树
             * 思路：
             *  1.可以模拟树的“中序遍历”过程
             */

            return MiddleSortedSearch(nums, 0, nums.Length - 1);
        }

        int currentIndex = 0;

        private TreeNode MiddleSortedSearch(int[] nums, int leftIndex, int rightIndex)
        {
            if (leftIndex > rightIndex) return null;

            var middleIndex = leftIndex + (rightIndex - leftIndex) / 2;

            var leftNode = MiddleSortedSearch(nums, leftIndex, middleIndex - 1);

            TreeNode root = new TreeNode(nums[currentIndex++]);
            root.left = leftNode;

            root.right = MiddleSortedSearch(nums, middleIndex + 1, rightIndex);

            return root;
        }

        public TreeNode SortedArrayToBST1(int[] nums)
        {
            /*
             * 将有序数组转换为平衡二叉搜索树
             * 思路：
             *  1.可以看成是一个递归的子问题，即就整棵树而言，左子树和右子树的高度平衡，左子树和右子树，也是同样的
             *  2.为了保持平衡，根应该是位于中间的位置
             *  3.相当于数组不断找文件位置，进而不断构造二叉树的过程
             * 
             * 时间复杂度：O(n)，即遍历一遍所有的节点
             * 空间复杂度：O(n）
             */

            return RecurSive(nums, 0, nums.Length - 1);
        }

        private TreeNode RecurSive(int[] nums, int leftIndex, int rigthIndex)
        {
            if (leftIndex > rigthIndex) return null;

            var middleIndex = leftIndex + (rigthIndex - leftIndex) / 2;

            TreeNode root = new TreeNode(nums[middleIndex]);

            root.left = RecurSive(nums, leftIndex, middleIndex - 1);
            root.right = RecurSive(nums, middleIndex + 1, rigthIndex);

            return root;
        }
    }
}
