using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem024 : IProblem
    {
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }

        public void RunProblem()
        {
            var n1 = new ListNode(1);
            var n2 = new ListNode(2);
            var n3 = new ListNode(3);
            var n4 = new ListNode(4);

            n1.next = n2;
            n2.next = n3;
            n3.next = n4;

            var newListNodes = SwapPairs(n1);
        }

        public ListNode SwapPairs(ListNode head)
        {
            /*
             * 指针的操作：
             * 1.新的头指针，用来返回最后的结果；
             * 2.指向两个交换节点的指针；
             * 3.用来拼接返还的指针；
             * 若站在职责分明的角度来看，这4个指针都是必不可少的；
             * 
             * 时间复杂度：O(n)
             * 空间复杂度：O(1)
             */

            if (head == null || head.next == null) return head;

            ListNode forReturn = new ListNode(0);
            forReturn.next = head;

            var firstNode = head;
            var secondNode = firstNode.next;
            var curNode = forReturn;

            //每次循环交换两个节点
            while(firstNode != null && firstNode.next != null)
            {
                secondNode = firstNode.next;

                //节点交换
                firstNode.next = secondNode.next;
                secondNode.next = firstNode;
                curNode.next = secondNode;

                //更新各指针
                curNode = firstNode;
                firstNode = firstNode.next;
            }

            return forReturn.next;
        }
    }
}
