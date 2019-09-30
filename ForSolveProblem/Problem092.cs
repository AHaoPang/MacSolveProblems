using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem092 : IProblem
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

        public ListNode ReverseBetween(ListNode head, int m, int n)
        {
            /*
             * 链表的部分反转实现
             * 必须的指针有3个：
             * pre：截断前的一个位置；
             * head：阶段后的一个位置；
             * next：本次要操作的位置；
             * 
             * 时间复杂度：O(n);
             * 空间复杂度：O(1);
             */

            ListNode dummy = new ListNode(0);
            dummy.next = head;

            //定位到开始的位置
            ListNode pre = dummy;
            for(int i = 1; i < m; i++)
            {
                head = head.next;
                pre = pre.next;
            }

            //循环操作节点
            ListNode next = null;
            for(int j = m;j < n; j++)
            {
                next = head.next;
                head.next = next.next;
                next.next = pre.next;
                pre.next = next;
            }

            return dummy.next;
        }
    }
}
