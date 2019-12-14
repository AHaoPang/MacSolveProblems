using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForSolveProblem
{
    public class Problem1190 : IProblem
    {
        public void RunProblem()
        {
            var temp = ReverseParentheses("(abcd)");
            if (temp != "dcba") throw new Exception();

            temp = ReverseParentheses("(u(love)i)");
            if (temp != "iloveu") throw new Exception();

            temp = ReverseParentheses("(ed(et(oc))el)");
            if (temp != "leetcode") throw new Exception();

            temp = ReverseParentheses("a(bcdefghijkl(mno)p)q");
            if (temp != "apmnolkjihgfedcbq") throw new Exception();

            temp = ReverseParentheses("ta()usw((((a))))");
            if (temp != "tauswa") throw new Exception();
        }

        public string ReverseParentheses(string s)
        {
            return RecursionGoOn(s, 0).Item2;
        }

        private (int, string) RecursionGoOn(string s, int curIndex)
        {
            if (curIndex >= s.Length) return (curIndex, null);

            var forReturn = new StringBuilder(s.Length - curIndex);
            int i = curIndex;
            for (; i < s.Length; i++)
            {
                switch (s[i])
                {
                    case '(':
                        var strTemp = RecursionGoOn(s, i + 1);
                        if (strTemp.Item2 != null) forReturn.Append(strTemp.Item2.Reverse().ToArray());
                        i = strTemp.Item1 - 1;
                        break;

                    case ')':
                        return (i + 1, forReturn.ToString());

                    default:
                        forReturn.Append(s[i]);
                        break;
                }
            }

            return (i, forReturn.ToString());
        }

        public string ReverseParentheses1(string s)
        {
            return Recursion(s, 0, s.Length - 1);
        }

        private string Recursion(string s, int startIndex, int stopIndex)
        {
            if (startIndex > stopIndex) return null;

            var forReturn = new StringBuilder(stopIndex - startIndex + 1);

            while (startIndex < stopIndex)
            {
                if (s[startIndex] == '(')
                {
                    startIndex++;
                    break;
                }

                forReturn.Append(s[startIndex]);
                startIndex++;
            }

            var stackTemp = new Stack<char>();
            while (stopIndex >= startIndex)
            {
                if (s[stopIndex] == ')')
                {
                    stopIndex--;
                    break;
                }

                stackTemp.Push(s[stopIndex]);
                stopIndex--;
            }

            var middleStr = Recursion(s, startIndex, stopIndex);
            if (middleStr != null) forReturn.Append(middleStr.Reverse().ToArray());

            return forReturn.Append(stackTemp.ToArray()).ToString();
        }
    }
}
