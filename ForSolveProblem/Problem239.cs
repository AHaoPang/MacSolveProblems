using System;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem239 : IProblem
    {
        public Problem239()
        {
        }

        public int[] MaxSlidingWindow(int[] nums, int k)
        {
            var res = new List<int>();
            var linkedList = new LinkedList<(int, int)>();

            var i = 0;
            for (; i < k; i++)
            {
                while (linkedList.Count != 0 && linkedList.Last.Value.Item1 < nums[i])
                    linkedList.RemoveLast();

                linkedList.AddLast((nums[i], i));
            }
            res.Add(linkedList.First.Value.Item1);

            for (; i < nums.Length; i++)
            {
                while (linkedList.Count != 0 && linkedList.Last.Value.Item1 < nums[i])
                    linkedList.RemoveLast();

                linkedList.AddLast((nums[i], i));

                if (i - linkedList.First.Value.Item2 + 1 > k)
                    linkedList.RemoveFirst();

                res.Add(linkedList.First.Value.Item1);
            }

            return res.ToArray();
        }

        public void RunProblem()
        {
            var temp = MaxSlidingWindow(new[] { 1, 3, -1, -3, 5, 3, 6, 7 }, 3);
            if (!ProblemHelper.ArrayEqual(temp, new[] { 3, 3, 5, 5, 6, 7 }))
                throw new Exception();

            temp = MaxSlidingWindow(new[] { 7, 2, 4 }, 2);
            if (!ProblemHelper.ArrayEqual(temp, new[] { 7, 4 }))
                throw new Exception();
        }
    }
}
