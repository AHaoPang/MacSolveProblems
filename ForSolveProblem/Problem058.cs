using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem058 : IProblem
    {
        public void RunProblem()
        {
            var temp = LengthOfLastWord("Hello World");
            if (temp != 5) throw new Exception();

            temp = LengthOfLastWord("a ");
            if (temp != 1) throw new Exception();
        }

        public int LengthOfLastWord(string s)
        {
            /*
             * 从字符串中找到最后一个单词，并返回其长度：
             * 思路：
             *  1.既然是最后一个单词，那么就逆序遍历单个字符好了
             *  2.对一个单词的定义是，不包含空格的多个连续的字母
             *  3.输入的字符串中，仅包含空格和字母
             *  4.因此自后向前遍历，在遇到空格前累计遍历的字符长度，就是题目的要求了
             *  
             * 时间复杂度：O(n)，最多就是把字符串全部遍历一遍了
             * 空间复杂度：O(1)，只需要一个计数位就好了
             * 
             * 考察点：
             *  1.字符串的相关操作?
             */

            //从后往前，定位到第一个非空格的位置
            int curPos = s.Length - 1;
            while (curPos >= 0 && s[curPos] == ' ')
                curPos--;

            //开始统计最后一个单词的长度了
            int forReturn = 0;
            while (curPos >= 0 && s[curPos] != ' ')
            {
                forReturn++;
                curPos--;
            }

            return forReturn;
        }
    }
}
