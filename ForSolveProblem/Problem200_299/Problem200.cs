using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem200 : IProblem
    {
        public void RunProblem()
        {
            var charArray = new char[,]
            {
                { '1', '1', '1', '1', '0' },
                { '1', '1', '0', '1', '0' },
                { '1', '1', '0', '0', '0' },
                { '0', '0', '0', '0', '0' }
            };

            var temp = NumIslands(charArray);
        }

        public int NumIslands(char[][] grid)
        {
            var res = 0;
            for (var r = 0; r < grid.Length; r++)
            {
                for (var c = 0; c < grid[r].Length; c++)
                {
                    if (grid[r][c] != '1') continue;

                    res++;
                    DfsSearch(grid, r, c);
                }
            }

            return res;
        }

        private void DfsSearch(char[][] grid, int r, int c)
        {
            var rows = grid.Length;
            var cols = grid[0].Length;

            if (r >= 0 && r < rows && c >= 0 && c < cols && grid[r][c] == '1')
            {
                grid[r][c] = '0';
                var arr = new int[][] { new[] { -1, 0 }, new[] { 1, 0 }, new[] { 0, -1 }, new[] { 0, 1 } };
                foreach (var arrItem in arr)
                {
                    var nr = r + arrItem[0];
                    var nc = c + arrItem[1];
                    DfsSearch(grid, nr, nc);
                }
            }
        }

        public int NumIslands(char[,] grid)
        {
            /*
             * 并查集的解题思路
             * 构造并查集，初始化的时候，独立成营，然后依据外部依赖条件将独立的部分联合起来，最终会得到岛屿总数
             * 并查集支持的基本操作：
             * 1.阵营个数统计；
             * 2.查找大Boss；
             * 3.将两个小的阵营合并成大的阵营
             * 
             * 若OK，可以考虑最并查集做优化
             */

            var uf = new UF(grid);

            int x = grid.GetLength(0);
            int y = grid.GetLength(1);

            for (int i = 0; i < x; i++)
                for (int j = 0; j < y; j++)
                {
                    if (grid[i, j] != '1') continue;

                    if (i - 1 >= 0 && grid[i - 1, j] == '1')
                        uf.Union(i * y + j, (i - 1) * y + j);

                    if (j - 1 >= 0 && grid[i, j - 1] == '1')
                        uf.Union(i * y + j, i * y + j - 1);
                }

            return uf.Count;
        }

        class UF
        {
            private int[] ufArray;

            public int Count { get; set; }

            /// <summary>
            /// 初始化：统计有多少个符合条件的岛屿
            /// </summary>
            public UF(char[,] grid)
            {
                ufArray = new int[grid.Length];

                int x = grid.GetLength(0);
                int y = grid.GetLength(1);

                for (int i = 0; i < x; i++)
                    for (int j = 0; j < y; j++)
                    {
                        if (grid[i, j] == '1')
                        {
                            Count++;
                            ufArray[i * y + j] = i * y + j;
                        }
                    }
            }

            /// <summary>
            /// 查找一个独立单元所属的阵营
            /// </summary>
            private int FindRoot(int i)
            {
                /* 此处使用了路径压缩 */

                int root = i;
                while (ufArray[root] != root)
                    root = ufArray[root];

                while (ufArray[i] != i)
                {
                    i = ufArray[i];
                    ufArray[i] = root;
                }

                return root;
            }

            /// <summary>
            /// 将两个阵营做合并
            /// </summary>
            public void Union(int i, int j)
            {
                int rootI = FindRoot(i);
                int rootJ = FindRoot(j);

                ufArray[rootI] = rootJ;

                if (rootI != rootJ) Count--;
            }
        }

        #region Way1
        public int NumIslands1(char[,] grid)
        {

            /*
             * 深度优先染色
             * 发现岛屿，那么就用DFS的方式把整个岛屿夷为平地
             * 知道检索完整个范围以后方可结束
             * 时间复杂度：O(n^2)
             * 空间复杂度：和递归相关
             */

            int numIslands = 0;
            int zeroDimension = grid.GetLength(0);
            int oneDimension = grid.GetLength(1);

            for (int i = 0; i < zeroDimension; i++)
            {
                for (int j = 0; j < oneDimension; j++)
                {
                    if (grid[i, j] == '0') continue;

                    numIslands++;

                    Recursive(i, j, zeroDimension, oneDimension, grid);
                }
            }

            return numIslands;
        }

        private void Recursive(int i, int j, int maxI, int maxJ, char[,] grid)
        {
            if (i < 0 || i >= maxI) return;
            if (j < 0 || j >= maxJ) return;
            if (grid[i, j] != '1') return;

            grid[i, j] = '0';

            Recursive(i - 1, j, maxI, maxJ, grid);
            Recursive(i + 1, j, maxI, maxJ, grid);
            Recursive(i, j - 1, maxI, maxJ, grid);
            Recursive(i, j + 1, maxI, maxJ, grid);
        }
        #endregion
    }
}
