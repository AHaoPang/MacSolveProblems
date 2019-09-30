using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem944 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int MinDeletionSize(string[] A)
        {
            /*
             * 对于字符串数组，期望每一列是升序排序的
             * 思路：
             *  1.一共有多少列，需要挨个检查
             *  2.不满足要求的列，要列出来
             *  
             * 时间复杂度：O(m*n)
             * 空间复杂度：O(m)
             */

            var firstLine = A.FirstOrDefault();
            if (firstLine == null) return 0;

            List<int> forReturnCount = new List<int>();
            var length = firstLine.Length;
            for (int col = 0; col < length; col++)
            {
                for (int row = 0; row < A.Length - 1; row++)
                {
                    if (A[row][col] <= A[row + 1][col]) continue;

                    forReturnCount.Add(col);
                    break;
                }
            }

            return forReturnCount.Count();
        }
    }
}
