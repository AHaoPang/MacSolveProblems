using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem148 : IProblem
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

        public ListNode SortList(ListNode head)
        {
            /*
             * 对链表节点排序
             * 思路：
             *  1.给定一个链表，你是不知道它有多长的
             *  2.要求时间复杂度是O(nlogn)，那么只能是，快速排序、归并排序、堆排序，中的一种
             *  3.要求空间复杂度是O(1)
             *      3.1 快速排序，是依赖递归的，递归就一定不会是常数级别的空间复杂度
             *      3.2 归并排序，正常情况下，需要递归，但是也有不递归的方式，同时链表这种特殊的结构决定了归并甚至不需要使用额外的存储空间
             *      3.3 堆排序，从结构上来看，也是不合适的
             *      
             * key point analyzed
             *  1.需要的方法有：截断方法、合并方法
             *  2.截断的长度，一次是2的倍数
             *      
             * 时间复杂度：O(nlogn)
             * 空间复杂度：O(1)
             */

            ListNode dummy = new ListNode(-1);
            dummy.next = head;

            for (int i = 1; ; i *= 2)
            {
                int mergeCount = 0;
                var linkHead = dummy.next;
                var tailNode = dummy;
                while (true)
                {
                    var firstRange = linkHead;
                    var nextRange = GetNodes(firstRange, i);
                    linkHead = GetNodes(nextRange, i);

                    if (firstRange == null && nextRange == null) break;
                    if (firstRange != null && nextRange != null) mergeCount++;

                    var mergedRange = MergedNodes(firstRange, nextRange);
                    tailNode.next = mergedRange;

                    while (tailNode.next != null) tailNode = tailNode.next;
                }

                //若都没有归并过，那么就不要再循环了
                if (mergeCount == 0) break;
            }

            return dummy.next;
        }

        /// <summary>
        /// 将链表在指定位置处截断，返回剩余的部分
        /// </summary>
        private ListNode GetNodes(ListNode nodes, int count)
        {
            ListNode dummy = new ListNode(-1);
            dummy.next = nodes;

            for (int i = 0; i < count; i++)
            {
                if (dummy.next == null) break;
                dummy = dummy.next;
            }

            var forReturn = dummy.next;
            dummy.next = null;
            return forReturn;
        }

        /// <summary>
        /// 按照大小顺序，合并两个链表
        /// </summary>
        private ListNode MergedNodes(ListNode firstRange, ListNode secondRange)
        {
            var firstIndex = firstRange;
            var secondIndex = secondRange;

            ListNode dummy = new ListNode(-1);
            ListNode tail = dummy;

            while (firstIndex != null || secondIndex != null)
            {
                int firstValue = int.MaxValue;
                if (firstIndex != null) firstValue = firstIndex.val;

                int secondValue = int.MaxValue;
                if (secondIndex != null) secondValue = secondIndex.val;

                if (firstValue <= secondValue && firstIndex != null)
                {
                    tail.next = firstIndex;
                    firstIndex = firstIndex.next;
                }
                else
                {
                    tail.next = secondIndex;
                    secondIndex = secondIndex.next;
                }

                tail = tail.next;
            }

            return dummy.next;
        }

    }
}
