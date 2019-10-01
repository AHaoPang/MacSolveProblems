using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem119 : IProblem
    {
        public void RunProblem()
        {
            var temp = GetRow(3);
        }

        public IList<int> GetRow(int rowIndex)
        {
            /*
             * 返回杨辉三角的指定行
             * 思路：
             *  1.杨辉三角的每一步，都是基于前一步来的
             *  2.每一行都比上一行多一个数字，因此知道第几行的时候，其实指定行有多少个元素就是已知的了
             *  
             * 时间复杂度：O(n^2)
             * 空间复杂度：O(n)
             */

            IList<int> forReturn = new List<int>(rowIndex);

            for (int i = 0; i <= rowIndex; i++)
            {
                for (int j = i - 1; j > 0; j--)
                    forReturn[j] = forReturn[j - 1] + forReturn[j];

                forReturn.Add(1);
            }

            return forReturn;
        }
    }
}
