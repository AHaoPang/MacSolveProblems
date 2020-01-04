using System;
namespace ForSolveProblem
{
    public class Problem856 : IProblem
    {
        public void RunProblem()
        {
            var temp = ScoreOfParentheses("()");
            if (temp != 1) throw new Exception();

            temp = ScoreOfParentheses("(())");
            if (temp != 2) throw new Exception();

            temp = ScoreOfParentheses("()()");
            if (temp != 2) throw new Exception();

            temp = ScoreOfParentheses("(()(()))");
            if (temp != 6) throw new Exception();
        }

        public int ScoreOfParentheses(string S)
        {
            return Recursive(S, 0).Item2;
        }

        private (int, int) Recursive(string S, int curIndex)
        {
            var curValue = 0;
            int i = curIndex;
            for (; i < S.Length; i++)
            {
                switch (S[i])
                {
                    case '(':
                        var resultTemp = Recursive(S, i + 1);
                        i = resultTemp.Item1;
                        curValue += resultTemp.Item2;
                        break;

                    case ')':
                        if (curValue == 0) return (i, 1);

                        return (i, curValue * 2);
                }
            }

            return (i, curValue);
        }
    }
}
