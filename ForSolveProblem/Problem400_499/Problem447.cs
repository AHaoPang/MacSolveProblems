using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem447 : IProblem
    {
        public void RunProblem()
        {
            var temp = NumberOfBoomerangs(new int[][]
            {
                new int[]{0,0 },
                new int[]{1,0 },
                new int[]{2,0 }
            });
            if (temp != 2) throw new Exception();

        }

        private static object lockObj = new object();

        public int NumberOfBoomerangs(int[][] points)
        {
            /*
             * 找寻点矩阵中，回旋镖的数量
             * 思路：
             *  1.查看每一条边是肯定的
             *  2.每个点都维护自己的Dictionary
             *  3.将两点之间的距离，记为key，目标点的个数记为value
             *  4.对于相同距离的x个点，组合的个数为x * (x -1)
             *  
             * 时间复杂度：O(n^2)
             * 空间复杂度：O(n)
             */

            var forReturn = 0;

            List<Task> tasks = new List<Task>();
            var length = points.GetLength(0);
            for (int i = 0; i < length; i++)
            {
                var taskTemp = GetCountAsync(i, points).ContinueWith(r => 
                {
                    lock (lockObj){forReturn += r.Result;}
                });
                tasks.Add(taskTemp);
            }

            Task.WaitAll(tasks.ToArray());
            return forReturn;
        }

        private Task<int> GetCountAsync(int i, int[][] points)
        {
            return Task.Run(() => GetCount(i, points));
        }

        private int GetCount(int i, int[][] points)
        {
            var length = points.GetLength(0);

            var forReturn = 0;

            Dictionary<int, int> pointDistance = new Dictionary<int, int>();
            for (int j = 0; j < length; j++)
            {
                if (i == j) continue;

                int x = points[i][0] - points[j][0];
                int xx = x * x;

                int y = points[i][1] - points[j][1];
                int yy = y * y;

                if (!pointDistance.ContainsKey(xx + yy)) pointDistance[xx + yy] = 0;
                pointDistance[xx + yy]++;
            }

            foreach (var distanceItem in pointDistance)
            {
                if (distanceItem.Value < 2) continue;
                forReturn += distanceItem.Value * (distanceItem.Value - 1);
            }

            return forReturn;
        }
    }
}
