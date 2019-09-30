using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem445 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }

        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            /*
             * 大数求和，数字存储在了链表中，头节点是高位
             * 思路：
             *  1.不允许修改链表的话，那么就考虑用递归回溯的特性好了
             *  
             * 时间复杂度：O(n)
             * 空间复杂度：O(n)
             */

            ListNode dummy = new ListNode(-1);

            //计算两个链表的长度
            var l1Count = GetListNodeCount(l1);
            var l2Count = GetListNodeCount(l2);

            //开始递归求和的过程
            int carryTemp = 0;
            if (l1Count >= l2Count) carryTemp = MergedNodes(l1, l2, l1Count - l2Count, dummy);
            else carryTemp = MergedNodes(l2, l1, l2Count - l1Count, dummy);

            if(carryTemp > 0)
            {
                ListNode n = new ListNode(carryTemp);
                n.next = dummy.next;
                dummy.next = n;
            }

            return dummy.next;
        }

        /// <summary>
        /// 获取链表的长度
        /// </summary>
        private int GetListNodeCount(ListNode nodes)
        {
            int count = 0;
            while (nodes != null)
            {
                count++;
                nodes = nodes.next;
            }

            return count;
        }

        /// <summary>
        /// 将两个链表做求和合并
        /// </summary>
        private int MergedNodes(ListNode longNodes, ListNode shortNodes, int diffCount, ListNode forReturn)
        {
            if (longNodes == null) return 0;

            int v1 = longNodes.val;
            int v2 = 0;
            int carryPos = 0;

            if (diffCount == 0)
            {
                v2 = shortNodes.val;
                carryPos = MergedNodes(longNodes.next, shortNodes.next, diffCount, forReturn);
            }
            else
            {
                carryPos = MergedNodes(longNodes.next, shortNodes, diffCount - 1, forReturn);
            }

            int sumTemp = v1 + v2 + carryPos;

            ListNode newNode = new ListNode(sumTemp % 10);
            newNode.next = forReturn.next;
            forReturn.next = newNode;

            return sumTemp / 10;
        }
    }
}
