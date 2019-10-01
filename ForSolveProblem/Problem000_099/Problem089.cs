using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem089 : IProblem
    {
        public void RunProblem()
        {
            var temp = GrayCode(2);

            temp = GrayCode(3);
        }

        public IList<int> GrayCode(int n)
        {
            /*
             * 输出特定规律的编码，格雷编码
             * 思路：
             *  1.给定位数量n，那么结果总数是2^n
             *  2.编码之间相邻仅1个位是不同的
             *  3.思考这种指数级别的增长和差异，发现其与镜子的效果是一致的！
             *  4.关键在于，能想清楚n逐渐增加时，他们之间的相互关系
             *  5.一下子得到最终的集合比较困难，但是通过比较两个集合的差异，也可以逐步得到结果，这种思想还是很不错的~
             *  
             * 举例：
             *  n = 0   {0}
             *  n = 1   {0} | {1}
             *  n = 2   {00}{01} | {11}{10}
             *  n = 3   {000}{001}{011}{010} | {110}{111}{101}{100}
             */

            var forReturn = new List<int>((int)Math.Pow(2, n)) { 0 };

            for (int i = 0; i < n; i++)
            {
                var t = 1 << i;

                for (int j = forReturn.Count - 1; j >= 0; j--)
                    forReturn.Add(t + forReturn[j]);
            }

            return forReturn;
        }
    }
}
