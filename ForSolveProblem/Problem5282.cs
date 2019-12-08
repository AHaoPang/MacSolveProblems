using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem5282 : IProblem
    {
        public void RunProblem()
        {
            var temp = MinFlips(new int[][]
            {
                new int[]{0,0},
                new int[]{0,1}
            });
            if (temp != 3) throw new Exception();

            temp = MinFlips(new int[][]
            {
                new int[]{0}
            });
            if (temp != 0) throw new Exception();

            temp = MinFlips(new int[][]
            {
                new int[]{1,1,1},
                new int[]{1,0,1},
                new int[]{0,0,0}
            });
            if (temp != 6) throw new Exception();

            temp = MinFlips(new int[][]
            {
                new int[]{1,0,0},
                new int[]{1,0,0}
            });
            if (temp != -1) throw new Exception();
        }

        public int MinFlips(int[][] mat)
        {
            var queueTemp = new PriorityQueue<QueueItem>(false);
            queueTemp.AddData(new QueueItem(0, mat));
            var visited = new HashSet<int>();
            while (queueTemp.HasData())
            {
                var curDate = queueTemp.GetData();
                var curMat = curDate.CurMat;

                var curNum = GetCurValue(curMat);
                if (curNum == 0) return curDate.Level;

                if (visited.Contains(curNum)) continue;
                visited.Add(curNum);

                for (int i = 0; i < curMat.Length; i++)
                {
                    for (int j = 0; j < curMat[i].Length; j++)
                    {
                        ChangeValue(curMat, i, j);
                        queueTemp.AddData(new QueueItem(curDate.Level + 1, curMat));
                        ChangeValue(curMat, i, j);
                    }
                }
            }

            return -1;
        }

        class QueueItem : IComparable<QueueItem>
        {
            public QueueItem(int level, int[][] mat)
            {
                Level = level;

                CurMat = new int[mat.Length][];
                for (int i = 0; i < mat.Length; i++)
                {
                    CurMat[i] = new int[mat[i].Length];
                    for (int j = 0; j < mat[i].Length; j++)
                        CurMat[i][j] = mat[i][j];
                }
            }

            public int Level { get; set; }

            public int[][] CurMat { get; set; }

            public int CompareTo(QueueItem other)
            {
                if (other.Level == this.Level) return 0;

                return this.Level > other.Level ? 1 : -1;
            }
        }

        private void ChangeValue(int[][] mat, int r, int c)
        {
            var rows = mat.Length;
            var cols = mat[0].Length;

            var upDownArray = new int[] { 0, -1, 1, 0, 0 };
            var leftRightArray = new int[] { 0, 0, 0, -1, 1 };
            for (int i = 0; i < upDownArray.Length; i++)
            {
                var rTemp = r + upDownArray[i];
                var cTemp = c + leftRightArray[i];

                if (rTemp < 0 || rTemp >= rows || cTemp < 0 || cTemp >= cols) continue;

                mat[rTemp][cTemp] = GetValue(mat[rTemp][cTemp]);
            }
        }

        private int GetValue(int v) => v == 0 ? 1 : 0;

        private int GetCurValue(int[][] mat)
        {
            var forReturn = 0;
            for (int i = 0; i < mat.Length; i++)
            {
                for (int j = 0; j < mat[i].Length; j++)
                {
                    if (mat[i][j] == 0) continue;

                    var curValue = i * mat.Length + j;
                    forReturn |= (1 << curValue);
                }
            }

            return forReturn;
        }
    }
}
