using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ForSolveProblem
{
    public class Problem023 : IProblem
    {
        public void RunProblem()
        {
            var temp = MergeKLists(new ListNode[]
            {
                MadeList(new int[]{1,4,5}),
                MadeList(new int[]{1,3,4}),
                MadeList(new int[]{2,6})
            });
        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }

        private ListNode MadeList(int[] numArray)
        {
            var forReturn = new ListNode(0);

            var curNode = forReturn;
            for (int i = 0; i < numArray.Length; i++)
            {
                curNode.next = new ListNode(numArray[i]);

                curNode = curNode.next;
            }

            return forReturn.next;
        }

        public ListNode MergeKLists(ListNode[] lists) => lists.Length == 0 ? null : Recursion(lists, 0, lists.Length - 1);

        private ListNode Recursion(ListNode[] lists, int min, int max)
        {
            if (min == max) return lists[min];

            var middle = min + (max - min) / 2;

            var listnode1 = Recursion(lists, min, middle);
            var listnode2 = Recursion(lists, middle + 1, max);

            return MergeTwoListNode(listnode1, listnode2);
        }

        private ListNode MergeTwoListNode(ListNode listnode1, ListNode listnode2)
        {
            var node1 = listnode1;
            var node2 = listnode2;

            var forReturn = new ListNode(0);
            var curNode = forReturn;
            while (node1 != null || node2 != null)
            {
                if (node2 != null && (node1 == null || node1.val >= node2.val))
                {
                    curNode.next = node2;
                    node2 = node2.next;
                }
                else if (node1 != null && (node2 == null || node2.val >= node1.val))
                {
                    curNode.next = node1;
                    node1 = node1.next;
                }

                curNode = curNode.next;
            }

            return forReturn.next;
        }

        public ListNode MergeKLists1(ListNode[] lists)
        {
            var listCount = lists.Length;
            if (listCount == 0) return null;

            var pq = new PriorityQueue<ListNode>(false, listCount, new ComparerNode());
            for (int i = 0; i < lists.Length; i++)
                if (lists[i] != null) pq.AddData(lists[i]);

            var forReturn = new ListNode(0);
            var nodeTail = forReturn;
            while (pq.HasData())
            {
                var curNode = pq.GetData();
                nodeTail.next = curNode;

                if (curNode.next != null) pq.AddData(curNode.next);
                nodeTail = nodeTail.next;
            }

            return forReturn.next;
        }

        public class ComparerNode : Comparer<ListNode>
        {
            public override int Compare(ListNode x, ListNode y)
            {
                if (x.val == y.val) return 0;

                return x.val > y.val ? 1 : -1;
            }
        }
    }
}
