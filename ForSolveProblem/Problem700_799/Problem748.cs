using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem748 : IProblem
    {
        public void RunProblem()
        {
            var temp = ShortestCompletingWord("1s3 PSt", new string[] { "step", "steps", "stripe", "stepple" });
            if (temp != "steps") throw new Exception();

            temp = ShortestCompletingWord("1s3 456", new string[] { "looks", "pest", "stew", "show" });
            if (temp != "pest") throw new Exception();
        }

        public string ShortestCompletingWord(string licensePlate, string[] words)
        {
            /*
             * 找到最短完整词
             * 思路：
             *  1.首先分析牌照本身，它包含了各种字符，然后我们真正关心的是其中的“字母”，所以要分析出其字母的成分和个数
             *  2.分析出的个数，本身就是最短的极限，早发现早结束，随着这个并不会影响整体的时间复杂度
             *  3.再分析单词数组，每个单词都是小写字母组成的，那我们只统计其与牌照相同的字母好了
             *  
             * 时间复杂度：O(m+n)，相当于检查牌照和单词数组中单词每个字符
             * 空间复杂度：O(1)，基本上只存储牌照的成分分析，和，单个单词的成分分析
             */

            //先分析牌照
            var licenseLetterDic = new Dictionary<char, int>();
            var shortLength = 0;
            var distanceTemp = 'a' - 'A';
            foreach (var licenseItem in licensePlate)
            {
                if ((licenseItem >= 'a' && licenseItem <= 'z') || (licenseItem >= 'A' && licenseItem <= 'Z'))
                {
                    char lowerChar = licenseItem;
                    if (licenseItem <= 'Z') lowerChar = (char)(licenseItem + distanceTemp);

                    if (!licenseLetterDic.ContainsKey(lowerChar)) licenseLetterDic[lowerChar] = 0;
                    licenseLetterDic[lowerChar]++;
                    shortLength++;
                }
            }

            //再分析单词数组
            var forReturn = string.Empty;
            foreach (var wordItem in words)
            {
                if (!AnalyzedWord(licenseLetterDic, wordItem)) continue;

                if (forReturn == string.Empty || forReturn.Length > wordItem.Length) forReturn = wordItem;

                if (forReturn.Length == shortLength) break;
            }

            return forReturn;
        }

        private bool AnalyzedWord(IDictionary<char, int> dic, string word)
        {
            var wordLetterDic = new Dictionary<char, int>();
            foreach (var wordItem in word)
            {
                if (!dic.ContainsKey(wordItem)) continue;

                if (!wordLetterDic.ContainsKey(wordItem)) wordLetterDic[wordItem] = 0;
                wordLetterDic[wordItem]++;
            }

            foreach (var dicItem in dic)
                if (!wordLetterDic.ContainsKey(dicItem.Key) || dicItem.Value > wordLetterDic[dicItem.Key]) return false;

            return true;
        }
    }
}
