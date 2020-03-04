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
            var v1 = new ListNode(1);
            var v2 = new ListNode(2);
            var v3 = new ListNode(3);

            v1.next = v2;
            v2.next = v3;

            var temp = ReverseList(v1);
        }

        public ListNode ReverseList(ListNode head)
        {
            /*
             * ##### 1. 题目概述：反转单链表
             * 
             * ##### 2. 思路：
             *    - 特征：因为单链表是单项的,一旦连接关系断掉,后面就会消失了,所以在断掉前,要把下一个结点记录下来
             *    - 方案：考虑使用循环的方式 分别用 2 个变量记录 当前节点,下一个节点 每次先记录好下一个节点,然后让头节点指向当前节点
             *    - 结果：循环过 n 个结点以后,得到的就是所需的解
             *
             * ##### 3. 知识点：循环 单链表
             * 
             * ##### 4. 复杂度分析: 
             *    - 时间复杂度：O(n)
             *    - 空间复杂度：O(1)
             */

            var newHead = new ListNode(0);

            var curNode = head;
            while (curNode != null)
            {
                var nextNode = curNode.next;

                curNode.next = newHead.next;
                newHead.next = curNode;

                curNode = nextNode;
            }

            return newHead.next;
        }

        public ListNode ReverseList4(ListNode head)
        {
            /*
             * ##### 1. 题目概述：反转链表
             * 
             * ##### 2. 思路：
             *    - 特征：单链表之间,是通过单个指针来建立联系的,目前就是要反转这种联系
             *    - 方案：递归的思路,只要下一个结点以后的结点都反转好了,那么让自己的下一个结点指向自己就 OK 了
             *    - 结果：传入新的头结点,让最后一个节点被它指向,然后递归方法返回的是当前节点的下一个节点,让这个节点指向自己即可
             *
             * ##### 3. 知识点：递归 单链表
             * 
             * ##### 4. 复杂度分析: 
             *    - 时间复杂度：O(n)
             *    - 空间复杂度：O(n)
             */

            var newHead = new ListNode(0);
            GetNextNode(newHead, head);

            return newHead.next;
        }

        private ListNode GetNextNode(ListNode newHead, ListNode nextNode)
        {
            if (nextNode == null || nextNode.next == null)
            {
                newHead.next = nextNode;
            }
            else
            {
                var nextTemp = GetNextNode(newHead, nextNode.next);
                nextTemp.next = nextNode;
                nextNode.next = null;
            }

            return nextNode;
        }

        public ListNode ReverseList3(ListNode head)
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

            while (curListNode != null)
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
