using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem345 : IProblem
    {
        public void RunProblem()
        {
            var temp = ReverseVowels("hello");
            if (temp != "holle") throw new Exception();

            temp = ReverseVowels("leetcode");
            if (temp != "leotcede") throw new Exception();

            temp = ReverseVowels(" ");
            if (temp != " ") throw new Exception();

            temp = ReverseVowels("a.");
            if (temp != "a.") throw new Exception();

            temp = ReverseVowels("a a");
            if (temp != "a a") throw new Exception();
        }

        public string ReverseVowels(string s)
        {
            /*
             * 元音字母反转
             * 思路：
             *  1.元音字母，包括大小写，一共有10个
             *  2.将前后的元音字母反转
             *  3.采用双指针法，两个指针都指向的是元音字母，然后直到他俩相遇表示结束
             *  
             * 时间复杂度：O(n)，整个字符串要遍历一遍的，元音字母由于存在hastTable中，所以查找的复杂度是O(1)
             * 空间复杂度：O(1)，使用额外的存储空间大小是固定的
             */

            HashSet<char> vowels = new HashSet<char>();
            vowels.Add('a'); vowels.Add('A');
            vowels.Add('e'); vowels.Add('E');
            vowels.Add('i'); vowels.Add('I');
            vowels.Add('o'); vowels.Add('O');
            vowels.Add('u'); vowels.Add('U');


            List<char> forReturnChar = new List<char>(s);
            int firstIndex = 0;
            int lastIndex = s.Length - 1;
            while (firstIndex < lastIndex)
            {
                while (firstIndex < s.Length && !vowels.Contains(s[firstIndex]))
                    firstIndex++;

                while (lastIndex >= 0 && !vowels.Contains(s[lastIndex]))
                    lastIndex--;

                if (firstIndex < lastIndex)
                {
                    forReturnChar[firstIndex] = s[lastIndex];
                    forReturnChar[lastIndex] = s[firstIndex];
                }

                firstIndex++;
                lastIndex--;
            }

            return string.Join("", forReturnChar);
        }
    }
}
