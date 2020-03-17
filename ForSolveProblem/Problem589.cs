using System;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem589 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public IList<int> Preorder(Node root)
        {
            var forReturn = new List<int>();
            if (root == null) return forReturn;

            var stackTemp = new Stack<Node>();
            stackTemp.Push(root);
            while (stackTemp.Any())
            {
                var curNode = stackTemp.Pop();

                forReturn.Add(curNode.val);

                for (var i = curNode.children.Count - 1; i >= 0; i--)
                    stackTemp.Push(curNode.children[i]);
            }

            return forReturn;
        }

        public IList<int> Preorder1(Node root)
        {
            m_list = new List<int>();
            Dfs(root);
            return m_list;
        }

        private List<int> m_list;

        private void Dfs(Node root)
        {
            if (root == null) return;

            m_list.Add(root.val);

            foreach (var item in root.children)
                Dfs(item);
        }
    }
}
