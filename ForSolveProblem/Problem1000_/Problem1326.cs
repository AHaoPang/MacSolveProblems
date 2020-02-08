using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForSolveProblem
{
    public class Problem1326 : IProblem
    {
        public void RunProblem()
        {
            var temp = MinTaps(5, new int[] { 3, 4, 1, 1, 0, 0 });
            if (temp != 1) throw new Exception();

            temp = MinTaps(3, new int[] { 0, 0, 0, 0 });
            if (temp != -1) throw new Exception();

            temp = MinTaps(7, new int[] { 1, 2, 1, 0, 2, 1, 0, 1 });
            if (temp != 3) throw new Exception();

            temp = MinTaps(8, new int[] { 4, 0, 0, 0, 0, 0, 0, 0, 4 });
            if (temp != 2) throw new Exception();

            temp = MinTaps(8, new int[] { 4, 0, 0, 0, 4, 0, 0, 0, 4 });
            if (temp != 1) throw new Exception();

            temp = MinTaps(9, new int[] { 0, 5, 0, 3, 3, 3, 1, 4, 0, 4 });
            if (temp != 2) throw new Exception();

        }

        public int MinTaps(int n, int[] ranges)
        {
            var collection = new List<ListEntity>();
            for (int i = 0; i < ranges.Length; i++)
            {
                if (ranges[i] == 0) continue;

                var startIndex = i - ranges[i];
                var stopIndex = i + ranges[i];

                if (collection.Any())
                    if (collection.Last().StopIndex >= stopIndex) continue;

                var length = collection.Count;
                for (int j = length - 1; j >= 0; j--)
                {
                    if (startIndex <= 0)
                    {
                        collection.RemoveAt(j);
                        continue;
                    }

                    if (collection[j].StopIndex >= startIndex)
                    {
                        var newLength = collection.Count;
                        for (int s = newLength - 1; s > j; s--)
                            collection.RemoveAt(s);
                    }
                    else
                        break;
                }

                if (collection.Any() && collection.Last().StopIndex < startIndex) return -1;

                collection.Add(new ListEntity()
                {
                    StartIndex = startIndex,
                    StopIndex = stopIndex
                });

                if (collection.Last().StopIndex >= n) break;
            }

            if (!collection.Any()) return -1;
            if (collection.First().StartIndex > 0) return -1;

            return collection.Count;
        }

        class ListEntity
        {
            public int StartIndex { get; set; }

            public int StopIndex { get; set; }
        }

        public int MinTaps2(int n, int[] ranges)
        {
            var stackTemp = new Stack<StackEntity>();
            for (int i = 0; i < ranges.Length; i++)
            {
                if (ranges[i] == 0) continue;

                if (!stackTemp.Any())
                {
                    stackTemp.Push(new StackEntity()
                    {
                        NIndex = i,
                        NRange = ranges[i]
                    });

                    continue;
                }

                var topEntity = stackTemp.Peek();
                if (topEntity.NRange + topEntity.NIndex >= i + ranges[i]) continue;

                if (i - ranges[i] <= topEntity.NIndex - topEntity.NRange)
                    stackTemp.Pop();

                while (i - ranges[i] <= 0 && stackTemp.Any())
                    stackTemp.Pop();

                stackTemp.Push(new StackEntity()
                {
                    NIndex = i,
                    NRange = ranges[i]
                });

                if (i + ranges[i] >= n)
                    break;
            }

            if (!stackTemp.Any()) return -1;

            var numArray = stackTemp.ToList();
            numArray.Reverse();

            var firstEntity = numArray.First();
            if (firstEntity.NIndex - firstEntity.NRange > 0) return -1;

            var stopIndex = firstEntity.NIndex + firstEntity.NRange;
            for (int i = 1; i < numArray.Count; i++)
            {
                var curEntity = numArray[i];

                if (curEntity.NIndex - curEntity.NRange <= stopIndex)
                    stopIndex = curEntity.NIndex + curEntity.NRange;
                else
                    return -1;
            }

            if (stopIndex < n) return -1;

            return stackTemp.Count;
        }

        class StackEntity
        {
            public int NIndex { get; set; }

            public int NRange { get; set; }
        }
    }
}
