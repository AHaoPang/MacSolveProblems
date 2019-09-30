using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem025 : IProblem
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
            var n5 = new ListNode(5);

            n1.next = n2;
            n2.next = n3;
            n3.next = n4;
            n4.next = n5;

            var temp = ReverseKGroup(n1, 2);
        }

        public ListNode ReverseKGroup(ListNode head, int k)
        {
            var headTemp = new ListNode(-1);
            headTemp.next = head;
            Recursive(headTemp, k);
            return headTemp.next;
        }

        private void Recursive(ListNode preNode, int k)
        {
            /*
             * 反转思路说明：
             * 1.要明确，反转的是哪个范围里面的结点；
             * 2.反转的具体过程是：
             *      2.1 直接指向尾
             *      2.2 断掉的部分依次遍历，插入到起始的位置
             *      
             * 里面使用到了递归的思想，即链表不管有多长，始终反转特定长度的一段，然后不断的重复做相同的事情，直到全部检查一遍并反转完成
             * 
             * 实现原则：
             * 1.明确各个指针的含义和职责，不要去变动
             * 2.各个指针自身演变的时候，多做思考
             * 3.深刻的去理解指针的移动，与，结点的移动 的关系
             * 
             * 时间复杂度：O(n) 其实是遍历了3次的样子
             * 空间复杂度：O(1)
             */

            //定位被反转链表的结束为止
            var lastNode = preNode;
            int i = 0;
            for (; i < k; i++)
            {
                if (lastNode.next == null) break;

                lastNode = lastNode.next;
            }
            //说明长度达不到反转的标准k，因此结束
            if (i != k) return;

            //将前驱结点与结束结点一起连到结束的位置
            var nextNode = preNode.next;
            preNode.next = lastNode.next;

            //开始遍历断掉的分支部分
            var stopNode = lastNode.next;
            while (nextNode != stopNode)
            {
                var readyNode = nextNode;
                nextNode = nextNode.next;

                readyNode.next = preNode.next;
                preNode.next = readyNode;
            }

            //移动preNode k 次，递归的去检查一下段
            for (int j = 0; j < k; j++) preNode = preNode.next;
            Recursive(preNode, k);
        }
    }
}
