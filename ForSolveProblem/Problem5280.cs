using System;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem5280 : IProblem
    {
        public void RunProblem()
        {
            var temp = GroupThePeople(new int[] { 3, 3, 3, 3, 3, 1, 3 });

            temp = GroupThePeople(new int[] { 2, 1, 3, 3, 3, 2 });
        }

        public IList<IList<int>> GroupThePeople(int[] groupSizes)
        {
            var groupSizeDic = new Dictionary<int, IList<int>>();
            for (int i = 0; i < groupSizes.Length; i++)
            {
                var groupCount = groupSizes[i];

                if (!groupSizeDic.ContainsKey(groupCount)) groupSizeDic[groupCount] = new List<int>();
                groupSizeDic[groupCount].Add(i);
            }

            var forReturn = new List<IList<int>>();
            foreach (var dicItem in groupSizeDic)
            {
                var countTemp = dicItem.Key;
                var startIndex = 0;
                while (startIndex < dicItem.Value.Count)
                {
                    forReturn.Add(dicItem.Value.Skip(startIndex).Take(countTemp).ToList());
                    startIndex += countTemp;
                }
            }

            return forReturn;
        }
    }
}
