using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem127 : IProblem
    {
        public void RunProblem()
        {
            var temp = LadderLength("hit", "cog", new List<string>() { "hot", "dot", "dog", "lot", "log", "cog" });
            if (temp != 5) throw new Exception();

            temp = LadderLength("hit", "cog", new List<string>() { "hot", "dot", "dog", "lot", "log" });
            if (temp != 0) throw new Exception();
        }

        public int LadderLength(string beginWord, string endWord, IList<string> wordList)
        {
            /*
             * 从开始单词，到达目标单词，使用字典表中给定的单词，每次仅能走一步，最短多少步就能到达终点
             * 思路：
             *  1.这其实是一个无向无权图的问题，每个单词是一个节点，单词相连的依据是仅仅差一个字母
             *  2.对于无权无向图，最短的路径，就是经典的BFS搜索
             *  3.本地的巧妙之处，在于key是模式字符串，值是对应的单词，这样就减少了存储空间
             *  
             * 时间复杂度：O(m*n)，即单词的长度与单词的个数，预处理的耗时是最长的
             * 空间复杂度：O(m*n)，预处理的结果，是要做存储的
             */

            //预处理得到一个key-value关系
            Dictionary<string, IList<string>> formatStrDic = new Dictionary<string, IList<string>>();
            foreach (string stringItem in wordList)
            {
                for (int i = 0; i < stringItem.Length; i++)
                {
                    var formatStr = stringItem.Substring(0, i) + "-" + stringItem.Substring(i + 1);
                    if (!formatStrDic.ContainsKey(formatStr)) formatStrDic[formatStr] = new List<string>();

                    formatStrDic[formatStr].Add(stringItem);
                }
            }

            //使用BFS来做搜索
            Queue<Tuple<string, int>> bfsQueue = new Queue<Tuple<string, int>>();
            HashSet<string> hasPassed = new HashSet<string>();

            bfsQueue.Enqueue(Tuple.Create(beginWord, 1));
            hasPassed.Add(beginWord);

            while (bfsQueue.Any())
            {
                var curItem = bfsQueue.Dequeue();

                for (int i = 0; i < curItem.Item1.Length; i++)
                {
                    var formatStr = curItem.Item1.Substring(0, i) + "-" + curItem.Item1.Substring(i + 1);

                    if (!formatStrDic.ContainsKey(formatStr)) continue;

                    var words = formatStrDic[formatStr];
                    foreach (var wordItem in words)
                    {
                        if (wordItem == endWord) return curItem.Item2 + 1;

                        if (hasPassed.Contains(wordItem)) continue;
                        hasPassed.Add(wordItem);

                        bfsQueue.Enqueue(Tuple.Create(wordItem, curItem.Item2 + 1));
                    }
                }
            }

            //返回预期的结果
            return 0;
        }
    }
}
