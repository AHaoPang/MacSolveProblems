using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem430 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public class Node
        {
            public int val;
            public Node prev;
            public Node next;
            public Node child;

            public Node() { }
            public Node(int _val, Node _prev, Node _next, Node _child)
            {
                val = _val;
                prev = _prev;
                next = _next;
                child = _child;
            }
        }

        public Node Flatten(Node head)
        {
            /*
             * 将一个包含子链表的双向链表拼接起来
             * 思路：
             *  1.给了一个双向链表的头，期望返回一个单纯的双向链表
             *  2.问题是存在子链表，那么就期望子链表也能像自己一样去返会
             *  3.然后将子链表的返回拼接到自己的上面
             *  
             * 时间复杂度：O(n)
             * 空间复杂度：O(1)
             * 
             * 职责思考：
             *  1.递归方法，给你头节点，期望返回一个链表的头指针和尾指针
             *  2.父要准确将子链表插入到自己的链表中
             */

            return Recursive(head).Item1;
        }

        private Tuple<Node, Node> Recursive(Node n)
        {
            /* 遍历自身，寻找子链表 */
            Node head = n;
            Node curNode = head;
            Node tail = n;
            while (curNode != null)
            {
                var nodeTemp = curNode;
                tail = nodeTemp;

                //指向下一个打算遍历的位置
                curNode = curNode.next;

                if (nodeTemp.child == null) continue;

                var resultTemp = Recursive(nodeTemp.child);

                nodeTemp.child = null;

                //把子链表拼接到自己的链表上
                resultTemp.Item2.next = nodeTemp.next;
                if (nodeTemp.next != null) nodeTemp.next.prev = resultTemp.Item2;

                nodeTemp.next = resultTemp.Item1;
                resultTemp.Item1.prev = nodeTemp;

                tail = resultTemp.Item2;
            }

            return Tuple.Create(head, tail);
        }
    }
}
