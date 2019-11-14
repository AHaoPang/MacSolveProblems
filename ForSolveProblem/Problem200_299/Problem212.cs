using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForSolveProblem
{
    public class Problem212 : IProblem
    {
        public void RunProblem()
        {
            var temp = FindWords(new char[][]
            {
                new char[]{'o','a','a','n'},
                new char[]{'e','t','a','e'},
                new char[]{'i', 'h', 'k', 'r'},
                new char[]{'i','f','l','v'},
            },
            new string[] { "oath", "pea", "eat", "rain" });
            if (!ProblemHelper.ArrayIsEqual(temp.ToArray(), new string[] { "eat", "oath" })) throw new Exception();

            temp = FindWords(new char[][]
            {
                new char[]{'a','a'}
            },
            new string[] { "aaa" });
            if (!ProblemHelper.ArrayIsEqual(temp.ToArray(), new string[] { "" })) throw new Exception();
        }

        public IList<string> FindWords(char[][] board, string[] words)
        {
            /*
             * 问题:在二维网格中,找到字典中的单词
             * 思路:
             *  1.构建trie树,以每个网格位置作为单词的首字母,去trie树种去搜索单词
             *  2.trie树节点主要包含3个信息
             *      2.1 当前节点,是否表示当前单词已经结束
             *      2.2 到此节点,所表示的字符串
             *      2.3 从此节点,可以前往哪些节点
             *  3.trie树本身提供2个能力
             *      3.1 以一个节点为起始位置,前往下一个字符的节点
             *      3.2 构建Trie树的过程
             * 
             * 关键点:
             * 
             * 时间复杂度:
             * 空间复杂度:
             */

            var rows = board.Length;
            if (rows == 0) return new List<string>();
            var cols = board.First().Length;
            
            var trieRoot = new Trie();
            foreach (var wordItem in words)
                trieRoot.AddString(wordItem);

            var forReturnSets = new HashSet<string>();
            for (int i = 0; i < board.Length; i++)
                for (int j = 0; j < board[i].Length; j++)
                    RecursiveFindWords(board, i, j, trieRoot, trieRoot.Root, new bool[rows, cols], forReturnSets);

            return forReturnSets.ToList();
        }

        private void RecursiveFindWords(char[][] board, int i, int j, Trie trie, TrieNode preNode, bool[,] flags, ISet<string> wordsSet)
        {
            if (flags[i, j]) return;

            var curNode = trie.GotoNextNode(preNode, board[i][j]);
            if (curNode == null) return;

            flags[i, j] = true;

            if (curNode.IsEnd) wordsSet.Add(curNode.EndString);

            var rows = board.Length;
            var cols = board.First().Length;
            var rowArrayTemp = new int[] { -1, 1, 0, 0 };
            var colArrayTemp = new int[] { 0, 0, -1, 1 };
            for (int k = 0; k < rowArrayTemp.Length; k++)
            {
                var newI = i + rowArrayTemp[k];
                var newJ = j + colArrayTemp[k];
                if (newI < 0 || newJ < 0 || newI >= rows || newJ >= cols) continue;

                RecursiveFindWords(board, newI, newJ, trie, curNode, flags, wordsSet);
            }

            flags[i, j] = false;
        }

        /// <summary>
        /// Trie树节点
        /// </summary>
        class TrieNode
        {
            /// <summary>
            /// 是否是一个结尾
            /// </summary>
            public bool IsEnd { get; set; }

            /// <summary>
            /// 到此节点时的字符串
            /// </summary>
            public string EndString { get; set; }

            /// <summary>
            /// 前往下一个节点的路标
            /// </summary>
            public TrieNode[] nextChar = new TrieNode[26];
        }

        /// <summary>
        /// Trie树
        /// </summary>
        class Trie
        {
            public TrieNode Root { get; } = new TrieNode();

            public Trie()
            {
                Root.EndString = "";
            }

            /// <summary>
            /// 为trie树增加枝叶
            /// </summary>
            public void AddString(string addStr)
            {
                var curNode = Root;
                foreach (var strItem in addStr)
                {
                    var nextIndex = strItem - 'a';

                    if (curNode.nextChar[nextIndex] == null)
                    {
                        curNode.nextChar[nextIndex] = new TrieNode()
                        {
                            EndString = curNode.EndString + strItem
                        };
                    }

                    curNode = curNode.nextChar[nextIndex];
                }

                curNode.IsEnd = true;
            }

            /// <summary>
            /// 从一个节点,前往下一个节点
            /// </summary>
            public TrieNode GotoNextNode(TrieNode curNode, char nextChar)
            {
                var nextIndex = nextChar - 'a';
                if (curNode.nextChar[nextIndex] != null) return curNode.nextChar[nextIndex];

                return null;
            }
        }
    }
}
