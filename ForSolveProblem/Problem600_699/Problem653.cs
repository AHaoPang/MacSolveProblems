using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem653 : IProblem
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

        public bool FindTarget(TreeNode root, int k)
        {
            /*
             * 在二叉搜索树中，找两个数，他们的和等于目标值
             * 思路：
             *  1.二叉搜索树，本来是类似二分一样，快速定位一个确定值的
             *  2.本次是要定位两个不确定的值，因此二叉搜索树结构本身并不适合做这个
             *  3.考虑将二叉搜索树中序遍历转换为数组，然后利用双指针的方式，定位到结果
             *  
             * 时间复杂度：O(n)，实际上是可能遍历了2次全部的元素
             * 空间复杂度：O(n)，为了存储中序遍历后的数组
             */

            //先输出数组
            List<int> forReturn = new List<int>();
            GetOrderedNumsArray(root, forReturn);

            //再使用双指针的方式来定位目标值
            int leftIndex = 0;
            int rightIndex = forReturn.Count - 1;
            while (leftIndex < rightIndex)
            {
                var sumTemp = forReturn[leftIndex] + forReturn[rightIndex];

                if (sumTemp == k) return true;
                else if (sumTemp < k) leftIndex++;
                else rightIndex--;
            }

            return false;
        }

        private void GetOrderedNumsArray(TreeNode root, List<int> forReturn)
        {
            if (root == null) return;

            GetOrderedNumsArray(root.left, forReturn);

            forReturn.Add(root.val);

            GetOrderedNumsArray(root.right, forReturn);
        }
    }
}
