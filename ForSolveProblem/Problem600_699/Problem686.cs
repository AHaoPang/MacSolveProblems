using System;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem686 : IProblem
    {
        public void RunProblem()
        {

            var temp = RepeatedStringMatch("abcd", "cdabcdab");
        }

        public int RepeatedStringMatch(string A, string B)
        {
            var initLength = (B.Length - 1) / A.Length + 1;
            var strTemp = string.Join("", Enumerable.Repeat(A, initLength));
            for (var i = initLength; i <= initLength + 1; i++)
            {
                if (strTemp.IndexOf(B) != -1)
                    return i;

                strTemp += A;
            }

            return -1;
        }

        public int RepeatedStringMatch1(string A, string B)
        {
            if (A.Length >= B.Length)
            {
                var v1 = A.IndexOf(B);
                if (v1 >= 0) return 1;

            }
            var newStr = A + A;
            if (newStr.Length > B.Length)
                return newStr.IndexOf(B) >= 0 ? 2 : -1;

            var firstIndex = B.IndexOf(A);
            if (firstIndex == -1) return -1;

            var forReturn = 0;
            if (firstIndex != 0)
            {
                var titleStr = new string(B.ToCharArray().Take(firstIndex).ToArray());

                var indexTemp = A.IndexOf(titleStr);
                if (indexTemp == -1)
                    return -1;

                forReturn++;
            }

            for (var i = firstIndex; i < B.Length; i++)
            {
                var iAdd = i - firstIndex;
                if (iAdd % A.Length == 0)
                    forReturn++;

                if (A[iAdd % A.Length] != B[i])
                    return -1;
            }

            return forReturn;
        }
    }
}
