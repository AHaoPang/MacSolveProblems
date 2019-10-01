using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem409 : IProblem
    {
        public void RunProblem()
        {
            var temp = LongestPalindrome("abccccdd");
            if (temp != 7) throw new Exception();
        }

        public int LongestPalindrome(string s)
        {
            /*
             * 利用提供的字符串来构造一个最长的回文子串，返回子串的数目即可
             * 思路：
             *  1.回文的特点是：两边对称，可以的话，中间可以唯一
             *  2.那么无论一个字符的个数是奇数还是偶数，都可以放在两边偶数个，中间放1个（对于奇数而言）
             *  3.经过以上分析，这就是一个数学问题了
             *  
             * 时间复杂度：O(n)
             * 空间复杂度：O(1)
             */

            Dictionary<char, int> charCountDic = new Dictionary<char, int>();

            foreach(var sItem in s)
            {
                if (!charCountDic.ContainsKey(sItem)) charCountDic[sItem] = 0;

                charCountDic[sItem] += 1;
            }

            var forReturn = 0;
            foreach(var dicItem in charCountDic)
            {
                forReturn += dicItem.Value / 2 * 2;

                if ((dicItem.Value & 1) == 1 && (forReturn & 1) == 0) forReturn += 1;
            }

            return forReturn;
        }
    }
}
