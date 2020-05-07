using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem045 : IProblem
    {
        public void RunProblem()
        {
            var set = new HashSet<QueueEntity>();

            set.Add(new QueueEntity(1, 2));
            set.Add(new QueueEntity(2, 3));
            set.Add(new QueueEntity(1, 3));

            var temp = Jump(new[] { 2, 3, 1, 1, 4 });
            if (temp != 2) throw new Exception();

            temp = Jump(new[] { 3, 1, 1, 1, 1 });
            if (temp != 2) throw new Exception();

            temp = Jump(new[] { 8, 2, 4, 4, 4, 9, 5, 2, 5, 8, 8, 0, 8, 6, 9, 1, 1, 6, 3, 5, 1, 2, 6, 6, 0, 4, 8, 6, 0, 3, 2, 8, 7, 6, 5, 1, 7, 0, 3, 4, 8, 3, 5, 9, 0, 4, 0, 1, 0, 5, 9, 2, 0, 7, 0, 2, 1, 0, 8, 2, 5, 1, 2, 3, 9, 7, 4, 7, 0, 0, 1, 8, 5, 6, 7, 5, 1, 9, 9, 3, 5, 0, 7, 5 });

            temp = Jump(new[] { 4, 1, 1, 3, 1, 1, 1 });
            if (temp != 2) throw new Exception();
        }

        public int Jump(int[] nums)
        {
            var res = 0;
            if (nums.Length <= 1)
                return res;

            var max = 0;
            var end = 0;
            for (var i = 0; i < nums.Length; i++)
            {
                var m = i + nums[i];
                if (m >= nums.Length - 1)
                    return res + 1;
                max = Math.Max(max, m);

                if (i == end)
                {
                    res++;
                    end = max;
                }
            }

            return res;
        }

        public int Jump2(int[] nums)
        {
            var res = 0;
            if (nums.Length <= 1)
                return res;

            var pq = new PriorityQueue<QueueEntity>(false, 64, new QueueEntity());
            pq.AddData(new QueueEntity(0, 0));

            while (pq.Count > 0)
            {
                var curDate = pq.GetData();
                if (curDate.Index + nums[curDate.Index] >= nums.Length - 1)
                    return curDate.Step + 1;

                for (var i = 1; i <= nums[curDate.Index]; i++)
                    pq.AddData(new QueueEntity(curDate.Index + i, curDate.Step + 1));
            }

            return -1;
        }

        public class QueueEntity : IComparer<QueueEntity>
        {
            public int Index { get; set; }
            public int Step { get; set; }

            public QueueEntity() { }

            public QueueEntity(int index, int step)
            {
                Index = index;
                Step = step;
            }

            public int Compare(QueueEntity x, QueueEntity y)
            {
                if (x.Step != y.Step)
                    return x.Step.CompareTo(y.Step);

                return y.Index.CompareTo(x.Index);
            }

            public override int GetHashCode()
            {
                return 1;
            }

            public override bool Equals(object obj)
            {
                var o = (QueueEntity)obj;

                return o.Index == Index && o.Step >= Step;
            }

            public override string ToString()
            {
                return $"{Index}_{Step}";
            }
        }

        public int Jump4(int[] nums)
        {
            var res = 0;
            if (nums.Length <= 1)
                return res;

            var set = new HashSet<int>();
            set.Add(0);

            var max = 0;
            while (set.Any())
            {
                res++;
                var newSet = new HashSet<int>();
                foreach (var curIndex in set)
                {
                    var lastIndex = curIndex + nums[curIndex];
                    if (lastIndex >= nums.Length - 1)
                        return res;

                    if (lastIndex <= max)
                        continue;
                    max = lastIndex;

                    for (var i = 1; i <= nums[curIndex]; i++)
                        newSet.Add(curIndex + i);
                }

                set = newSet;
            }

            return res;
        }

        public int Jump6(int[] nums)
        {
            var res = 0;
            if (nums.Length <= 1)
                return res;

            var list = new List<int>();
            list.Add(0);

            var max = 0;
            while (list.Any())
            {
                res++;
                var newSet = new List<int>();
                foreach (var curIndex in list)
                {
                    var lastIndex = curIndex + nums[curIndex];
                    if (lastIndex >= nums.Length - 1)
                        return res;

                    var i = max + 1;
                    for (; i <= lastIndex; i++)
                    {
                        newSet.Add(i);
                        max = i;
                    }
                }

                list = newSet;
            }

            return res;
        }
    }
}
