using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem478 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            private double m_x;
            private double m_y;
            private double m_r;
            Random r;

            public Solution(double radius, double x_center, double y_center)
            {
                m_x = x_center;
                m_y = y_center;
                m_r = radius;

                r = new Random();
            }

            public double[] RandPoint()
            {
                while (true)
                {
                    var x = r.NextDouble() * 2 * m_r - m_r;
                    var y = r.NextDouble() * 2 * m_r - m_r;

                    var l = x * x + y * y;

                    if (l <= m_r * m_r) return new double[] { m_x + x, m_y + y };
                }
            }
        }
    }
}
