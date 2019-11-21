using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ForSolveProblem
{
    public class Problem1263 : IProblem
    {
        public void RunProblem()
        {
            var temp = MinPushBox(new char[][]
            {
                new char[]{'#', '#', '#', '#', '#', '#'},
                new char[]{'#', 'T', '#', '#', '#', '#'},
                new char[]{'#', '.', '.', 'B', '.', '#'},
                new char[]{'#', '.', '#', '#', '.', '#'},
                new char[]{'#', '.', '.', '.', 'S', '#'},
                new char[]{ '#', '#', '#', '#', '#', '#' }
            });
            if (temp != 3) throw new Exception();

            temp = MinPushBox(new char[][]
            {
                new char[]{'#', '#', '#', '#', '#', '#'},
                new char[]{'#', 'T', '#', '#', '#', '#'},
                new char[]{'#', '.', '.', 'B', '.', '#'},
                new char[]{'#', '#', '#', '#', '.', '#'},
                new char[]{'#', '.', '.', '.', 'S', '#'},
                new char[]{'#', '#', '#', '#', '#', '#' }
            });
            if (temp != -1) throw new Exception();

            temp = MinPushBox(new char[][]
            {
               new char[]{'#', '#', '#', '#', '#', '#'},
               new char[]{'#', 'T', '.', '.', '#', '#'},
               new char[]{'#', '.', '#', 'B', '.', '#'},
               new char[]{'#', '.', '.', '.', '.', '#'},
               new char[]{'#', '.', '.', '.', 'S', '#'},
               new char[]{'#', '#', '#', '#', '#', '#' }
            });
            if (temp != 5) throw new Exception();

            temp = MinPushBox(new char[][]
            {
                new char[]{'#', '#', '#', '#', '#', '#', '#'},
                new char[]{'#', 'S', '#', '.', 'B', 'T', '#'},
                new char[]{'#', '#', '#', '#', '#', '#', '#' }
            });
            if (temp != -1) throw new Exception();
        }

        public int MinPushBox(char[][] grid)
        {
            var boxPos = new int[2];
            var personPos = new int[2];
            for (int r = 0; r < grid.Length; r++)
            {
                for (int c = 0; c < grid[r].Length; c++)
                {
                    if (grid[r][c] == 'B')
                    {
                        boxPos = new int[] { r, c };
                        grid[r][c] = '.';
                    }
                    else if (grid[r][c] == 'S')
                    {
                        personPos = new int[] { r, c };
                        grid[r][c] = '.';
                    }
                }
            }

            var initStatus = new CurStatus()
            {
                CurSteps = 0,
                BoxRow = boxPos[0],
                BoxCol = boxPos[1],
                PersonRow = personPos[0],
                PersonCol = personPos[1]
            };
            var pq = new PriorityQueue<CurStatus>(true);
            pq.AddData(initStatus);

            var rows = grid.Length;
            var cols = grid[0].Length;
            var statusHash = new HashSet<CurStatus>() { initStatus };
            var upDownArray = new int[] { -1, 1, 0, 0 };
            var leftRightArray = new int[] { 0, 0, -1, 1 };
            while (pq.HasData())
            {
                var statusTemp = pq.GetData();
                for (int i = 0; i < 4; i++)
                {
                    var personRowTemp = statusTemp.PersonRow + upDownArray[i];
                    var personColTemp = statusTemp.PersonCol + leftRightArray[i];

                    if (personRowTemp >= rows || personRowTemp < 0 || personColTemp >= cols || personColTemp < 0) continue;
                    if (grid[personRowTemp][personColTemp] == '#') continue;

                    if (personRowTemp == statusTemp.BoxRow && personColTemp == statusTemp.BoxCol)
                    {
                        var boxRowTemp = statusTemp.BoxRow + upDownArray[i];
                        var boxColTemp = statusTemp.BoxCol + leftRightArray[i];

                        if (boxRowTemp >= rows || boxRowTemp < 0 || boxColTemp >= cols || boxColTemp < 0) continue;
                        if (grid[boxRowTemp][boxColTemp] == '#') continue;

                        if (grid[boxRowTemp][boxColTemp] == 'T') return statusTemp.CurSteps + 1;

                        var newStatus = new CurStatus()
                        {
                            CurSteps = statusTemp.CurSteps + 1,
                            BoxCol = boxColTemp,
                            BoxRow = boxRowTemp,
                            PersonCol = personColTemp,
                            PersonRow = personRowTemp
                        };
                        if (!statusHash.Contains(newStatus))
                        {
                            pq.AddData(newStatus);
                            statusHash.Add(newStatus);
                        }
                    }
                    else
                    {
                        var newStatus = new CurStatus()
                        {
                            CurSteps = statusTemp.CurSteps,
                            BoxCol = statusTemp.BoxCol,
                            BoxRow = statusTemp.BoxRow,
                            PersonCol = personColTemp,
                            PersonRow = personRowTemp
                        };
                        if (!statusHash.Contains(newStatus))
                        {
                            pq.AddData(newStatus);
                            statusHash.Add(newStatus);
                        }
                    }
                }
            }

            return -1;
        }

        /// <summary>
        /// 表示 箱子 人 目标移动距离 的状态
        /// </summary>
        class CurStatus : IComparable<CurStatus>
        {
            public int CurSteps { get; set; }

            public int BoxRow { get; set; }

            public int BoxCol { get; set; }

            public int PersonRow { get; set; }

            public int PersonCol { get; set; }

            public int CompareTo([AllowNull] CurStatus other)
            {
                if (this.CurSteps == other.CurSteps) return 0;
                if (this.CurSteps > other.CurSteps) return 1;

                return -1;
            }

            public override int GetHashCode()
            {
                return BoxRow + BoxCol + PersonRow + PersonCol;
            }

            public override bool Equals(object obj)
            {
                if (obj is CurStatus)
                {
                    var anotherStatus = obj as CurStatus;

                    return 
                        anotherStatus.BoxRow == this.BoxRow &&
                        anotherStatus.BoxCol == this.BoxCol &&
                        anotherStatus.PersonRow == this.PersonRow &&
                        anotherStatus.PersonCol == this.PersonCol;
                }
                else
                    return base.Equals(obj);
            }
        }
    }
}
