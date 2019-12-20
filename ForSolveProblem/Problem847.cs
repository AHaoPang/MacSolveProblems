using System;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem847 : IProblem
    {
        public void RunProblem()
        {
            var temp = ShortestPathLength(new int[][]
            {
                new int[]{1,2,3},
                new int[]{0},
                new int[]{0},
                new int[]{0}
            });
            if (temp != 4) throw new Exception();

            temp = ShortestPathLength(new int[][]
            {
                new int[]{1},
                new int[]{0,2,4},
                new int[]{1,3,4},
                new int[]{2},
                new int[]{1,2}
            });
            if (temp != 4) throw new Exception();
        }

        public int ShortestPathLength(int[][] graph)
        {
            /*
             * 题目概述：从任意点开始,最少的移动次数下走完所有点
             * 
             * 思路：
             * 1.需要一个转态来表示到达当前节点后,已经走完的点,以及至今的步数
             * 2.考虑使用位来表示这种状态,1 个位表示 2 个状态那么 n 个位就表示了 2^n 种状态
             * 3.最少移动次数,所以想到了 BFS 的方式
             * 4.初始状态应该是各个点作为起始位置
             * 5.每一轮各个点向着可能的方向移动,并记录新的状态
             *
             * 关键点：
             * 1.为了提高效率,需要做相应剪枝,对于处在相同状态的点,步数比之前记录的还大,那么就舍弃
             *
             * 时间复杂度：O(2^n*n)
             * 空间复杂度：O(2^n*n)
             */

            var n = graph.Length;

            var visited = new int[1 << n][];
            for (int i = 0; i < visited.Length; i++)
                visited[i] = Enumerable.Repeat(n * n, n).ToArray();

            var queueTemp = new Queue<QueueItem>();
            for (int i = 0; i < n; i++)
            {
                queueTemp.Enqueue(new QueueItem(1 << i, i, 0));
                visited[1 << i][i] = 0;
            }

            var targetValue = (1 << n) - 1;
            while (queueTemp.Any())
            {
                var curItem = queueTemp.Dequeue();
                if (targetValue == curItem.Conver) return curItem.Steps;

                var newSteps = curItem.Steps + 1;
                foreach (var otherItem in graph[curItem.CurPos])
                {
                    var newConver = curItem.Conver | (1 << otherItem);

                    if (visited[newConver][otherItem] <= newSteps) continue;

                    visited[newConver][otherItem] = newSteps;
                    queueTemp.Enqueue(new QueueItem(newConver, otherItem, newSteps));
                }
            }

            return -1;
        }

        public class QueueItem
        {
            public QueueItem(int conver, int curPos, int step)
            {
                Conver = conver;
                CurPos = curPos;
                Steps = step;
            }

            public int Conver { get; set; }

            public int CurPos { get; set; }

            public int Steps { get; set; }
        }
    }
}
