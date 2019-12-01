﻿using System;
using System.Collections.Generic;

namespace ForSolveProblem
{
    public class Problem5113 : IProblem
    {
        public void RunProblem()
        {
            var temp = RemoveInterval(new int[][]
            {
                new int[]{0,2},
                new int[]{3,4},
                new int[]{5,7}
            },
            new int[] { 1, 6 });

            temp = RemoveInterval(new int[][]
            {
                new int[]{0,5}
            }, new int[] { 2, 3 });
        }

        public IList<IList<int>> RemoveInterval(int[][] intervals, int[] toBeRemoved)
        {
            if (toBeRemoved.Length == 0) return intervals;

            var forReturn = new List<IList<int>>();
            var leftDel = toBeRemoved[0];
            var rightDel = toBeRemoved[1];

            for (int i = 0; i < intervals.Length; i++)
            {
                var leftPoint = intervals[i][0];
                var rightPoint = intervals[i][1];

                if (rightPoint <= leftDel || leftPoint >= rightDel)
                    forReturn.Add(new List<int>() { leftPoint, rightPoint });
                else
                {
                    if (leftPoint >= leftDel && rightPoint <= rightDel) continue;

                    if (leftPoint < leftDel && rightPoint > rightDel)
                    {
                        forReturn.Add(new List<int>() { leftPoint, leftDel });
                        forReturn.Add(new List<int>() { rightDel, rightPoint });
                    }
                    else if (leftPoint < leftDel && rightPoint > leftDel)
                        forReturn.Add(new List<int>() { leftPoint, leftDel });
                    else if (rightPoint > rightDel && leftPoint < rightDel)
                        forReturn.Add(new List<int>() { rightDel, rightPoint });
                }
            }

            return forReturn;
        }
    }
}
