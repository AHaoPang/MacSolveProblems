using System;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem1584 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int MinCostConnectPoints(int[][] points)
        {
            var n = points.Length;
            var l = new List<Edge>(n * n);
            for (var i = 0; i < n - 1; i++)
            {
                for (var j = i + 1; j < n; j++)
                {
                    var length = Math.Abs(points[i][0] - points[j][0]) + Math.Abs(points[i][1] - points[j][1]);
                    l.Add(new Edge(i, j, length));
                }
            }

            var orderList = l.OrderBy(i => i.Length);
            var res = 0;
            var uf = new UF(n);
            foreach (var listItem in orderList)
            {
                var fx = uf.Find(listItem.X);
                var fy = uf.Find(listItem.Y);
                if (fx != fy)
                {
                    res += listItem.Length;
                    uf.Union(fx, fy);
                }
            }

            return res;
        }

        class Edge
        {
            public Edge(int x, int y, int length)
            {
                X = x;
                Y = y;
                Length = length;
            }
            public int X { get; set; }
            public int Y { get; set; }
            public int Length { get; set; }
        }

        class UF
        {
            private int[] m_arr;

            public UF(int n)
            {
                m_arr = new int[n];
                for (var i = 0; i < n; i++)
                    m_arr[i] = i;
            }

            public int Find(int i) => m_arr[i] == i ? i : m_arr[i] = Find(m_arr[i]);

            public void Union(int x, int y) => m_arr[x] = y;
        }
    }
}
