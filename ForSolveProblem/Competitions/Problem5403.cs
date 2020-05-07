using System;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem5403 : IProblem
    {
        public void RunProblem()
        {
            var mat = new int[][]
            {
                new[]{1,3,11},
                new[]{2,4,6}
            };
            var temp = KthSmallest(mat, 5);
        }

        public int KthSmallest(int[][] mat, int k)
        {
            var r = mat.Length;
            var c = mat[0].Length;

            var list = new List<int>() { 0 };
            for (var i = 0; i < r; i++)
            {
                var newlist = new List<int>();
                for (var j = 0; j < c; j++)
                    for (var l = 0; l < list.Count; l++)
                        newlist.Add(list[l] + mat[i][j]);

                list = newlist.OrderBy(i => i).Take(k).ToList();
            }

            return list[k - 1];
        }

        public int KthSmallest1(int[][] mat, int k)
        {
            var c = mat[0].Length;

            var maxNum = 1L;
            var i = 0;
            for (; i < mat.Length; i++)
            {
                maxNum *= c;
                if (maxNum > k)
                    break;
            }
            var limitC = i + 1;


            m_res = 0;
            Recursive(mat, 0, k, limitC);

            return m_res;
        }

        private int m_res;

        private void Recursive(int[][] mat, int curIndex, int k, int limitC)
        {
            if (mat.Length - 1 - curIndex + 1 > limitC)
            {
                m_res += mat[curIndex][0];
                Recursive(mat, curIndex + 1, k, limitC);
            }
            else
            {
                var oneSum = (int)Math.Pow(mat[0].Length, limitC - 1);
                var i = 1;
                while (oneSum < k)
                {
                    oneSum *= 2;
                    i++;
                }
                m_res += mat[curIndex][i];
                Recursive(mat, curIndex + 1, k - (oneSum / 2), limitC - 1);
            }
        }
    }
}
