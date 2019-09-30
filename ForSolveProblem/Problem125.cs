using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem125 : IProblem
    {
        public void RunProblem()
        {
            var temp = IsPalindrome("A man, a plan, a canal: Panama");
            if (temp != true) throw new Exception();

            temp = IsPalindrome("race a car");
            if (temp != false) throw new Exception();

            temp = IsPalindrome("0P");
            if (temp != false) throw new Exception();
        }

        public bool IsPalindrome(string s)
        {
            /*
             * 验证构成一个字符串的字母和数字，是否可以组成一个回文
             * 思路：
             *  1.回文表示了对称，要对称那么就将目标元素全部比较一次好了
             *  2.使用两个指针，分别从前往后 和 从后往前找 目标元素，然后比较
             *  3.结束条件是：两个指针相遇并交错
             *  4.若结束前发现不一致，则说明不是回文，反之，则是回文了
             *  
             * 时间复杂度：O(n)，主要是把字符串遍历一遍
             * 空间复杂度：O(1)，并没有使用额外的空间
             */

            int startIndex = 0;
            int endIndex = s.Length - 1;
            while (startIndex < endIndex)
            {
                while (startIndex < s.Length && !isTargetChar(s[startIndex]))
                    startIndex++;

                while (endIndex >= 0 && !isTargetChar(s[endIndex]))
                    endIndex--;

                if (startIndex < s.Length && 
                    endIndex >= 0 && 
                    s[startIndex].ToString().ToUpper() != s[endIndex].ToString().ToUpper())

                    return false;

                startIndex++;
                endIndex--;
            }

            return true;
        }

        private bool isTargetChar(char c)
        {
            return (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') || (c >= '0' && c <= '9');
        }
    }
}
