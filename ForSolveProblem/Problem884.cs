using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem884 : IProblem
    {
        public void RunProblem()
        {
            var temp = UncommonFromSentences("this apple is sweet", "this apple is sour");

            temp = UncommonFromSentences("apple apple", "banana");
        }

        public string[] UncommonFromSentences(string A, string B)
        {
            /*
             * 寻找两个句子中的不常见单词
             * 思路：
             *  1.题目中对不常见单词的定义是：在自己的句子中只出现过1次，同时在另一个句子中，没有出现过
             *  2.所以我们需要一个方法来分析两个句子，得到一个哈希的统计结果
             *  3.那么分别在两份结果中寻找满足条件的单词即可
             *  
             * 时间复杂度：O(n+m)
             * 空间复杂度：O(n+m)
             */

            var aDic = AnalyzedSentance(A);
            var bDic = AnalyzedSentance(B);

            var forReturn = new List<string>();
            foreach (var aDicItem in aDic)
            {
                if (bDic.ContainsKey(aDicItem.Key))
                {
                    bDic.Remove(aDicItem.Key);
                    continue;
                }

                if (aDicItem.Value > 1) continue;
                forReturn.Add(aDicItem.Key);
            }

            foreach(var bDicItem in bDic)
            {
                if (bDicItem.Value > 1) continue;
                forReturn.Add(bDicItem.Key);
            }

            return forReturn.ToArray();
        }

        private IDictionary<string,int> AnalyzedSentance(string s)
        {
            var forReturn = new Dictionary<string, int>();
            var wordsArray = s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach(var wordItem in wordsArray)
            {
                if (!forReturn.ContainsKey(wordItem)) forReturn[wordItem] = 0;
                forReturn[wordItem]++;
            }

            return forReturn;
        }
    }
}
