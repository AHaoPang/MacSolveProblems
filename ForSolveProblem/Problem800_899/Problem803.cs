using System;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem803 : IProblem
    {
        public void RunProblem()
        {
            var temp = HitBricks(new int[][]
            {
                new int[]{1, 0, 0, 0},
                new int[]{1, 1, 1, 0 }
            },
            new int[][]
            {
                new int[]{1,0}
            });
            if (!ProblemHelper.ArrayIsEqual(temp, new int[] { 2 })) throw new Exception();

            temp = HitBricks(new int[][]
            {
                new int[]{1,0,0,0},
                new int[]{1,1,0,0}
            },
            new int[][]
            {
                new int[]{1,1},
                new int[]{1,0}
            });
            if (!ProblemHelper.ArrayIsEqual(temp, new int[] { 0, 0 })) throw new Exception();

            temp = HitBricks(new int[][]
            {
                new int[]{1,0,1},
                new int[]{1,1,1}
            },
            new int[][]
            {
                new int[]{0,0},
                new int[]{0,2},
                new int[]{1,1}
            });
            if (!ProblemHelper.ArrayIsEqual(temp, new int[] { 0, 3, 0 })) throw new Exception();
        }

        public int[] HitBricks(int[][] grid, int[][] hits)
        {
            /*
             * 题目概述：打砖块儿
             * 
             * 思路：
             *  1.实现并查集,除了Union 和 Find 功能外,还需要一个获取团队人数的功能
             *  2.拷贝一份儿砖块儿,把将要打掉的砖块儿全部打掉
             *  3.然后逆序把砖块儿加上来,加上来的过程中,特定团队增加的人数,就是要求的解
             *
             * 关键点：
             *
             * 时间复杂度：
             * 空间复杂度：
             */

            int rows = grid.Length;
            int cols = grid[0].Length;

            var copyGrid = new int[grid.Length][];
            for (int r = 0; r < grid.Length; r++)
            {
                copyGrid[r] = new int[grid[r].Length];
                for (int c = 0; c < grid[r].Length; c++)
                    copyGrid[r][c] = grid[r][c];
            }

            for (int i = 0; i < hits.Length; i++)
            {
                var r = hits[i][0];
                var c = hits[i][1];
                copyGrid[r][c] = 0;
            }

            var djs = new DisJointSet(rows * cols + 1);
            var visited = new bool[rows, cols];
            var specialNum = rows * cols;
            for (int r = 0; r < copyGrid.Length; r++)
            {
                for (int c = 0; c < copyGrid[r].Length; c++)
                {
                    if (copyGrid[r][c] == 0) continue;

                    if (r == 0)
                        Union(djs, specialNum, GetIndex(r, c, cols), specialNum);

                    Dfs(djs, copyGrid, r, c, visited);
                }
            }

            var forReturn = new int[hits.Length];
            var initTotal = djs.GetCount(specialNum);
            for (int i = hits.Length - 1; i >= 0; i--)
            {
                var r = hits[i][0];
                var c = hits[i][1];

                var tempValue = 0;
                if (grid[r][c] != 0)
                {
                    copyGrid[r][c] = 1;
                    if (r == 0) Union(djs, specialNum, GetIndex(r, c, cols), specialNum);

                    var upDownArray = new int[] { -1, 1, 0, 0 };
                    var leftRightArray = new int[] { 0, 0, -1, 1 };
                    for (int j = 0; j < 4; j++)
                    {
                        var newR = r + upDownArray[j];
                        var newC = c + leftRightArray[j];

                        if (newR < 0 || newR >= rows || newC < 0 || newC >= cols || copyGrid[newR][newC] != 1) continue;

                        Union(djs, GetIndex(r, c, cols), GetIndex(newR, newC, cols), specialNum);
                    }

                    var temp = djs.GetCount(specialNum);
                    tempValue = temp - initTotal - 1;
                    if (tempValue < 0) tempValue = 0;
                    initTotal = temp;
                }

                forReturn[i] = tempValue;
            }

            return forReturn;
        }

        private void Union(DisJointSet djs, int i,int j,int special)
        {
            var iParent = djs.Find(i);
            var jParent = djs.Find(j);

            if (iParent == special) djs.UnionToFrom(i, j);
            else if (jParent == special) djs.UnionToFrom(j, i);
            else djs.Union(i, j);
        }

        private int GetIndex(int row, int col, int cols) => row * cols + col;

        /// <summary>
        /// 目标是把周围的人都拽到自己的阵营里面
        /// </summary>
        private void Dfs(DisJointSet djs, int[][] grid, int row, int col, bool[,] visited)
        {
            if (visited[row, col]) return;
            visited[row, col] = true;

            int rows = grid.Length;
            int cols = grid[0].Length;

            var upDown = new int[] { -1, 1, 0, 0 };
            var leftRight = new int[] { 0, 0, -1, 1 };
            for (int i = 0; i < 4; i++)
            {
                var newRow = row + upDown[i];
                var newCol = col + leftRight[i];

                if (newRow >= 0 && newRow < rows && newCol >= 0 && newCol < cols && grid[newRow][newCol] == 1)
                {
                    Union(djs, GetIndex(row, col, cols), GetIndex(newRow, newCol, cols), rows * cols);
                    Dfs(djs, grid, newRow, newCol, visited);
                }
            }
        }
    }
}
