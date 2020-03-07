using System;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem5346 : IProblem
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
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

        public bool IsSubPath(ListNode head, TreeNode root)
        {
            var queueTemp = new Queue<QueueItemEntity>();
            queueTemp.Enqueue(new QueueItemEntity()
            {
                CurTreeNode = root,
                NodeSets = new HashSet<ListNode>() { head }
            });

            while (queueTemp.Any())
            {
                var curEntity = queueTemp.Dequeue();

                var nextSet = new HashSet<ListNode>();
                nextSet.Add(head);

                foreach (var nodeItem in curEntity.NodeSets)
                {
                    if (nodeItem.val == curEntity.CurTreeNode.val)
                    {
                        if (nodeItem.next == null) return true;

                        nextSet.Add(nodeItem.next);
                    }
                }

                if (curEntity.CurTreeNode.left != null)
                    queueTemp.Enqueue(new QueueItemEntity()
                    {
                        CurTreeNode = curEntity.CurTreeNode.left,
                        NodeSets = new HashSet<ListNode>(nextSet.ToList())
                    });

                if (curEntity.CurTreeNode.right != null)
                    queueTemp.Enqueue(new QueueItemEntity()
                    {
                        CurTreeNode = curEntity.CurTreeNode.right,
                        NodeSets = new HashSet<ListNode>(nextSet.ToList())
                    });
            }

            return false;
        }

        class QueueItemEntity
        {
            public TreeNode CurTreeNode { get; set; }

            public ISet<ListNode> NodeSets { get; set; }
        }
    }
}
