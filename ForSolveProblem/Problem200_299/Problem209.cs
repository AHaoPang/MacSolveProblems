using System;
using System.Collections;
using System.Collections.Generic;

namespace ForSolveProblem
{
    public class Problem209 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int MinSubArrayLen(int s, int[] nums)
        {
            var res = int.MaxValue;
            var sum = 0;
            var l = -1;
            for (var i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
                if (sum < s) continue;

                while (sum >= s)
                {
                    res = Math.Min(res, i - l + 1);
                    if (l >= 0)
                        sum -= nums[l];

                    l++;
                }
            }

            return res == int.MaxValue ? 0 : res;
        }

        public int MinSubArrayLen1(int s, int[] nums)
        {
            var res = int.MaxValue;
            var sum = 0;
            var queue = new Queue<int>();
            for (var i = 0; i < nums.Length; i++)
            {
                queue.Enqueue(i);
                sum += nums[i];

                if (sum < s) continue;

                while (sum >= s)
                {
                    var f = queue.Dequeue();
                    sum -= nums[f];

                    res = Math.Min(res, i - f + 1);
                }
            }

            return res == int.MaxValue ? 0 : res;
        }
    }
}
