using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem206 : IProblem
    {

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }

        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public ListNode ReverseList(ListNode head)
        {
            /*
             * 链表反转，方法二：递归法
             * 将业务操作看作是重复的解决子问题：已经反转好的链表，再加上当前的结点
             * 时间复杂度：O(n),即要处理每个链表结点
             * 空间复杂度：O(n)，即需要递归n次，是一个n层循环
             */

            //end point
            if (head == null || head.next == null) return head;//当进入到最末一个节点时，当前节点就是新的头指针了~

            //reverse operate
            var newHead = ReverseList(head.next);
            //需要修改当前结点了
            head.next.next = head;
            head.next = null;

            //return 
            return newHead;
        }

        public ListNode ReverseList2(ListNode head)
        {
            /*
             * 链表反转，方法一：迭代法，即循环的方式
             * key point：涉及3个指针的责任交替
             * 时间复杂度：O(n)
             * 空间复杂度：O(1)
             * 
             * 总结：循环过程中，包含两部分操作
             * 1.链表相关的操作；
             * 2.指针相关的操作；
             */

            ListNode newListNode = null;
            ListNode curListNode = head;
            ListNode nextListNode = null;

            while(curListNode != null)
            {
                nextListNode = curListNode.next;

                //链表相关的操作
                curListNode.next = newListNode;

                newListNode = curListNode;
                curListNode = nextListNode;
            }

            return newListNode;
        }
    }
}
