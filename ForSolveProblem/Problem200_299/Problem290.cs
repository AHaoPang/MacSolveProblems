using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem290 : IProblem
    {
        public void RunProblem()
        {
            var temp = WordPattern("abba", "dog cat cat dog");
            if (temp != true) throw new Exception();

            temp = WordPattern("abba", "dog cat cat fish");
            if (temp != false) throw new Exception();

            temp = WordPattern("aaaa", "dog cat cat dog");
            if (temp != false) throw new Exception();

            temp = WordPattern("abba", "dog dog dog dog");
            if (temp != false) throw new Exception();
        }

        public bool WordPattern(string pattern, string str)
        {
            /*
             * 字符与字符串之间的模式匹配
             * 思路：
             *  1.在字符与字符串之间建立双向映射关系
             *  
             * 时间复杂度：O(n)
             * 空间复杂度：O(n)
             */

            //先做简单的切割
            string[] wordArr = str.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (wordArr.Length != pattern.Length) return false;

            //开始做一一匹配
            Dictionary<char, string> cToS = new Dictionary<char, string>();
            Dictionary<string, char> sToC = new Dictionary<string, char>();
            for (int i = 0; i < wordArr.Length; i++)
            {
                if (cToS.ContainsKey(pattern[i])) if (cToS[pattern[i]] != wordArr[i]) return false;
                if (sToC.ContainsKey(wordArr[i])) if (sToC[wordArr[i]] != pattern[i]) return false;

                cToS[pattern[i]] = wordArr[i];
                sToC[wordArr[i]] = pattern[i];
            }

            return true;
        }
    }
}
