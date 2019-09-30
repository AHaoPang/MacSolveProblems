using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem138 : IProblem
    {
        public class Node
        {
            public int val;
            public Node next;
            public Node random;

            public Node() { }
            public Node(int _val, Node _next, Node _random)
            {
                val = _val;
                next = _next;
                random = _random;
            }
        }

        public void RunProblem()
        {
            Node n1 = new Node();
            n1.val = 1;

            Node n2 = new Node();
            n2.val = 2;

            n1.next = n2;
            n1.random = n2;

            n2.random = n2;

            var temp = CopyRandomList(n1);
        }

        public Node CopyRandomList(Node head)
        {
            /*
             * 复杂链表的拷贝
             * 思路：
             *  1.第一步，double原来的链表，依据next做拷贝
             *  2.第二步，拷贝原来的random
             *  3.第三步，拆分拷贝链表
             *  
             * 时间复杂度：O(n)
             * 空间复杂度：O(1)，因为并不使用额外的存储空间
             */

            Node oldNodeHead = new Node();
            oldNodeHead.next = head;

            Node oldNodeTail = oldNodeHead;
            while(oldNodeTail.next != null)
            {
                oldNodeTail = oldNodeTail.next;

                var newNodeTemp = new Node(oldNodeTail.val, oldNodeTail.next, null);
                oldNodeTail.next = newNodeTemp;

                oldNodeTail = newNodeTemp;
            }

            oldNodeTail = oldNodeHead;
            while(oldNodeTail.next != null)
            {
                oldNodeTail = oldNodeTail.next;

                if (oldNodeTail.random != null)
                    oldNodeTail.next.random = oldNodeTail.random.next;

                oldNodeTail = oldNodeTail.next;
            }

            Node newNodeHead = new Node();
            Node newNodeTail = newNodeHead;

            oldNodeTail = oldNodeHead;
            while(oldNodeTail.next != null)
            {
                oldNodeTail = oldNodeTail.next;

                newNodeTail.next = oldNodeTail.next;

                if (oldNodeTail.next != null)
                    oldNodeTail.next = oldNodeTail.next.next;

                newNodeTail = newNodeTail.next;
            }

            return newNodeHead.next;
        }

        public Node CopyRandomList3(Node head)
        {
            /*
             * 复杂链表的拷贝问题
             * 思路：
             *  1.把复杂链表看成是一个特殊的二叉树，两个指针分别叫做next和random
             *  2.复杂链表的拷贝，可以看做是树的遍历过程
             *  3.按图索骥的感觉，使用递归的方式，思路意外的清晰
             *  
             * 时间复杂度：O(n)，所有的节点都是要过一遍的
             * 空间复杂度：O(n)，要额外的存储新旧节点的映射关系
             */

            return Recursive(new Dictionary<Node, Node>(), head);
        }

        private Node Recursive(Dictionary<Node, Node> oldToNewNodeDic, Node oldNode)
        {
            if (oldNode == null) return null;
            if (oldToNewNodeDic.ContainsKey(oldNode)) return oldToNewNodeDic[oldNode];

            Node newNodeTemp = new Node(oldNode.val, null, null);
            oldToNewNodeDic[oldNode] = newNodeTemp;

            newNodeTemp.next = Recursive(oldToNewNodeDic, oldNode.next);
            newNodeTemp.random = Recursive(oldToNewNodeDic, oldNode.random);

            return newNodeTemp;
        }

        public Node CopyRandomList2(Node head)
        {
            /*
             * 复杂链表的拷贝问题
             * 思路：
             *  1.用循环的方式，循环主线节点，并把相关的节点一并创建
             *  
             * 时间复杂度：O(n)，与链表节点个数有关
             * 空间复杂度：O(n)，需要建立新旧节点的映射关系
             */

            Node oldHead = new Node();
            oldHead.next = head;
            Node oldHeadTail = oldHead;

            Node newHead = new Node();
            Node newHeadTail = newHead;

            Dictionary<Node, Node> oldToNewNodeDic = new Dictionary<Node, Node>();

            while (oldHeadTail.next != null)
            {
                //原链表指向下一个节点
                oldHeadTail = oldHeadTail.next;

                //复制主链表节点
                Node newNodeNext = null;
                if (oldToNewNodeDic.ContainsKey(oldHeadTail))
                    newNodeNext = oldToNewNodeDic[oldHeadTail];

                if (newNodeNext == null)
                {
                    newNodeNext = new Node(oldHeadTail.val, null, null);
                    oldToNewNodeDic[oldHeadTail] = newNodeNext;
                }

                //复制指向的随机节点
                if (oldHeadTail.random != null)
                {
                    Node newNodeRandom = null;
                    if (oldToNewNodeDic.ContainsKey(oldHeadTail.random))
                        newNodeRandom = oldToNewNodeDic[oldHeadTail.random];

                    if (newNodeRandom == null)
                    {
                        newNodeRandom = new Node(oldHeadTail.random.val, null, null);
                        oldToNewNodeDic[oldHeadTail.random] = newNodeRandom;
                    }

                    newNodeNext.random = newNodeRandom;
                }

                //将新的节点添加到新的链表中
                newHeadTail.next = newNodeNext;
                newHeadTail = newHeadTail.next;
            }

            return newHead.next;
        }

        public Node CopyRandomList1(Node head)
        {
            /*
             * 深度拷贝一个带随机指针的链表
             * 思路：
             *  1.分析下带随机指针的链表，它有且只有一个主链表，然后就是随机的指针了；
             *  2.如果是单链表，那么问题的处理很简单很多~，现在加上了一个随机指针~
             *  3.考虑先复制主链表，并建立新旧链表地址的映射关系，再复制随机指针
             *  
             * 时间复杂度：O(n)，总共需要遍历两次链表
             * 空间复杂度：O(n)，我们要建立每个地址的映射关系
             */

            //复制主链表，并建立映射关系
            Node newHead = new Node();
            Node newHeadTail = newHead;

            Dictionary<Node, Node> dicOldToNewNode = new Dictionary<Node, Node>();

            Node oldHead = new Node();
            oldHead.next = head;

            Node oldHeadTail = oldHead;
            while (oldHeadTail.next != null)
            {
                oldHeadTail = oldHeadTail.next;

                var newTemp = new Node();
                newTemp.val = oldHeadTail.val;

                newHeadTail.next = newTemp;
                newHeadTail = newHeadTail.next;

                dicOldToNewNode[oldHeadTail] = newTemp;
            }

            oldHeadTail = oldHead;
            newHeadTail = newHead;
            while (oldHeadTail.next != null)
            {
                oldHeadTail = oldHeadTail.next;
                newHeadTail = newHeadTail.next;

                if (oldHeadTail.random != null) newHeadTail.random = dicOldToNewNode[oldHeadTail.random];
            }

            return newHead.next;
        }
    }
}
