using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem147 : IProblem
    {
        public void RunProblem()
        {
            ListNode n1 = new ListNode(4);
            ListNode n2 = new ListNode(2);
            ListNode n3 = new ListNode(1);
            ListNode n4 = new ListNode(3);

            n1.next = n2;
            n2.next = n3;
            n3.next = n4;

            var temp = InsertionSortList(n1);
        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }

        public ListNode InsertionSortList(ListNode head)
        {
            /*
             * 对链表做插入排序
             * 思路：
             *  1.相当于将链表一个个的从一个无序的位置，移动到有序的位置
             *  2.涉及链表节点的删除、链表节点的插入
             *  
             * 时间复杂度：O(n^2)
             * 空间复杂度：O(1)
             * 
             * 职责思考：
             *  1.新建位置，需要两个虚拟指针，分别指向头和尾
             *  2.需要一个可以遍历原始链表的指针
             *  3.需要一个可以顺序遍历，并得到插入位置的方法
             */

            ListNode dummy = new ListNode(-1);
            var tail = dummy;

            /* 开始遍历给定的链表 */
            var curNode = head;
            while (curNode != null)
            {
                var nodeTemp = curNode;
                curNode = curNode.next;
                nodeTemp.next = null;

                //如果是第一个移动过去的，那么直接拼接就好了
                if (tail == dummy)
                {
                    dummy.next = nodeTemp;
                    tail = nodeTemp;
                    continue;
                }

                //如果比新的链表的最后一个还大，那么直接拼接到最后
                if (tail.val <= nodeTemp.val)
                {
                    tail.next = nodeTemp;
                    tail = nodeTemp;
                    continue;
                }

                //从前往后遍历，为了找到合适的插入位置
                var preNode = dummy;
                var nextNode = dummy.next;
                while (nextNode != null)
                {
                    if (nextNode.val > nodeTemp.val) break;

                    nextNode = nextNode.next;
                    preNode = preNode.next;
                }

                if (preNode == tail) tail = nodeTemp;

                nodeTemp.next = preNode.next;
                preNode.next = nodeTemp;
            }

            return dummy.next;
        }
    }
}
