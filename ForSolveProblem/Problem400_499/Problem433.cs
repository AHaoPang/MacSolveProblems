using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem433 : IProblem
    {
        public void RunProblem()
        {
            var temp = MinMutation("AACCGGTT", "AACCGGTA", new string[] { "AACCGGTA" });
            if(temp != 1) throw new Exception();

            temp = MinMutation("AACCGGTT", "AAACGGTA", new string[] { "AACCGGTA", "AACCGCTA", "AAACGGTA" });
            if (temp != 2) throw new Exception();

            temp = MinMutation("AAAAACCC", "AACCCCCC", new string[] { "AAAACCCC", "AAACCCCC", "AACCCCCC" });
            if (temp != 3) throw new Exception();
        }

        public int MinMutation(string start, string end, string[] bank)
        {
            var wordList = bank.ToList();
            var beginWord = start;
            var endWord = end;

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
                        if (wordItem == endWord) return curItem.Item2;

                        if (hasPassed.Contains(wordItem)) continue;
                        hasPassed.Add(wordItem);

                        bfsQueue.Enqueue(Tuple.Create(wordItem, curItem.Item2 + 1));
                    }
                }
            }

            //返回预期的结果
            return -1;
        }
    }
}
