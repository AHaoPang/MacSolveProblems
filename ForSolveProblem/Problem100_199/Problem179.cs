using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem179 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public string LargestNumber(int[] nums)
        {
            if (!nums.Any())
                return "";

            var arr = nums.OrderByDescending(i => i, new CustomComparer()).ToArray();
            if (arr.First() == 0) return "0";

            return string.Join("", arr);
        }

        class CustomComparer : IComparer<int>
        {
            public int Compare([AllowNull] int x, [AllowNull] int y)
            {
                var s1 = $"{x}{y}";
                var s2 = $"{y}{x}";

                return s1.CompareTo(s2);
            }
        }
    }
}
