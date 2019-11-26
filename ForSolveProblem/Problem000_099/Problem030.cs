using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem030 : IProblem
    {
        public void RunProblem()
        {
            var temp = FindSubstring("barfoothefoobarman", new string[] { "foo", "bar" });

            temp = FindSubstring("wordgoodgoodgoodbestword", new string[] { "word", "good", "best", "word" });

            temp = FindSubstring("", new string[] { });
        }

        public IList<int> FindSubstring(string s, string[] words)
        {
            /*
             * 题目概述：串联所有单词的字串
             * 
             * 思路：
             *  1.滑动窗口+Dictionary
             *  2.滑动窗口的移动,一次移动一个单词的长度距离
             *  3.一共有单词长度个滑动窗口
             *  4.对数组索引的精确控制
             *
             * 关键点：
             *  1.每个单词的长度相同
             *  2.要得到所有的起始位置
             *
             * 时间复杂度：O(n*m)
             * 空间复杂度：O(m+n)
             */

            var wordCount = words.Length;
            if (wordCount == 0) return new List<int>();

            var wordLength = words.First().Length;
            var wordDic = new Dictionary<string, int>(wordCount);
            foreach (var wordItem in words)
            {
                if (!wordDic.ContainsKey(wordItem)) wordDic[wordItem] = 0;
                wordDic[wordItem]++;
            }

            var startPosArray = Enumerable.Range(0, wordLength);
            var forReturn = new List<int>();
            foreach (var startPosItem in startPosArray)
            {
                var startIndex = startPosItem;
                var stopIndex = startIndex + wordCount * wordLength;
                var composedStrHash = new Dictionary<string, int>(wordCount);
                for (; stopIndex <= s.Length; startIndex += wordLength, stopIndex += wordLength)
                {
                    if (startIndex < wordLength)
                    {
                        for (int firstIndex = startIndex; firstIndex <= stopIndex - wordLength; firstIndex += wordLength)
                        {
                            var curStr = new string(s.Skip(firstIndex).Take(wordLength).ToArray());
                            if (!composedStrHash.ContainsKey(curStr)) composedStrHash[curStr] = 0;
                            composedStrHash[curStr]++;
                        }
                    }
                    else
                    {
                        var delStr = new string(s.Skip(startIndex - wordLength).Take(wordLength).ToArray());
                        var addStr = new string(s.Skip(stopIndex - wordLength).Take(wordLength).ToArray());

                        composedStrHash[delStr]--;
                        if (composedStrHash[delStr] == 0) composedStrHash.Remove(delStr);

                        if (!composedStrHash.ContainsKey(addStr)) composedStrHash[addStr] = 0;
                        composedStrHash[addStr]++;
                    }

                    if (VerifySame(wordDic, composedStrHash)) forReturn.Add(startIndex);
                }
            }

            return forReturn;
        }

        private bool VerifySame(IDictionary<string, int> dic1, IDictionary<string, int> dic2)
        {
            if (dic1.Count != dic2.Count) return false;

            foreach (var dic1Item in dic1)
                if (!dic2.ContainsKey(dic1Item.Key) || dic2[dic1Item.Key] != dic1Item.Value) return false;

            return true;
        }

        public IList<int> FindSubstring1(string s, string[] words)
        {
            if (words.Length == 0 || s.Length == 0) return new List<int>();

            //找到各个子串在主串中的位置
            Dictionary<string, List<int>> wordPosDic = new Dictionary<string, List<int>>();
            foreach (var wordItem in words)
            {
                int indexTemp = 0;
                while (indexTemp != -1)
                {
                    indexTemp = s.IndexOf(wordItem, indexTemp);
                    if (indexTemp != -1)
                    {
                        if (!wordPosDic.ContainsKey(wordItem))
                            wordPosDic[wordItem] = new List<int>();

                        wordPosDic[wordItem].Add(indexTemp);
                        indexTemp++;
                    }
                }

                if (!wordPosDic.ContainsKey(wordItem))
                    return new List<int>();
            }

            //if (wordPosDic.Count != words.Length) return new List<int>();

            //开始构造排列组合
            MadeLists(words, wordPosDic, 0, new List<int>());

            int stepTemp = words[0].Length;
            List<int> forReturn = new List<int>();
            //找到满足要求的组合，然后搜集其索引值，输出
            foreach (var item in sets)
            {
                var orderArray = item.OrderBy(i => i).ToList();

                var startPos = orderArray[0];
                var isTrue = true;
                for (int i = 1; i < orderArray.Count; i++)
                {
                    startPos += stepTemp;
                    if (orderArray[i] != startPos)
                    {
                        isTrue = false;
                        break;
                    }
                }

                if (isTrue)
                    forReturn.Add(orderArray[0]);
            }

            return forReturn.Distinct().ToList();
        }

        private IList<IList<int>> sets = new List<IList<int>>();

        private void MadeLists(string[] words, Dictionary<string, List<int>> dic, int index, List<int> listTemp)
        {
            //end point
            if (words.Length <= index)
            {
                sets.Add(listTemp);
                return;
            }

            string strTemp = words[index];
            foreach (var dicItem in dic[strTemp])
            {
                listTemp.Add(dicItem);
                MadeLists(words, dic, index + 1, listTemp.ToList());
                listTemp.RemoveAt(listTemp.Count - 1);
            }
        }
    }
}
