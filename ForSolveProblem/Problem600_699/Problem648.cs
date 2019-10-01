using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem648 : IProblem
    {
        public void RunProblem()
        {
            var temp = ReplaceWords(new List<string>() { "cat", "bat", "rat" }, "the cattle was rattled by the battery");
            if (temp != "the cat was rat by the bat") throw new Exception();
        }

        public string ReplaceWords(IList<string> dict, string sentence)
        {
            /*
             * 单词替换
             * 思路：
             *  1.将句子中的“继承词”替换为“词根”
             *  2.能快速判断是否为词根的结构是HashTable
             *  3.句子中的单词，单独调用工具方法，返回字符串的结果
             */

            //字典构造
            var longInt = int.MinValue;
            var shortInt = int.MaxValue;
            var rootSet = new HashSet<string>(dict.Count);
            foreach (var dictItem in dict)
            {
                rootSet.Add(dictItem);
                longInt = Math.Max(longInt, dictItem.Length);
                shortInt = Math.Min(shortInt, dictItem.Length);
            }

            //新句子构造
            var forReturn = new StringBuilder(sentence.Length);
            var wordsArray = sentence.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var wordItem in wordsArray)
                forReturn.Append($"{TranslateWords(rootSet, longInt, shortInt, wordItem)} ");

            return forReturn.Remove(forReturn.Length - 1, 1).ToString();
        }

        private string TranslateWords(ISet<string> set, int longInt, int shortInt, string word)
        {
            for (int i = shortInt; i <= longInt && i <= word.Length; i++)
            {
                var strTemp = word.Substring(0, i);
                if (set.Contains(strTemp)) return strTemp;
            }

            return word;
        }
    }
}
