using System;
namespace ForSolveProblem
{
    public class Interview_16_03 : IProblem
    {
        public void RunProblem()
        {
            var temp = Intersection(new[] { 0, 0 }, new[] { 1, 0, }, new[] { 1, 1 }, new[] { 0, -1 });
            ProblemHelper.ArrayEqual(temp, new[] { 0.5, 0 });

            temp = Intersection(new[] { 0, 0 }, new[] { 3, 3 }, new[] { 1, 1 }, new[] { 2, 2 });
            ProblemHelper.ArrayEqual(temp, new[] { 1.0, 1 });

            temp = Intersection(new[] { 0, 0 }, new[] { 1, 1 }, new[] { 1, 0 }, new[] { 2, 1 });
            ProblemHelper.ArrayEqual(temp, new double[] { });

            temp = Intersection(new[] { 1, 0 }, new[] { 1, 1 }, new[] { -1, 0 }, new[] { 3, 2 });
        }

        public double[] Intersection(int[] start1, int[] end1, int[] start2, int[] end2)
        {
            var x1 = start1[0];
            var y1 = start1[1];
            var x2 = end1[0];
            var y2 = end1[1];
            var x3 = start2[0];
            var y3 = start2[1];
            var x4 = end2[0];
            var y4 = end2[1];

            var res = new double[2];
            var hasValue = false;
            if ((y4 - y3) * (x2 - x1) == (y2 - y1) * (x4 - x3))
            {
                if ((y2 - y1) * (x3 - x1) == (y3 - y1) * (x2 - x1))
                {
                    if (IsInside(x1, y1, x3, y3, x4, y4))
                        UpdatePoint(res, ref hasValue, x1, y1);

                    if (IsInside(x2, y2, x3, y3, x4, y4))
                        UpdatePoint(res, ref hasValue, x2, y2);

                    if (IsInside(x3, y3, x1, y1, x2, y2))
                        UpdatePoint(res, ref hasValue, x3, y3);

                    if (IsInside(x4, y4, x1, y1, x2, y2))
                        UpdatePoint(res, ref hasValue, x4, y4);
                }
            }
            else
            {
                var t1 = (x3 * (y4 - y3) + y1 * (x4 - x3) - y3 * (x4 - x3) - x1 * (y4 - y3)) * 1.0 / ((x2 - x1) * (y4 - y3) - (x4 - x3) * (y2 - y1));
                var t2 = (x1 * (y2 - y1) + y3 * (x2 - x1) - y1 * (x2 - x1) - x3 * (y2 - y1)) * 1.0 / ((x4 - x3) * (y2 - y1) - (x2 - x1) * (y4 - y3));

                if (t1 >= 0 && t1 <= 1.0 && t2 >= 0 && t2 <= 1.0)
                    return new double[] { x1 + t1 * (x2 - x1), y1 + t1 * (y2 - y1) };
            }

            return hasValue ? res : new double[0];
        }

        private bool IsInside(int x1, int y1, int x2, int y2, int x3, int y3)
        {
            return (x1 == x2 || (x1 >= Math.Min(x2, x3) && x1 <= Math.Max(x2, x3))) && (y1 == y2 || (y1 >= Math.Min(y2, y3) && y1 <= Math.Max(y2, y3)));
        }

        private void UpdatePoint(double[] res, ref bool hasValue, int x1, int y1)
        {
            if (!hasValue || x1 < res[0] || (x1 == res[0] && y1 < res[1]))
            {
                res[0] = x1;
                res[1] = y1;

                hasValue = true;
            }
        }
    }
}
