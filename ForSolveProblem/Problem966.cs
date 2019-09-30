using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem966 : IProblem
    {
        public void RunProblem()
        {
            var temp = Spellchecker(new string[] { "KiTe", "kite", "hare", "Hare" }, new string[] { "kite", "Kite", "KiTe", "Hare", "HARE", "Hear", "hear", "keti", "keet", "keto" });
            if (!ProblemHelper.ArrayIsEqual(temp, new string[] { "kite", "KiTe", "KiTe", "Hare", "hare", "", "", "KiTe", "", "KiTe" }, false)) throw new Exception();

        }

        public string[] Spellchecker(string[] wordlist, string[] queries)
        {
            /*
             * 依据查询词来判断，期望中的单词是哪个
             * 思路：
             *  1.单词列表是一个常用单词的热度排序
             *  2.查询列表是用户的输入
             *      2.1 用户知道自己输入的是什么，所以输入是很准确的，所以我们考虑使用HashSet来存储单词列表
             *      2.2 用户对大小写不敏感，所以输入的单词大小写不准确，所以考虑只存小写字母的Dictionary好了
             *      2.3 用户对元音不敏感，所以可以考虑让Dictionay忽略元音
             * 
             * 时间复杂度：O(m+n)，m 和 n 表示的但是单词列表的个数 和 查询词的个数
             * 空间复杂度：O(m+n)
             */

            var wordSet = new HashSet<string>();
            var wordDic = new Dictionary<string, string>();
            foreach (var wordItem in wordlist)
            {
                wordSet.Add(wordItem);

                if (!wordDic.ContainsKey(wordItem.ToLower())) wordDic[wordItem.ToLower()] = wordItem;

                var transResultTemp = TransformChar(wordItem);
                if (!string.IsNullOrWhiteSpace(transResultTemp) && !wordDic.ContainsKey(transResultTemp))
                    wordDic[transResultTemp] = wordItem;
            }

            var forReturn = new string[queries.Length];
            for (int i = 0; i < queries.Length; i++)
            {
                var wordTemp = queries[i];
                if (wordSet.Contains(wordTemp))
                {
                    forReturn[i] = wordTemp;
                    continue;
                }

                var wordToLower = wordTemp.ToLower();
                if (wordDic.ContainsKey(wordToLower))
                {
                    forReturn[i] = wordDic[wordToLower];
                    continue;
                }

                var transResult = TransformChar(wordTemp);
                if (!string.IsNullOrWhiteSpace(transResult) && wordDic.ContainsKey(transResult))
                {
                    forReturn[i] = wordDic[transResult];
                    continue;
                }

                forReturn[i] = "";
            }

            return forReturn;
        }

        private int m_distance = 'a' - 'A';
        private ISet<char> m_tupChar = new HashSet<char>()
        {
            'a', 'e', 'i', 'o', 'u',
            'A', 'E', 'I', 'O', 'U'
        };

        private string TransformChar(string inputStr)
        {
            var forReturn = new char[inputStr.Length];
            var isTrans = false;
            for (int i = 0; i < inputStr.Length; i++)
            {
                var charTemp = inputStr[i];
                if (charTemp < 'a') charTemp = (char)(charTemp + m_distance);
                if (m_tupChar.Contains(charTemp))
                {
                    isTrans = true;
                    charTemp = '-';
                }

                forReturn[i] = charTemp;
            }

            return isTrans ? new string(forReturn) : string.Empty;
        }
    }
}
