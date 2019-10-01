using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem143 : IProblem
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

            ReorderList(n1);
        }

        public void ReorderList(ListNode head)
        {
            /*
             * 单链表对折后重排
             * 思路：
             *  1.找到链表的中点
             *  2.将中点之后的链表，做反转
             *  3.重新拼接两个只有一半的链表
             *  
             * 时间复杂度：O(n)，找中点和反转，是对链表的一次遍历，然后凭借是有一次的遍历
             * 空间复杂度：O(1)，使用大小固定的额外空间
             * 
             * 指针职责思考：
             *  1.使用快慢指针 pFast 和 pSlow 定位链表的中点
             *      1.1 链表长度为偶数，pSlow后面的开始反转
             *      1.2 链表长度为奇数，pSlow后面的来势反转
             *  2.pLastHalfHead 是后半段的头指针
             *  3.pLastHalfCur 是后半段正在处理的指针，它会不断的插入到头的位置
             *  
             *  4.pPreHalfHead 是前半段的头指针
             *  5.pPreHalfMade 是前半段正在处理的节点
             *  
             *  6.pLastHalfMade 是后半段正在处理的指针
             *  
             *  7.pTotal 是最后拼接的头指针
             *  8.pTail 是最后拼接结果的尾指针
             */

            //至少有3个节点，这样的重排才是有意义的
            if (head == null || head.next == null || head.next.next == null) return;

            ListNode pPreHalfHead = new ListNode(-1);
            pPreHalfHead.next = head;

            ListNode pFast = pPreHalfHead;
            ListNode pSlow = pPreHalfHead;
            while (pFast.next != null && pFast.next.next != null)
            {
                pSlow = pSlow.next;
                pFast = pFast.next.next;
            }

            ListNode pLastHalfHead = new ListNode(-1);
            while (pSlow.next != null)
            {
                var pLastHalfCur = pSlow.next;
                pSlow.next = pSlow.next.next;

                pLastHalfCur.next = pLastHalfHead.next;
                pLastHalfHead.next = pLastHalfCur;
            }

            ListNode pTotal = new ListNode(-1);
            ListNode pTail = pTotal;

            while (pPreHalfHead.next != null || pLastHalfHead.next != null)
            {
                if (pPreHalfHead.next != null)
                {
                    ListNode pPreHalfMade = pPreHalfHead.next;
                    pPreHalfHead.next = pPreHalfHead.next.next;

                    pTail.next = pPreHalfMade;
                    pTail = pTail.next;
                }

                if (pLastHalfHead.next != null)
                {
                    ListNode pLastHalfMade = pLastHalfHead.next;
                    pLastHalfHead.next = pLastHalfHead.next.next;

                    pTail.next = pLastHalfMade;
                    pTail = pTail.next;
                }
            }

            head = pTotal.next;
        }
    }
}
