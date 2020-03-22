using System;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem709 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public string ToLowerCase(string str)
        {
            var sub = 'a' - 'A';
            return string.Join("", str.Select(i => char.IsUpper(i) ? (char)(i + sub) : i));
        }

        public string ToLowerCase1(string str)
        {
            return str.ToLower();
        }
    }
}
