using System;
namespace ForSolveProblem
{
    public class Problem5396 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int MaxPower(string s)
        {
            var res = 0;

            var l = 0;
            for (var r = 0; r < s.Length; r++)
            {
                if (s[l] != s[r])
                {
                    res = Math.Max(res, r - l);
                    l = r;
                }
            }

            res = Math.Max(res, s.Length - l);

            return res;
        }
    }
}
