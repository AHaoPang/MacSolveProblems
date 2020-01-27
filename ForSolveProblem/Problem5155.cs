using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForSolveProblem
{
    public class Problem5155 : IProblem
    {
        public void RunProblem()
        {
            var temp = ArrayRankTransform(new int[] { 40, 10, 20, 30 });
            if (!ProblemHelper.ArrayIsEqual(temp, new int[] { 4, 1, 2, 3 }, false))
                throw new Exception();

            temp = ArrayRankTransform(new int[] { 100, 100, 100 });
            if (!ProblemHelper.ArrayIsEqual(temp, new int[] { 1, 1, 1 }, false))
                throw new Exception();

            temp = ArrayRankTransform(new int[] { 37, 12, 28, 9, 100, 56, 80, 5, 12 });
            if (!ProblemHelper.ArrayIsEqual(temp, new int[] { 5, 3, 4, 2, 8, 6, 7, 1, 3 }, false))
                throw new Exception();

        }

        public int[] ArrayRankTransform(int[] arr)
        {
            var forReturn = new int[arr.Length];

            var arrEntity = new List<ArrEntityItem>(arr.Length);
            for (int i = 0; i < arr.Length; i++)
                arrEntity.Add(new ArrEntityItem()
                {
                    ArrIndex = i,
                    ArrValue = arr[i]
                });

            var curIndex = 0;
            var preValue = int.MinValue;
            var sortedArray = arrEntity.OrderBy(i => i.ArrValue);
            foreach (var sortedItem in sortedArray)
            {
                if (sortedItem.ArrValue != preValue)
                    curIndex++;

                forReturn[sortedItem.ArrIndex] = curIndex;
                preValue = sortedItem.ArrValue;
            }

            return forReturn;
        }

        class ArrEntityItem
        {
            public int ArrIndex { get; set; }

            public int ArrValue { get; set; }
        }
    }
}
