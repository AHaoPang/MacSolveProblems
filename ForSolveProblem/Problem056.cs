using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem056 : IProblem
    {
        public void RunProblem()
        {
            //[[1,3],[2,6],[8,10],[15,18]]
            int[][] inputArray = new int[][]
            {
                new int[] {1,3 },
                new int[] {2,6 },
                new int[] {8,10 },
                new int[]{15,18}
            };
            var temp = Merge(inputArray);
        }

        class NumRange
        {
            public int Min { get; set; }

            public int Max { get; set; }
        }

        public int[][] Merge(int[][] intervals)
        {
            /*
             * 将多个片段做个处理，即，当片段重叠，那么就直接合并成一个片段
             * 思路：
             *  1.将片段按照区间开始的大小来排序
             *  2.然后外层循环依次遍历所有的片段，内层循环查找并合并重叠片段
             *  
             * 时间复杂度：排序O(nlogn)+遍历O(n)，所以最后是，O(nlogn)
             * 空间复杂度：没有利用额外的空间，所以是，O(1)
             * 
             * 考察点：
             *  1.排序、数组
             */

            //1.对区间片段排序
            List<NumRange> ranges = new List<NumRange>();
            for (int i = 0; i < intervals.GetLength(0); i++)
            {
                ranges.Add(new NumRange()
                {
                    Min = intervals[i][0],
                    Max = intervals[i][1]
                });
            }
            if (!ranges.Any()) return intervals;
            var orderedRanges = ranges.OrderBy(i => i.Min).ToList();

            //2.利用内外循环的方式做遍历
            var mergedRanges = new List<NumRange>();
            for (int j = 0; j < orderedRanges.Count; j++)
            {
                NumRange newRange = new NumRange();
                newRange.Min = orderedRanges[j].Min;
                newRange.Max = orderedRanges[j].Max;

                while (j + 1 < orderedRanges.Count && orderedRanges[j + 1].Min <= newRange.Max)
                {
                    if (orderedRanges[j + 1].Max > newRange.Max)
                        newRange.Max = orderedRanges[j + 1].Max;
                    j++;
                }

                mergedRanges.Add(newRange);
            }

            //3.返回需要的结果
            int[][] forReturn = new int[mergedRanges.Count][];
            for (int k = 0; k < mergedRanges.Count; k++)
                forReturn[k] = new int[] { mergedRanges[k].Min, mergedRanges[k].Max };

            return forReturn;
        }
    }
}
