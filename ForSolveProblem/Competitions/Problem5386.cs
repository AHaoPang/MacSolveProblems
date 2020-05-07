using System;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem5386 : IProblem
    {
        public void RunProblem()
        {
            var t = CheckIfCanBreak("abc", "xya");
            if (t != true)
                throw new Exception();

            t = CheckIfCanBreak("abe", "acd");
            if (t != false)
                throw new Exception();

            t = CheckIfCanBreak("leetcodee", "interview");
            if (t != true)
                throw new Exception();

            t = CheckIfCanBreak("yopumzgd", "pamntyya");
            if (t != true)
                throw new Exception();
        }

        public bool CheckIfCanBreak(string s1, string s2)
        {
            var s1Order = s1.OrderBy(i => i).ToArray();
            var s2Order = s2.OrderBy(i => i).ToArray();

            var isBigger = true;
            for (var i = 0; i < s1Order.Length; i++)
            {
                if (s1Order[i] < s2Order[i])
                    isBigger = false;
            }
            if (isBigger)
                return true;

            var isSmall = true;
            for (var i = 0; i < s1Order.Length; i++)
            {
                if (s1Order[i] > s2Order[i])
                    isSmall = false;
            }

            return isSmall;
        }
    }
}
