using System;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem1337 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int[] KWeakestRows(int[][] mat, int k)
        {
            /*
             * 题目概述：方阵中战斗力最弱的 K 行
             * 
             * 思路：
             *  1.先要知道各行的战斗力如何,然后才能知道战斗力的强和弱
             *  2.常规思路是,逐行统计 1 的个数,然后排序,先按照个数排序,在按照行号排序
             *  3.以上方式,逐行统计复杂度是 O(m*n) 排序复杂度是 O(mlogm)
             *  4.其实题目中还有一个提示,方阵中 1 一定是排在 0 前面的,数据的总规模不是很大,而且会有重复的战斗力出现
             *  5.此种情况,非常像桶排序了,此种排序方式,天然是有序的,每个桶内记录行号的先后顺序即可
             *  6.本题考虑使用后一种思路来处理
             *
             * 关键点：
             *
             * 时间复杂度：O(m*n) O(n) => O(m*n)
             * 空间复杂度：O(m*n)
             */

            var rows = mat.Length;
            var cols = mat[0].Length;

            var bucketArray = new List<int>[cols + 1];
            for (var c = 0; c < bucketArray.Length; c++)
                bucketArray[c] = new List<int>();

            for (var r = 0; r < rows; r++)
            {
                var c = 0;
                for (; c < cols; c++)
                    if (mat[r][c] == 0)
                        break;

                bucketArray[c].Add(r);
            }

            var curCol = 0;
            var forReturn = new List<int>();
            while (forReturn.Count() < k && curCol <= bucketArray.Length)
                forReturn.AddRange(bucketArray[curCol++]);

            return forReturn.Take(k).ToArray();
        }
    }
}
