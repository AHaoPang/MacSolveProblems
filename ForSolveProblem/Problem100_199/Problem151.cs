using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem151 : IProblem
    {
        public void RunProblem()
        {
            var temp = ReverseWords("the sky is blue");
            if (temp != "blue is sky the") throw new Exception();

            temp = ReverseWords("  hello world!  ");
            if (temp != "world! hello") throw new Exception();

            temp = ReverseWords("a good   example");
            if (temp != "example good a") throw new Exception();
        }

        public string ReverseWords(string s)
        {
            /*
             * 采用原地算法对字符串做处理
             * 思路：
             *  1.去掉字符串中不合理的空格（字符串前后的空格，单词间的多个空格）-->需要两次单词遍历
             *  2.翻转每个单词 -->2次单词遍历
             *  3.翻转整个字符串 -->1次单词遍历
             *  
             * 时间复杂度：O(n)
             * 空间复杂度：O(1)
             */

            //1.去掉字符串中不合理的空格（字符串前后的空格，单词间的多个空格）
            s = s.Trim();


            //2.翻转每个单词

            //3.翻转整个字符串

            return "";
        }

        public string ReverseWords1(string s)
        {
            /*
             * 翻转字符串中的单词
             * 思路：
             *  1.简单理解为，检出字符串中的单词，然后逆序拼接
             *  
             * 时间复杂度：O(n)
             * 空间复杂度：O(n)
             */

            var strArray = s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            StringBuilder forReturn = new StringBuilder(s.Length);
            for(int i = strArray.Length-1;i >= 0; i--)
                forReturn.Append($"{strArray[i]} ");

            return forReturn.ToString().TrimEnd(' ');
        }
    }
}
