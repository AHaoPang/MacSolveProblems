using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem082 : IProblem
    {
        public void RunProblem()
        {
            var v1 = new ListNode(1);
            var v2 = new ListNode(2);
            var v3 = new ListNode(3);
            var v4 = new ListNode(3);
            var v5 = new ListNode(4);
            var v6 = new ListNode(4);
            var v7 = new ListNode(5);

            v1.next = v2;
            v2.next = v3;
            v3.next = v4;
            v4.next = v5;
            v5.next = v6;
            v6.next = v7;

            var temp = DeleteDuplicates(v1);

            var v11 = new ListNode(1);
            var v22 = new ListNode(1);
            var v33 = new ListNode(1);
            var v44 = new ListNode(2);
            var v55 = new ListNode(3);

            v11.next = v22;
            v22.next = v33;
            v33.next = v44;
            v44.next = v55;

            temp = DeleteDuplicates(v11);
        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }

        public ListNode DeleteDuplicates(ListNode head)
        {
            /*
             * 删除单链表中重复的节点-->只要节点重复，那么就是都要删除的
             * 思路：
             *  1.删除操作的大概步骤是：检测到重复，然后把重复的移除掉
             *  2.具体到细节考虑：重复节点的出现位置不同
             *      2.1 在开头 --> 可以引入一个虚拟的头节点，那么这个就相当于是“在中间”的情况了
             *      2.2 在中间
             *      2.3 在末尾 --> 和在中间并没有什么不同
             *  3.基础处理步骤是：
             *      3.1 建立重复节点前与重复节点后指针的连接
             *      
             *  时间复杂度：O(n)，毕竟所有节点都是要遍历一遍的
             *  空间复杂度：O(1)，使用大小固定的额外空间
             *  
             * 指针职责思考：
             *  1.前驱指针
             *  2.检测指针
             *  3.重复的头位置指针
             *  4.重复的尾位置指针
             *  5.自己虚拟的头节点
             */

            ListNode dummyNode = new ListNode(-1);
            dummyNode.next = head;

            ListNode preNode = dummyNode;
            ListNode checkNode = preNode.next;
            while (checkNode != null && checkNode.next != null)
            {
                //判断是否是重复节点，进而走不同的逻辑
                if (checkNode.val != checkNode.next.val)
                {
                    //探测到的节点不重复
                    preNode = checkNode;
                    checkNode = checkNode.next;
                }
                else
                {
                    //探测到的节点重复
                    ListNode dupStartNode = checkNode;
                    ListNode dupEndNode = checkNode;
                    while (dupEndNode != null && dupEndNode.val == dupStartNode.val)
                        dupEndNode = dupEndNode.next;

                    preNode.next = dupEndNode;
                    checkNode = dupEndNode;
                }
            }

            return dummyNode.next;
        }
    }
}
