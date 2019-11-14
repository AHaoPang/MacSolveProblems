using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForSolveProblem
{
    public class Problem1253 : IProblem
    {
        public void RunProblem()
        {
            var temp = ReconstructMatrix(2, 1, new int[] { 1, 1, 1 });

            temp = ReconstructMatrix(2, 3, new int[] { 2, 2, 1, 1 });

            temp = ReconstructMatrix(5, 5, new int[] { 2, 1, 2, 0, 1, 0, 1, 2, 0, 1 });
        }

        public IList<IList<int>> ReconstructMatrix(int upper, int lower, int[] colsum)
        {
            /*
             * 问题:依据对两行以及各列总和的汇总结果,反向推出原来的二进制矩阵
             * 思路:
             *  1.由于是二进制矩阵,所以当一个列的总和为0和2的时候,其实这一列的值就是固定的了
             *  2.需要统计出为1的列,要将这些1分到不同的行
             * 
             * 关键点:
             *  1.遍历列的统计和时,要累计出第1行的值以及第2行的值,依据此值,才知道如何分配1
             *  2.需要将为1的列的索引记录下来,此处使用的队列的方式来记录
             * 
             * 时间复杂度:O(n)
             * 空间复杂度:O(n)
             */

            var forReturn = new List<IList<int>>()
            {
                new List<int>(Enumerable.Repeat(0,colsum.Length)),
                new List<int>(Enumerable.Repeat(0,colsum.Length)),
            };

            var oneIndexArray = new Queue<int>(colsum.Length);
            var upperTemp = 0;
            var lowerTemp = 0;
            for (int i = 0; i < colsum.Length; i++)
            {
                switch (colsum[i])
                {
                    case 2:
                        upperTemp++;
                        lowerTemp++;

                        forReturn[0][i] = 1;
                        forReturn[1][i] = 1;
                        break;

                    case 1:
                        oneIndexArray.Enqueue(i);
                        break;
                }
            }

            var upperRest = upper - upperTemp;
            var lowerRest = lower - lowerTemp;
            if (upperRest < 0 || lowerRest < 0 || upperRest + lowerRest != oneIndexArray.Count) return new List<IList<int>>();

            for (int i = 0; i < upperRest; i++)
                forReturn[0][oneIndexArray.Dequeue()] = 1;
            for (int j = 0; j < lowerRest; j++)
                forReturn[1][oneIndexArray.Dequeue()] = 1;

            return forReturn;
        }
    }
}
