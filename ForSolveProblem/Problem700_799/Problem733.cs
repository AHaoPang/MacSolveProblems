using System;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem733 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int[][] FloodFill(int[][] image, int sr, int sc, int newColor)
        {
            var curColor = image[sr][sc];
            if (curColor == newColor) return image;

            var r = image.Length;
            var c = image[0].Length;
            var arr = new int[][]
            {
                new[]{-1,0},
                new[]{1,0},
                new[]{0,-1},
                new[]{0,1}
            };

            var queue = new Queue<int[]>();
            queue.Enqueue(new[] { sr, sc });

            while (queue.Any())
            {
                var curPos = queue.Dequeue();
                foreach (var arrItem in arr)
                {
                    var newR = curPos[0] + arrItem[0];
                    var newC = curPos[1] + arrItem[1];

                    if (newR >= 0 && newR < r && newC >= 0 && newC < c && image[newR][newC] == curColor)
                        queue.Enqueue(new[] { newR, newC });
                }

                image[curPos[0]][curPos[1]] = newColor;
            }

            return image;
        }
    }
}
