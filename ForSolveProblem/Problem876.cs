using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem876 : IProblem
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

        public ListNode MiddleNode(ListNode head)
        {
            /*
             * 返回链表中间节点及其之后的节点
             * 思路：
             *  1.是快慢指针的一个应用
             *  2.当链表节点数字个数为
             *      2.1 奇数，快指针可以中断循环
             *      2.2 偶数，快指针同样可以中断循环
             *      
             * 时间复杂度：O(n)
             * 空间复杂度：O(1)
             */

            ListNode dummy = new ListNode(-1);
            dummy.next = head;

            ListNode slow = dummy;
            ListNode fast = dummy;

            while(fast != null)
            {
                slow = slow.next;

                fast = fast.next;
                if (fast == null) break;
                fast = fast.next;
            }

            return slow;
        }
    }
}
