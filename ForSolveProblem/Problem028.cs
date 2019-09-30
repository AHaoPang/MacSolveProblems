using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem028 : IProblem
    {
        public void RunProblem()
        {
            var temp = StrStr("aaaaa", "bba");
        }

        public int StrStr(string haystack, string needle)
        {
            /*
             * 判断一个子字符串在一个父字符串中的首次出现位置
             * 思路：
             *  1.可以用回溯的思路来处理；
             *  2.当一个位置与子串首字符相同时，就去深入比较
             *  3.若匹配到了，就返回，否则继续查找下去
             *  
             *  时间复杂度：父串是要遍历一遍的，子串要遍历多遍，因此是O(m*n)
             *  空间复杂度：O(1)，整个过程中，不使用额外的存储空间
             *  
             * 考察点：
             *  1.回溯的思想
             *  2.字符串匹配的相关思想
             */

            if (needle.Length == 0) return 0;

            for (int i = 0; i <= haystack.Length - needle.Length; i++)
            {
                if (haystack[i] == needle[0])
                {
                    var posIndex = DeepthMatch(haystack, i, needle);
                    if (posIndex != -1) return posIndex;
                }
            }

            return -1;
        }

        private int DeepthMatch(string haystack, int startIndex, string needle)
        {
            int i = 0;
            for (; i < needle.Length; i++)
                if (haystack.Length <= startIndex + i || haystack[startIndex + i] != needle[i]) break;

            return i == needle.Length ? startIndex : -1;
        }
    }
}
