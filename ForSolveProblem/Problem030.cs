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
        }

        public IList<int> FindSubstring(string s, string[] words)
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
