using System;
namespace ForSolveProblem
{
    public class Problem434 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int CountSegments(string s)
        {


            var forReturn = 0;
            var preIndex = -1;
            for (var i = 0; i < s.Length; i++)
            {
                var curChar = s[i];
                if (curChar != ' ') continue;

                if (i - preIndex > 1)
                    forReturn++;

                preIndex = i;
            }

            if (preIndex != s.Length - 1)
                forReturn++;

            return forReturn;
        }

        public int CountSegments1(string s) => s.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length;
    }
}
