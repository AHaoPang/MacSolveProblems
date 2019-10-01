using System;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem1019 : IProblem
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

        public int[] NextLargerNodes(ListNode head)
        {
            /*
             * 找寻链表下一个更大节点的值
             * 思路：
             *  1.是对栈的一个应用
             *  2.需要用栈来解决的问题，有个特点，可追溯性，即当前的答案需要后面的结果来回答
             *  
             * 职责思考：
             *  1.一个指向被处理节点的指针，一个计数的
             *  2.一个返回结果的容器，一个栈结果用来存储当前不知道答案的节点
             *  3.构造一个结构，用来描述：位置信息 和 链表值信息
             *  
             * 时间复杂度：O(n)
             * 空间复杂度：O(n)
             */

            List<int> forReturn = new List<int>();

            ListNode dummy = new ListNode(-1);
            dummy.next = head;

            ListNode preNode = dummy;
            int posIndex = 0;
            Stack<Tuple<int, int>> stack = new Stack<Tuple<int, int>>();

            while (preNode.next != null)
            {
                var nodeValTemp = preNode.next.val;

                while (stack.Any())
                {
                    var stackNodeTemp = stack.Peek();

                    if (stackNodeTemp.Item2 >= nodeValTemp) break;

                    forReturn[stackNodeTemp.Item1] = nodeValTemp;
                    stack.Pop();
                }

                stack.Push(Tuple.Create(posIndex, nodeValTemp));
                forReturn.Add(0);

                preNode = preNode.next;
                posIndex++;
            }

            return forReturn.ToArray();
        }
    }
}
