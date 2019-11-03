using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForSolveProblem
{
    public class Problem5249 : IProblem
    {
        public void RunProblem()
        {
            var temp = MinRemoveToMakeValid("lee(t(c)o)de)");
            if (temp != "lee(t(c)o)de") throw new Exception();

            temp = MinRemoveToMakeValid("a)b(c)d");
            if (temp != "ab(c)d") throw new Exception();

            temp = MinRemoveToMakeValid("))((");
            if (temp != "") throw new Exception();

            temp = MinRemoveToMakeValid("(a(b(c)d)");
            if (temp != "a(b(c)d)") throw new Exception();
        }

        public string MinRemoveToMakeValid(string s)
        {
            var hashIndex = new HashSet<int>(s.Length);
            var stackIndex = new Stack<int>();
            for (int i = 0; i < s.Length; i++)
            {
                var curChar = s[i];

                if (curChar == '(')
                    stackIndex.Push(i);
                else if (curChar == ')')
                {
                    if (stackIndex.Count == 0)
                        hashIndex.Add(i);
                    else
                        stackIndex.Pop();
                }
            }

            while (stackIndex.Any())
                hashIndex.Add(stackIndex.Pop());

            var forReturn = new StringBuilder(s.Length);
            for (int i = 0; i < s.Length; i++)
                if (!hashIndex.Contains(i)) forReturn.Append(s[i]);

            return forReturn.ToString();
        }
    }
}
