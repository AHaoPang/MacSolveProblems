using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem117 : IProblem
    {
        public Problem117()
        {
        }

        public void RunProblem()
        {
            throw new NotImplementedException();
        }

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

        public Node Connect(Node root)
        {
            if (root == null) return root;

            var leftMost = root;
            while (true)
            {
                var newLeftNode = leftMost.left ?? leftMost.right;
                while (newLeftNode == null && leftMost.next != null)
                {
                    leftMost = leftMost.next;
                    newLeftNode = leftMost.left ?? leftMost.right;
                }
                if (newLeftNode == null)
                    break;

                var curNode = newLeftNode;
                if (leftMost.left != null && leftMost.right != null)
                {
                    curNode.next = leftMost.right;
                    curNode = leftMost.right;
                }

                while (leftMost.next != null)
                {
                    if (leftMost.next.left != null)
                    {
                        curNode.next = leftMost.next.left;
                        curNode = leftMost.next.left;
                    }

                    if (leftMost.next.right != null)
                    {
                        curNode.next = leftMost.next.right;
                        curNode = leftMost.next.right;
                    }

                    leftMost = leftMost.next;
                }

                leftMost = newLeftNode;
            }

            return root;
        }

        public Node Connect1(Node root)
        {
            if (root == null) return root;

            var queue = new Queue<Node>();
            queue.Enqueue(root);
            while (queue.Any())
            {
                var count = queue.Count;
                for (var i = 0; i < count; i++)
                {
                    var curNode = queue.Dequeue();
                    if (i < count - 1)
                        curNode.next = queue.Peek();

                    if (curNode.left != null)
                        queue.Enqueue(curNode.left);
                    if (curNode.right != null)
                        queue.Enqueue(curNode.right);
                }
            }

            return root;
        }
    }
}
