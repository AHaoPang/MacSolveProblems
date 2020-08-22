using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForSolveProblem
{
    public class Problem1546 : IProblem
    {
        public void RunProblem()
        {
            var temp = MaxNonOverlapping(new[] { 1, 1, 1, 1, 1 }, 2);

            temp = MaxNonOverlapping(new[] { -2, 6, 6, 3, 5, 4, 1, 2, 8 }, 10);

        }

        public int MaxNonOverlapping2(int[] nums, int target)
        {
            var dic = new Dictionary<int, int>();
            dic[0] = -1;
            var sum = 0;
            var dp = new int[nums.Length + 1];
            for (var i = 0; i < nums.Length; i++)
            {
                sum += nums[i];

                var sub = sum - target;
                if (!dic.ContainsKey(sub))
                {
                    dp[i + 1] = dp[i];
                }
                else
                {
                    var j = dic[sub];
                    dp[i + 1] = Math.Max(dp[i], dp[j + 1] + 1);
                }

                dic[sum] = i;
            }

            return dp[nums.Length];
        }

        public int MaxNonOverlapping(int[] nums, int target)
        {
            var set = new HashSet<int>();
            var sum = 0;
            set.Add(sum);

            var res = 0;
            foreach (var numItem in nums)
            {
                sum += numItem;
                var sub = sum - target;
                if (set.Contains(sub))
                {
                    res++;
                    sum = 0;
                    set.Clear();
                    set.Add(sum);
                }
                else
                    set.Add(sum);
            }

            return res;
        }
    }
}
