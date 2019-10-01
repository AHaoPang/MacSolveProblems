using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem725 : IProblem
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

        public ListNode[] SplitListToParts(ListNode root, int k)
        {
            /*
             * 将链表做分隔，分隔成指定的份数
             * 思路：
             *  1.依据题意，把链表分隔成k份，而且每份要保持原始链表的连续性
             *  2.每段的长度 = (length-1)/k + 1
             *  3.那么首先要知道链表的长度，然后就是一个截取链表指定长度的方法
             */

            //得到链表的长度
            var nodeCount = GetNodeCount(root);

            //计算每段的长度（平均长度，进1法）
            var perCount = (nodeCount - 1) / k + 1;
            //计算长度不够的索引位置
            var subOne = nodeCount % k;

            //开始截取k段链表
            ListNode[] forReturn = new ListNode[k];
            var newRoot = root;
            for (int i = 0; i < k; i++)
            {
                int perCountTemp = perCount;
                if (subOne != 0 && i >= subOne) perCountTemp--;

                var curResult = CutNode(newRoot, perCountTemp);
                forReturn[i] = curResult.Item1;

                newRoot = curResult.Item2;
            }

            return forReturn;
        }

        /// <summary>
        /// 获取指定链表的长度
        /// </summary>
        private int GetNodeCount(ListNode root)
        {
            int forReturn = 0;

            while (root != null)
            {
                forReturn++;
                root = root.next;
            }

            return forReturn;
        }

        /// <summary>
        /// 切割链表的一段下来，然后返回这一段，以及剩下的段
        /// </summary>
        private Tuple<ListNode, ListNode> CutNode(ListNode root, int size)
        {
            ListNode cutPiece = root;
            ListNode cutPieceTail = root;

            int count = 0;
            while (count < size - 1)
            {
                if (cutPieceTail == null) break;
                count++;

                cutPieceTail = cutPieceTail.next;
            }

            var nextPiect = cutPieceTail?.next;
            if (cutPieceTail != null) cutPieceTail.next = null;

            return Tuple.Create(cutPiece, nextPiect);
        }

        private Tuple<ListNode, ListNode> CutNodeV2(ListNode root, int size)
        {
            /* 这种截取段数的方法，更加的直观，要几个，tail就指向几个，直接了当 */
            var dummy = new ListNode(-1);
            dummy.next = root;
            var tail = dummy;

            for (int i = 0; i < size; i++)
            {
                if (tail == null) break;

                tail = tail.next;
            }

            var nextPiece = tail?.next;
            if (tail != null) tail.next = null;

            return Tuple.Create(dummy.next, nextPiece);
        }
    }
}
