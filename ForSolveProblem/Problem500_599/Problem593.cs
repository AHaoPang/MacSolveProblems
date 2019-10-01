using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem593 : IProblem
    {
        public void RunProblem()
        {
            var temp = ValidSquare(new int[] { 0, 0 }, new int[] { 1, 1 }, new int[] { 1, 0 }, new int[] { 0, 1 });
            if (temp != true) throw new Exception();
        }

        public bool ValidSquare(int[] p1, int[] p2, int[] p3, int[] p4)
        {
            /*
             * 判断平面上给定的4个点，是否构成一个正方形
             * 思路：
             *  1. 4个点，可以构成6条边，只要满足4条边（正边）相等，2条边（对角线）相等，即可
             *  
             * 时间复杂度：O(1)
             * 空间复杂度：O(1)
             */

            var lengthDic = new Dictionary<int, int>();
            int[][] points = new int[][] { p1, p2, p3, p4 };
            for (int i = 0; i < points.GetLength(0); i++)
            {
                for (int j = i + 1; j < points.GetLength(0); j++)
                {
                    var xLength = points[j][0] - points[i][0];
                    var yLength = points[j][1] - points[i][1];
                    var sumLength = xLength * xLength + yLength * yLength;

                    if (!lengthDic.ContainsKey(sumLength)) lengthDic[sumLength] = 0;
                    lengthDic[sumLength]++;
                }
            }

            if (lengthDic.Count == 2)
            {
                if (lengthDic.First().Value == 2 && lengthDic.Last().Value == 4) return true;
                if (lengthDic.First().Value == 4 && lengthDic.Last().Value == 2) return true;
            }

            return false;
        }
    }
}
