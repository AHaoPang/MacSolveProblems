using System;
using System.Collections.Generic;
using System.Text;

namespace ForSolveProblem
{
    public class Problem1541 : IProblem
    {
        public void RunProblem()
        {
            var temp = MinInsertions("(()))");
            if (temp != 1) throw new Exception();

            temp = MinInsertions("())");
            if (temp != 0) throw new Exception();

            temp = MinInsertions("))())(");
            if (temp != 3) throw new Exception();

            temp = MinInsertions("((((((");
            if (temp != 12) throw new Exception();

            temp = MinInsertions(")))))))");
            if (temp != 5) throw new Exception();
        }

        public int MinInsertions(string s)
        {
            var res = 0;
            var stack = 0;
            var curIndex = 0;
            while (curIndex < s.Length)
            {
                switch (s[curIndex])
                {
                    case '(':
                        stack++;
                        break;

                    case ')':
                        Check(s, ref curIndex, ref stack, ref res);
                        break;
                }

                curIndex++;
            }

            res += 2 * stack;
            return res;
        }

        private void Check(string s, ref int curIndex, ref int stack, ref int res)
        {
            var rightCount = 1;
            if (curIndex + 1 < s.Length && s[curIndex + 1] == ')')
                rightCount++;

            if (rightCount == 1)
            {
                if (stack > 0)
                {
                    stack--;
                    res++;
                }
                else
                    res += 2;
            }
            else
            {
                if (stack > 0)
                    stack--;
                else
                    res++;

                curIndex++;
            }
        }
    }
}
