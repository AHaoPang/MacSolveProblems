using System;
namespace ForSolveProblem
{
    public class Problem806 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int[] NumberOfLines(int[] widths, string S)
        {
            var line = 1;
            var increaseCount = 0;
            foreach (var charItem in S)
            {
                if (increaseCount + widths[charItem - 'a'] > 100)
                {
                    increaseCount = widths[charItem - 'a'];
                    line++;
                    continue;
                }

                increaseCount += widths[charItem - 'a'];
            }

            return new[] { line, increaseCount };
        }
    }
}
