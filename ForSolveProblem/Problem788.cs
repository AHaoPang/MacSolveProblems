using System;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem788 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int RotatedDigits(int N)
        {
            var res = 0;

            var wrongNum = new HashSet<char>() { '3', '4', '7' };
            var rightNum = new HashSet<char>() { '2', '5', '6', '9' };

            for (var i = 1; i <= N; i++)
            {
                var charArray = i.ToString().ToCharArray();

                if (!charArray.Any(c => wrongNum.Contains(c)) && charArray.Any(c => rightNum.Contains(c)))
                    res++;
            }

            return res;
        }
    }
}
