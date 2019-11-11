using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem1021 : IProblem
    {
        public void RunProblem()
        {
            var temp = RemoveOuterParentheses("(()())(())");
            if (temp != "()()()") throw new Exception();

            temp = RemoveOuterParentheses("(()())(())(()(()))");
            if (temp != "()()()()(())") throw new Exception();

            temp = RemoveOuterParentheses("()()");
            if (temp != "") throw new Exception();
        }

        public string RemoveOuterParentheses(string S)
        {
            /*
             * 将由括号组成的字符串S，脱去一层括号
             * 思路：
             *  1.关键就是字符串的切割
             *  2.然后就是把切割后的字符串去掉括号
             *  3.把栈作为一个切割的判断工具，一个指针作为探测的坐标
             *  
             * 时间复杂度：O(n)
             * 空间复杂度：O(n)
             */

            StringBuilder forReturn = new StringBuilder();
            Stack<char> stackForSplit = new Stack<char>();

            int checkPosStart = 0;
            for (int i = 0; i < S.Length; i++)
            {
                if (i == 0)
                {
                    stackForSplit.Push(S[i]);
                    continue;
                }

                if (S[i] == '(')
                {
                    stackForSplit.Push(S[i]);
                    continue;
                }

                stackForSplit.Pop();

                if (!stackForSplit.Any())
                {
                    forReturn.Append(S.Substring(checkPosStart + 1, i - checkPosStart - 1));
                    checkPosStart = i + 1;
                }
            }

            return forReturn.ToString();
        }
    }
}
