using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem274 : IProblem
    {
        public void RunProblem()
        {
            var temp = HIndex(new int[] { 3, 0, 6, 1, 5 });
            if (temp != 3) throw new Exception();
        }

        public int HIndex(int[] citations)
        {
            /*
             * h指数求解
             * 思路：
             *  1.当平均引用数量高的时候，受限于论文数量；
             *  2.当论文数量高时，受限于引用数量；
             *  3.所以，h指数，总是反映出短板的那一面，逻辑上引用次数会远高于论文数量，因此还是对论文数量有要求
             *  4.给定的论文数量是有限的，那么结果的取值基本也是有限的了
             *  5.引用次数超过论文数n的论文，也一定超过论文数n-1
             *  
             * 时间复杂度：O(1)，遍历2次数组，第一遍写值，第二遍逆序查找满足要求的
             * 空间复杂度：O(n)，需要一个同样大小的数组来做统计
             */

            int[] countArray = new int[citations.Length + 1];

            foreach (var citationItem in citations)
            {
                if (citationItem > citations.Length)
                {
                    countArray[citations.Length]++;
                    continue;
                }

                countArray[citationItem]++;
            }

            int totalNumTemp = 0;
            for (int i = countArray.Length - 1; i >= 0; i--)
            {
                totalNumTemp += countArray[i];

                if (i <= totalNumTemp) return i;
            }

            return 0;
        }
    }
}
