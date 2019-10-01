using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem118 : IProblem
    {
        public void RunProblem()
        {
            var temp = Generate(5);
        }

        public IList<IList<int>> Generate(int numRows)
        {
            /*
             * 生成杨辉三角的指定行
             * 思路：
             *  1.生成个规律是已知的
             *  2.可以依据循环的方式来，一步步的生成
             * 
             * 时间复杂度：O(n^2)
             * 空间复杂度：O(n^2)
             */

            IList<IList<int>> forReturn = new List<IList<int>>();
            if (numRows < 1) return forReturn;

            IList<int> preLine = new List<int>() { 1 };
            forReturn.Add(preLine);

            for (int i = 2; i <= numRows; i++)
            {
                var nextLine = new List<int>() { 1 };
                for (int j = 0; j < preLine.Count; j++)
                {
                    if (j + 1 < preLine.Count)
                        nextLine.Add(preLine[j + 1] + preLine[j]);
                    else
                        nextLine.Add(preLine[j]);
                }

                preLine = nextLine;
                forReturn.Add(nextLine);
            }

            return forReturn;
        }
    }
}
