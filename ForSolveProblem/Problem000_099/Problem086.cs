using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem086 : IProblem
    {
        public void RunProblem()
        {
            ListNode p1 = new ListNode(1);
            ListNode p2 = new ListNode(4);
            ListNode p3 = new ListNode(3);
            ListNode p4 = new ListNode(2);
            ListNode p5 = new ListNode(5);
            ListNode p6 = new ListNode(2);

            p1.next = p2;
            p2.next = p3;
            p3.next = p4;
            p4.next = p5;
            p5.next = p6;

            var temp = Partition(p1, 3);
        }

        public ListNode Partition1(ListNode head, int x)
        {
            /*
             * 依据特定值来分隔链表，但是要保证链表的相对位置不变
             * 思路：
             *  1.基本上就是两步走：
             *  2.第1步：把小于目标值的节点挑出去，单独拼接起来；
             *  3.第2步：把挑出去的链表拼接到链表的头部；
             *  
             * 时间复杂度：O(n)，把链表遍历一遍
             * 空间复杂度：O(1)，使用的额外空间，大小固定
             * 
             * 指针职责思考：
             *  1.pminHead，是小值链表的头
             *  2.pminTail，是小值链表的尾
             *  3.pnormalHead，是输入的链表头
             *  4.pnormalPre，是当前正在判断的节点的前一个
             *  5.pnormalCur，是当前正在判断的节点
             */

            ListNode pMinHead = new ListNode(-1);
            ListNode pMinTail = pMinHead;

            ListNode pNormalHead = new ListNode(-1);
            pNormalHead.next = head;
            ListNode pNormalPre = pNormalHead;

            while (pNormalPre.next != null)
            {
                var pNormalCur = pNormalPre.next;

                if (pNormalCur.val < x)
                {
                    pNormalPre.next = pNormalCur.next;
                    pMinTail.next = pNormalCur;
                    pMinTail = pNormalCur;
                }
                else
                {
                    pNormalPre = pNormalPre.next;
                }
            }

            pMinTail.next = pNormalHead.next;
            pNormalHead.next = pMinHead.next;

            return pNormalHead.next;
        }

        public ListNode Partition(ListNode head, int x)
        {
            var big = new ListNode(0);
            var bigHead = big;
            var small = new ListNode(0);
            var smallHead = small;

            while (head != null)
            {
                if (head.val >= x)
                {
                    bigHead.next = head;
                    bigHead = head;
                }
                else
                {
                    smallHead.next = head;
                    smallHead = head;
                }

                head = head.next;
            }

            smallHead.next = big.next;
            bigHead.next = null;
            return small.next;
        }
    }
}
