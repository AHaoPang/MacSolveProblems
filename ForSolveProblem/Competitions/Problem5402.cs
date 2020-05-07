using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem5402 : IProblem
    {
        public void RunProblem()
        {
            var temp = LongestSubarray(new[] { 8, 2, 4, 7 }, 4);

            temp = LongestSubarray(new[] { 34, 24, 70, 27, 40, 26, 32, 47, 11, 36, 12, 97, 58, 12, 84, 74, 83, 44, 30, 50, 40, 6, 42, 24, 41, 75, 39, 32, 43, 13, 70, 79, 75, 77, 12, 32, 29, 3, 32, 52, 10, 35, 71, 10, 94, 10, 3, 82, 2, 38, 97, 46, 64, 61, 20, 13, 65, 100, 42, 10, 66, 86, 23, 23, 100, 20, 19, 41, 40, 14, 91, 66, 78, 38, 17, 27, 19, 70, 93, 5, 100, 41, 80, 87, 71, 96, 89, 27, 23, 39, 56, 69 }, 72);

            temp = LongestSubarray(new[] { 1, 1, 1, 1, 1, 1, 1 }, 10);
        }

        public int LongestSubarray(int[] nums, int limit)
        {
            var res = 0;
            var l = -1;
            var big = new LinkedList<int>();
            var small = new LinkedList<int>();
            for (var r = 0; r < nums.Length; r++)
            {
                if (l == -1)
                {
                    l = r;
                    big.AddLast(r);
                    small.AddLast(r);
                }
                else
                {
                    while (big.Any() && nums[r] > nums[big.Last.Value])
                        big.RemoveLast();
                    big.AddLast(r);

                    while (small.Any() && nums[r] < nums[small.Last.Value])
                        small.RemoveLast();
                    small.AddLast(r);

                    while (nums[big.First.Value] - nums[small.First.Value] > limit)
                    {
                        if (big.First() == l)
                            big.RemoveFirst();
                        if (small.First() == l)
                            small.RemoveFirst();
                        l++;

                        if (!big.Any() || !small.Any())
                            break;
                    }
                }

                res = Math.Max(res, r - l + 1);
            }

            return res;
        }
    }
}
