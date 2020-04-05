using System;
namespace ForSolveProblem
{
    public class Problem5361 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public bool CheckOverlap(int radius, int x_center, int y_center, int x1, int y1, int x2, int y2)
        {
            if (x_center >= x1 && x_center <= x2 && y_center >= y1 && y_center <= y2)
                return true;

            var cenX = (x1 + x2) / 2;
            var cenY = (y1 + y2) / 2;
            if (GetDistance(x_center, y_center, radius, cenX, cenY))
                return true;

            var xLeft = x_center - radius;
            var xRight = x_center + radius;
            var yUp = y_center + radius;
            var yDown = y_center - radius;

            var arr = new int[][] { new[] { x1, y1 }, new[] { x2, y2 }, new[] { x1, y2 }, new[] { x2, y1 } };
            foreach (var arrItem in arr)
            {
                if (arrItem[0] >= xLeft && arrItem[0] <= xRight && arrItem[1] >= yDown && arrItem[1] <= yUp)
                {
                    if (GetDistance(x_center, y_center, radius, arrItem[0], arrItem[1]))
                        return true;
                }
            }

            var rArr = new int[][] { new[] { x_center, yUp }, new[] { x_center, yDown }, new[] { xLeft, y_center }, new[] { xRight, y_center } };
            foreach (var rItem in rArr)
            {
                if (rItem[0] >= x1 && rItem[0] <= x2 && rItem[1] >= y1 && rItem[1] <= y2)
                    return true;
            }

            return false;
        }

        private bool GetDistance(int x_center, int y_center, int radius, int x, int y)
        {
            return (x_center - x) * (x_center - x) + (y_center - y) * (y_center - y) <= radius * radius;
        }
    }
}
