using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForSolveProblem
{
    public class Problem1544 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public string MakeGood(string s)
        {
            var constNum = 'a' - 'A';
            var stack = new Stack<char>();
            foreach (var c in s)
            {
                if(!stack.Any())
                {
                    stack.Push(c);
                    continue;
                }

                var sub = Math.Abs(c - stack.Peek());
                if (stack.Any() && sub == constNum)
                    stack.Pop();
                else
                    stack.Push(c);
            }

            return new string(stack.Reverse().ToArray());
        }
    }
}
