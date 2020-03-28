using System;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem844 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public bool BackspaceCompare(string S, string T)
        {
            var constChar = '#';

            var e1 = GetStrQueue(S, constChar);
            var e2 = GetStrQueue(T, constChar);

            return e1.SequenceEqual(e2);
        }

        private static IEnumerable<char> GetStrQueue(string S, char constChar)
        {
            var s = new Stack<char>();
            foreach (var sItem in S)
            {
                if (sItem == constChar)
                {
                    if (s.Any())
                        s.Pop();
                }
                else
                    s.Push(sItem);
            }

            return s;
        }
    }
}
