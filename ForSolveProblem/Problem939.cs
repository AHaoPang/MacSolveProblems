using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem939 : IProblem
    {
        public void RunProblem()
        {
            var temp = MinAreaRect(new int[][]
            {
                new int[]{1,1},
                new int[]{1,3},
                new int[]{3,1},
                new int[]{3,3},
                new int[]{2,2}
            });
            if (temp != 4) throw new Exception();

            temp = MinAreaRect(new int[][]
            {
                new int[]{1,1},
                new int[]{1,3},
                new int[]{3,1},
                new int[]{3,3},
                new int[]{4,1},
                new int[]{4,3}
            });
            if (temp != 2) throw new Exception();
        }

        public int MinAreaRect(int[][] points)
        {
            /*
             * 从给定的点集合中，找到最小的标准矩形（即，矩形的边要和X和Y轴平行）
             * 思路：
             *  1.本地的关键点在于，如何快速检索到，是否存在能构成矩形的点
             *  2.如果把能构成对角线的点作为主要骨架，那么就需要快速判断，是否存在期望中的点
             *  3.依据题目发现，X和Y的值的范围，都是有限的，那么就可以得到一个有趣的Hash算法，即X*40001+Y，就是哈希后的值（有种数量级差距的感觉）
             *  
             * 时间复杂度：O(n^2)，主要的耗时点在于需要组合所有两个点，才能知道是否是对角线
             * 空间复杂度：O(n)，需要记录所有的点
             */

            var pointSet = new HashSet<int>();
            foreach (var pointItem in points) pointSet.Add(pointItem[0] * 40001 + pointItem[1]);

            var forReturn = int.MaxValue;
            for (int i = 0; i < points.Length - 1; i++)
            {
                for (int j = i + 1; j < points.Length; j++)
                {
                    if (points[i][0] == points[j][0] || points[i][1] == points[j][1]) continue;
                    if (!pointSet.Contains(points[i][0] * 40001 + points[j][1])) continue;
                    if (!pointSet.Contains(points[j][0] * 40001 + points[i][1])) continue;

                    int xLength = Math.Abs(points[j][0] - points[i][0]);
                    int yLength = Math.Abs(points[j][1] - points[i][1]);
                    forReturn = Math.Min(forReturn, xLength * yLength);
                }
            }

            return forReturn == int.MaxValue ? 0 : forReturn;
        }
    }
}
