using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem208 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }
    }

    public class Trie
    {
        TreeNode Root { get; }

        /** Initialize your data structure here. */
        public Trie()
        {
            Root = new TreeNode();
        }

        /** Inserts a word into the trie. */
        public void Insert(string word)
        {
            var curNode = Root;
            foreach (var item in word)
            {
                var pos = item - 'a';

                if (curNode.Nexts[pos] == null)
                    curNode.Nexts[pos] = new TreeNode(item);

                curNode = curNode.Nexts[pos];
            }
            curNode.IsWordEnd = true;
        }

        /** Returns if the word is in the trie. */
        public bool Search(string word)
        {
            var curNode = Root;
            foreach (var item in word)
            {
                var pos = item - 'a';

                if (curNode.Nexts[pos] == null) return false;

                curNode = curNode.Nexts[pos];
            }

            return curNode.IsWordEnd;
        }

        /** Returns if there is any word in the trie that starts with the given prefix. */
        public bool StartsWith(string prefix)
        {
            var curNode = Root;
            foreach (var item in prefix)
            {
                var pos = item - 'a';

                if (curNode.Nexts[pos] == null) return false;

                curNode = curNode.Nexts[pos];
            }

            return true;
        }

        private class TreeNode
    {
        public TreeNode(int arrCount = 26)
        {
            Nexts = new TreeNode[arrCount];
        }

        public TreeNode(char val, int arrCount = 26)
        {
            Val = val;
            Nexts = new TreeNode[arrCount];
        }

        public char Val { get; set; }

        public bool IsWordEnd { get; set; }

        public TreeNode[] Nexts { get; set; }
    }
    }

}
