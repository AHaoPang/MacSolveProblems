using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem116 : IProblem
    {
        public class Node
        {
            public int val;
            public Node left;
            public Node right;
            public Node next;

            public Node() { }

            public Node(int _val)
            {
                val = _val;
            }

            public Node(int _val, Node _left, Node _right, Node _next)
            {
                val = _val;
                left = _left;
                right = _right;
                next = _next;
            }
        }

        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public Node Connect(Node root)
        {
            if (root == null) return root;

            var leftMost = root;
            while (leftMost.left != null)
            {
                var newLeftMost = leftMost.left;
                leftMost.left.next = leftMost.right;

                while (leftMost.next != null)
                {
                    leftMost.right.next = leftMost.next.left;

                    leftMost = leftMost.next;
                    leftMost.left.next = leftMost.right;
                }

                leftMost = newLeftMost;
            }

            return root;
        }

        public Node Connect2(Node root)
        {
            Dfs(new List<Node>(), 0, root);
            return root;
        }

        private void Dfs(List<Node> list, int curLevel, Node curNode)
        {
            if (curNode == null) return;

            if (list.Count < curLevel + 1)
                list.Add(curNode);
            else
            {
                list[curLevel].next = curNode;
                list[curLevel] = curNode;
            }

            Dfs(list, curLevel + 1, curNode.left);
            Dfs(list, curLevel + 1, curNode.right);
        }

        public Node Connect1(Node root)
        {
            if (root == null) return root;

            var queue = new Queue<Node>();
            queue.Enqueue(root);
            while (queue.Any())
            {
                var nextQueue = new Queue<Node>();
                var lastNode = queue.Dequeue();
                if (lastNode.left != null)
                {
                    nextQueue.Enqueue(lastNode.right);
                    nextQueue.Enqueue(lastNode.left);
                }

                while (queue.Any())
                {
                    var curNode = queue.Dequeue();
                    if (curNode.right != null)
                    {
                        nextQueue.Enqueue(curNode.right);
                        nextQueue.Enqueue(curNode.left);
                    }

                    curNode.next = lastNode;
                    lastNode = curNode;
                }

                if (nextQueue.Any())
                    queue = nextQueue;
            }

            return root;
        }
    }
}
