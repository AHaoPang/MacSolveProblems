using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem061 : IProblem
    {
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }

        public void RunProblem()
        {
            ListNode n1 = new ListNode(1);
            ListNode n2 = new ListNode(2);
            ListNode n3 = new ListNode(3);
            ListNode n4 = new ListNode(4);
            ListNode n5 = new ListNode(5);

            n1.next = n2;
            n2.next = n3;
            n3.next = n4;
            n4.next = n5;

            var temp = RotateRight(n1, 2);
        }

        public ListNode RotateRight(ListNode head, int k)
        {
            /*
             * 思路：旋转k个位置，其实就相当于把右面k个节点，接到前面来就好
             * 1.了解整个链表有多长-->一轮遍历
             * 2.了解到底要偏离多少-->是一个取余的过程
             * 3.使用距离指针的方式，截取到后半段；
             * 4.把后半段，接到前面来
             * 
             * 时间复杂度：O(n)
             * 空间复杂度：O(1)
             */

            int nodeLength = 0;
            var nodeForLength = head;
            while (nodeForLength != null)
            {
                nodeLength++;
                nodeForLength = nodeForLength.next;
            }

            if (nodeLength == 0 || nodeLength == 1) return head;

            int trueMoveStep = k % nodeLength;
            if (trueMoveStep == 0) return head;

            ListNode zeroNode = new ListNode(-1);
            zeroNode.next = head;
            ListNode firstNode = zeroNode;
            ListNode lastNode = zeroNode;
            for (int i = 0; i < nodeLength; i++)
            {
                firstNode = firstNode.next;
                if (i + 1 > trueMoveStep) lastNode = lastNode.next;
            }

            ListNode newHead = lastNode.next;

            firstNode.next = head;
            lastNode.next = null;

            return newHead;
        }
    }
}
