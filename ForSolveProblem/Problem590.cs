using System;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem590 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public IList<int> Postorder(Node root)
        {
            var forReturn = new List<int>();
            if (root == null) return forReturn;

            var stack = new Stack<Node>();
            stack.Push(root);
            while (stack.Any())
            {
                var curNode = stack.Pop();

                if(curNode.children == null)
                {
                    forReturn.Add(curNode.val);
                    continue;
                }

                var child = curNode.children;

                curNode.children = null;
                stack.Push(curNode);

                for (var i = child.Count - 1; i >= 0; i--)
                    stack.Push(child[i]);
            }

            return forReturn;
        }

        public IList<int> Postorder1(Node root)
        {
            m_list = new List<int>();
            Dfs(root);
            return m_list;
        }

        private List<int> m_list;

        private void Dfs(Node root)
        {
            if (root == null) return;

            foreach (var item in root.children)
                Dfs(item);

            m_list.Add(root.val);
        }
    }
}
