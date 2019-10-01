using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem133 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public class Node
        {
            public int val;
            public IList<Node> neighbors;

            public Node() { }
            public Node(int _val, IList<Node> _neighbors)
            {
                val = _val;
                neighbors = _neighbors;
            }
        }

        private Dictionary<Node, Node> oldToNewNode = new Dictionary<Node, Node>();

        public Node CloneGraph(Node node)
        {
            /*
             * 图的深度克隆
             * 思路：
             *  1.使用DFS的搜索方法，处理每个节点
             *  2.建立新旧节点的映射关系
             *  3.要么新建节点，要么就是返回已经创建好的新节点
             *  
             * 时间复杂度：O(n)
             * 空间复杂度：O(n)
             */

            if (oldToNewNode.ContainsKey(node)) return oldToNewNode[node];

            Node newNode = new Node(node.val, null);
            oldToNewNode[node] = newNode;

            if (node.neighbors != null)
            {
                List<Node> neighborsTemp = new List<Node>();
                foreach (var nodeItem in node.neighbors)
                    neighborsTemp.Add(CloneGraph(nodeItem));

                newNode.neighbors = neighborsTemp;
            }

            return newNode;
        }
    }
}
