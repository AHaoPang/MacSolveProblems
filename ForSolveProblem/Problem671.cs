using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem671 : IProblem
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

        public int FindSecondMinimumValue(TreeNode root)
        {
            /*
             * 解析思路：利用递归的思想
             * 此树的特性，明显是个小顶堆
             * 若是找最小，那么直接就是根节点了，现在要第二个小的，那么就是第一个比根节点大的那个了~、
             * 
             * 时间复杂度：O(n)-->最差情况是把树都检查了一遍，最好情况是马上就找到了
             * 空间复杂度：O(n)-->使用递归的方式，栈的空间存值问题
             */

            return MinimumValue(root, root.val);
        }

        private int MinimumValue(TreeNode root,int matchValue)
        {
            //到尽头了，那就说明没找到比根大的值
            if (root == null) return -1;

            //首次找到比根大的值，那么就返回，不要再继续查找了
            if (root.val > matchValue) return root.val;

            //继续往下找
            int leftValue = MinimumValue(root.left, matchValue);
            int rightValue = MinimumValue(root.right, matchValue);

            //两个子都有比根大的值，那就取两者间的小的
            if (leftValue > 0 && rightValue > 0)
                return Math.Min(leftValue, rightValue);

            //二者仅有一个找到了，或者都没找到，那么返回较大的好了
            return Math.Max(leftValue, rightValue);
        }

        public int FindSecondMinimumValue2(TreeNode root)
        {
            /*
             * 解题思路：遍历树的各个结点，搜集数据；排序后输出第二小的数字
             * 时间复杂度：O(nlogn)
             * 空间复杂度：O(n)
             * 
             * 此种方式，没有很好的利用树自下而上逐渐变小的规律，不太好
             */

            HashSet<int> nums = new HashSet<int>();
            Reverse(root, nums);

            var list = nums.OrderBy(i => i).Take(2).ToList();
            if (list.Count < 2) return -1;
            else return list[1];
        }

        private void Reverse(TreeNode root, HashSet<int> nums)
        {
            /*
             * 根->左->右 的循环遍历方式
             */

            if (root == null) return;
            nums.Add(root.val);

            Reverse(root.left, nums);
            Reverse(root.right, nums);
        }
    }
}
