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

        private bool HasCycle(char[][] grid, int rt, int ct)
        {
            var r = grid.Length;
            var c = grid[0].Length;
            var curValue = grid[rt][ct];
            var path = new[] { 1, 2, 3, 4 };

            var visited = new bool[r, c];
            visited[rt, ct] = true;
            var queue = new Queue<Entity>();
            queue.Enqueue(new Entity(rt, ct, 0));
            grid[rt][ct] = '.';

            while (queue.Any())
            {
                var secondQueue = new Queue<Entity>();
                while (queue.Any())
                {
                    var curItem = queue.Dequeue();
                    foreach (var pathItem in path)
                    {
                        //不走回头路
                        if (curItem.From == pathItem) continue;

                        //确定新的位置
                        var nr = 0;
                        var nc = 0;
                        switch (pathItem)
                        {
                            case 1:
                                nr = curItem.R - 1;
                                nc = curItem.C;
                                break;

                            case 2:
                                nr = curItem.R + 1;
                                nc = curItem.C;
                                break;

                            case 3:
                                nr = curItem.R;
                                nc = curItem.C - 1;
                                break;

                            case 4:
                                nr = curItem.R;
                                nc = curItem.C + 1;
                                break;
                        }

                        if (nr < 0 || nr >= r || nc < 0 || nc >= c)
                            continue;

                        //确定了位置重叠
                        if (grid[nr][nc] == '.' && visited[nr, nc]) return true;

                        if (grid[nr][nc] != curValue)
                            continue;

                        visited[nr, nc] = true;

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
                        secondQueue.Enqueue(new Entity(nr, nc, nfrom));
                        grid[nr][nc] = '.';
                    }
                }

                if (secondQueue.Any())
                    queue = secondQueue;
            }

            return false;
        }

        class Entity
        {
            public Entity(int r, int c, int from)
            {
                R = r;
                C = c;
                From = from;
            }

            public int R { get; set; }

            public int C { get; set; }

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
