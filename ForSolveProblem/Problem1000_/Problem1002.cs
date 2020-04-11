using System;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem1002 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public IList<string> CommonChars(string[] A)
        {
            var arr1 = GetStrArr(A.First());
            for (var i = 1; i < A.Length; i++)
                arr1 = MergeArr(arr1, GetStrArr(A[i]));

            return arr1
                .SelectMany((item, index) =>
                {
                    if (item == 0)
                        return new string[0];
                    else
                    {
                        var curStr = ((char)('a' + index)).ToString();
                        return Enumerable.Repeat(curStr, item);
                    }
                })
                .ToList();
        }

        private int[] GetStrArr(string s)
        {
            var res = new int[26];
            foreach (var c in s)
                res[c - 'a']++;

            return res;
        }

        private int[] MergeArr(int[] arr1, int[] arr2)
        {
            var res = new int[arr1.Length];
            for (var i = 0; i < arr1.Length; i++)
                res[i] = Math.Min(arr1[i], arr2[i]);

            return res;
        }
    }
}
