using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem429 : IProblem
    {
        public class Node
        {
            public int val;
            public IList<Node> children;

            public Node() { }
            public Node(int _val, IList<Node> _children)
            {
                val = _val;
                children = _children;
            }
        }

        public void RunProblem()
        {
            Node n1 = new Node();
            n1.val = 1;

            Node n2 = new Node();
            n2.val = 3;

            Node n3 = new Node();
            n3.val = 2;

            Node n4 = new Node();
            n4.val = 4;

            Node n5 = new Node();
            n5.val = 5;

            Node n6 = new Node();
            n6.val = 6;

            n1.children = new List<Node>() { n2, n3, n4 };
            n2.children = new List<Node>() { n5, n6 };

            var temp = LevelOrder(n1);
        }

        public IList<IList<int>> LevelOrder(Node root)
        {
            /*
             * n叉树的层次遍历，自左向右遍历
             * 思路：
             *  1.依然使用BFS的思想
             *  2.只使用一个队列做循环的时候，要划清层与层之间的界限
             *  
             * 时间复杂度：O(n)，需要把所有的节点遍历一遍，才能拿到所有的层次值
             * 空间复杂度：O(n)，需要把所有节点的值返回
             */

            Queue<Node> queueTemp = new Queue<Node>();
            queueTemp.Enqueue(root);

            IList<IList<int>> forReturn = new List<IList<int>>();

            while (queueTemp.Any())
            {
                var totalNum = queueTemp.Count;
                IList<int> lineNums = new List<int>();
                for(int i = 0;i < totalNum; i++)
                {
                    var nodeTemp = queueTemp.Dequeue();
                    if (nodeTemp == null) continue;

                    lineNums.Add(nodeTemp.val);

                    if (nodeTemp.children != null)
                        foreach (var childItem in nodeTemp.children)
                            queueTemp.Enqueue(childItem);
                }

                if (lineNums.Any()) forReturn.Add(lineNums);
            }

            return forReturn;
        }
    }
}
