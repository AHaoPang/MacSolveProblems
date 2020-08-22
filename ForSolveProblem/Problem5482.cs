using System;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem5482 : IProblem
    {
        public void RunProblem()
        {
            var t = ContainsCycle(new char[][]
            {
                new char[]{'a','a','a','a'},
                new char[]{'a','b','b','a'},
                new char[]{'a','b','b','a'},
                new char[]{'a','a','a','a'},
            });
            if (t != true) throw new Exception();

            t = ContainsCycle(new char[][]
            {
                new char[]{'a','a','b'},
            });
            if (t != false) throw new Exception();

            t = ContainsCycle(new char[][]
            {
                new char[]{'c','c','c','a'},
                new char[]{'c','d','c','c'},
                new char[]{'c','c','e','c'},
                new char[]{'f','c','c','c'},
            });
            if (t != true) throw new Exception();

            t = ContainsCycle(new char[][]
            {
                new char[]{'a','b','b'},
                new char[]{'b','z','b'},
                new char[]{'b','b','a'},
            });
            if (t != false) throw new Exception();
        }

        public bool ContainsCycle(char[][] grid)
        {
            var r = grid.Length;
            var c = grid[0].Length;

            for (var i = 0; i < r; i++)
            {
                for (var j = 0; j < c; j++)
                {
                    if (grid[i][j] != '.')
                    {
                        if (j + 1 < c && i + 1 < r && grid[i][j] != grid[i + 1][j] && grid[i][j] != grid[i][j + 1])
                            continue;

                        var t = HasCycle(grid, i, j);
                        if (t) return true;
                    }
                }
            }

            return false;
        }

        private bool HasCycle(char[][] grid, int x, int y)
        {
            var r = grid.Length;
            var c = grid[0].Length;
            var curValue = grid[x][y];
            var path = new[] { 1, 2, 3, 4 };

            var visited = new bool[r, c];
            visited[x, y] = true;
            var queue = new Queue<entity>();
            queue.Enqueue(new entity(x, y, 0));
            grid[x][y] = '.';

            while (queue.Any())
            {
                var secondQueue = new Queue<entity>();
                while (queue.Any())
                {
                    var curItem = queue.Dequeue();
                    foreach (var pathItem in path)
                    {
                        if (curItem.From == pathItem) continue;

                        var nx = 0;
                        var ny = 0;
                        switch (pathItem)
                        {
                            case 1:
                                nx = curItem.X - 1;
                                ny = curItem.Y;
                                break;

                            case 2:
                                nx = curItem.X + 1;
                                ny = curItem.Y;
                                break;

                            case 3:
                                nx = curItem.X;
                                ny = curItem.Y - 1;
                                break;

                            case 4:
                                nx = curItem.X;
                                ny = curItem.Y + 1;
                                break;
                        }

                        if (nx < 0 || nx >= r || ny < 0 || ny >= c)
                            continue;

                        if (grid[nx][ny] == '.' && visited[nx, ny]) return true;

                        if (grid[nx][ny] != curValue)
                            continue;

                        visited[nx, ny] = true;

                        var nfrom = 0;
                        switch (pathItem)
                        {
                            case 1:
                                nfrom = 2;
                                break;

                            case 2:
                                nfrom = 1;
                                break;

                            case 3:
                                nfrom = 4;
                                break;

                            case 4:
                                nfrom = 3;
                                break;
                        }
                        secondQueue.Enqueue(new entity(nx, ny, nfrom));
                        grid[nx][ny] = '.';
                    }
                }

                if (secondQueue.Any())
                    queue = secondQueue;
            }

            return false;
        }

        class entity
        {
            public entity(int x, int y, int from)
            {
                this.X = x;
                this.Y = y;
                this.From = from;
            }

            public int X { get; set; }

            public int Y { get; set; }

            /// <summary>
            /// 0 - 无
            /// 1 - 上
            /// 2 - 下
            /// 3 - 左
            /// 4 - 右
            /// </summary>
            public int From { get; set; }
        }
    }
}
