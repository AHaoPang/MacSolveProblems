using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem109 : IProblem
    {
        public void RunProblem()
        {
            ListNode n1 = new ListNode(-10);
            ListNode n2 = new ListNode(-3);
            ListNode n3 = new ListNode(0);
            ListNode n4 = new ListNode(5);
            ListNode n5 = new ListNode(9);

            n1.next = n2;
            n2.next = n3;
            n3.next = n4;
            n4.next = n5;

            var temp = SortedListToBST(n1);
        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

        public TreeNode SortedListToBST(ListNode head)
        {
            /*
             * 将排序链表，构造成平衡二叉搜索树
             * 思路：
             *  1.借用中间的容器数组，来构造二叉搜索树
             *  
             * 时间复杂度：O(n)
             * 空间复杂度：O(n)
             */

            //先把链表数据存入数组中
            List<int> sortedArray = new List<int>();
            ListNode headTemp = head;
            while (headTemp != null)
            {
                sortedArray.Add(headTemp.val);

                headTemp = headTemp.next;
            }

            //直接读取数组中的索引来构造树
            return ModeTreeFromArray(sortedArray, 0, sortedArray.Count - 1);
        }

        private TreeNode ModeTreeFromArray(List<int> sortedArray, int leftIndex, int rightIndex)
        {
            if (leftIndex > rightIndex) return null;

            int middle = leftIndex + (rightIndex - leftIndex) / 2;

            TreeNode root = new TreeNode(sortedArray[middle]);

            root.left = ModeTreeFromArray(sortedArray, leftIndex, middle - 1);
            root.right = ModeTreeFromArray(sortedArray, middle + 1, rightIndex);

            return root;
        }
    }
}
