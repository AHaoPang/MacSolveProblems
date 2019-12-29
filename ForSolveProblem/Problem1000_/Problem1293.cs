using System;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem1293 : IProblem
    {
        public void RunProblem()
        {
            var temp = ShortestPath(new int[][]
            {
                 new int[]{0, 0, 0},
                 new int[]{1, 1, 0},
                 new int[]{0, 0, 0},
                 new int[]{0, 1, 1},
                 new int[]{0, 0, 0 }
            }, 1);
            if (temp != 6) throw new Exception();

            temp = ShortestPath(new int[][]
            {
                 new int[]{0, 1, 1 },
                 new int[]{1, 1, 1},
                 new int[]{1, 0, 0}
            }, 1);
            if (temp != -1) throw new Exception();

            temp = ShortestPath(new int[][]
            {
                    new int[]{0, 0, 1, 0, 1, 1, 1, 0 },
                    new int[]{1, 1, 0, 1, 0, 1, 0, 0},
                    new int[]{1, 1, 0, 0, 1, 0, 1, 1},
                    new int[]{1, 1, 0, 1, 0, 1, 0, 0},
                    new int[]{1, 0, 0, 1, 0, 1, 0, 1},
                    new int[]{0, 0, 1, 1, 1, 0, 0, 1},
                    new int[]{0, 1, 0, 1, 1, 1, 1, 0},
                    new int[]{1, 0, 0, 0, 1, 1, 1, 0},
                    new int[]{0, 0, 0, 1, 0, 0, 0, 1},
                    new int[]{1, 0, 1, 0, 0, 0, 1, 0},
                    new int[]{1, 0, 1, 0, 1, 1, 1, 1},
                    new int[]{1, 1, 1, 0, 0, 0, 0, 1},
                    new int[]{0, 0, 1, 1, 1, 1, 0, 0},
                    new int[]{0, 1, 0, 1, 0, 1, 0, 1},
                    new int[]{1, 1, 0, 0, 1, 0, 0, 0},
                    new int[]{0, 1, 1, 1, 0, 0, 1, 1},
                    new int[]{0, 1, 0, 0, 0, 0, 1, 0},
                    new int[]{1, 1, 1, 0, 1, 0, 0, 0},
                    new int[]{1, 0, 1, 1, 1, 1, 1, 0},
                    new int[]{0, 1, 0, 1, 0, 0, 1, 0},
                    new int[]{1, 1, 1, 1, 0, 1, 0, 1},
                    new int[]{0, 0, 0, 0, 0, 0, 1, 1},
                    new int[]{0, 1, 0, 0, 0, 0, 1, 1},
                    new int[]{1, 1, 1, 0, 0, 0, 1, 1},
                    new int[]{0, 1, 0, 0, 1, 0, 0, 1},
                    new int[]{1, 0, 0, 1, 0, 1, 0, 0},
                    new int[]{0, 0, 0, 0, 1, 1, 0, 1},
                    new int[]{0, 0, 1, 0, 1, 0, 1, 0},
                    new int[]{0, 1, 1, 1, 1, 0, 1, 0}
            }, 3);

        }

        public int ShortestPath(int[][] grid, int k)
        {
            var rows = grid.Length;
            var cols = grid[0].Length;
            if (rows == 1 && cols == 1) return 0;

            k = Math.Min(rows + cols - 3, k);

            var visitedArray = new int[rows, cols];
            for (int r = 0; r < rows; r++)
                for (int c = 0; c < cols; c++)
                    visitedArray[r, c] = -1;
            visitedArray[0, 0] = k;

            var queue = new Queue<QueueItem>();
            queue.Enqueue(new QueueItem(0, k, 0, 0));

            var upDownArray = new int[] { -1, 1, 0, 0 };
            var leftRightArray = new int[] { 0, 0, -1, 1 };
            while (queue.Any())
            {
                var curQueueItem = queue.Dequeue();
                for (int i = 0; i < upDownArray.Length; i++)
                {
                    var newRow = curQueueItem.X + upDownArray[i];
                    var newCol = curQueueItem.Y + leftRightArray[i];

                    if (newRow == rows - 1 && newCol == cols - 1) return curQueueItem.Steps + 1;

                    if (newRow < 0 || newRow >= rows || newCol < 0 || newCol >= cols) continue;

                    var newk = curQueueItem.K;
                    if (grid[newRow][newCol] == 1)
                    {
                        if (newk == 0) continue;

                        newk = curQueueItem.K - 1;
                    }

                    if (visitedArray[newRow, newCol] == -1 || visitedArray[newRow, newCol] < newk)
                    {
                        visitedArray[newRow, newCol] = newk;
                        queue.Enqueue(new QueueItem(curQueueItem.Steps + 1, newk, newRow, newCol));
                    }
                }
            }

            return -1;
        }

        public class QueueItem
        {
            public QueueItem(int steps, int k, int x, int y)
            {
                Steps = steps;
                K = k;
                X = x;
                Y = y;
            }

            public int Steps { get; set; }

            public int K { get; set; }

            public int X { get; set; }

            public int Y { get; set; }
        }
    }
}
