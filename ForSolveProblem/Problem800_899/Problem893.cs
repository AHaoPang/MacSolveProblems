using System;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem893 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int NumSpecialEquivGroups(string[] A)
        {
            return A.GroupBy(
                i =>
                {
                    var (a, b) = GetStr(i);
                    return $"{a}_{b}";
                }, j => j)
                .Count();
        }

        private (int a, int b) GetStr(string s)
        {
            var a = 0;
            var b = 0;
            for (var i = 0; i < s.Length; i++)
            {
                var move = s[i] - 'a';

                if (i % 2 == 0)
                    a += 1 << move;
                else
                    b += 1 << move;
            }

            return (a, b);
        }
    }
}
