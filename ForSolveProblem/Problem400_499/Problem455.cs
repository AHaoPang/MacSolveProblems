using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem455 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int FindContentChildren(int[] g, int[] s)
        {
            /*
             * 此种方式，时间复杂度是: O(n)，是线性的！
             */

            int gIndex = 0;
            int sIndex = 0;

            var nG = g.OrderBy(i => i).ToList();
            var nS = s.OrderBy(i => i).ToList();

            while (gIndex < g.Length && sIndex < s.Length)
            {
                //只有满足孩子，孩子指针会下移一位
                if (nG[gIndex] <= nS[sIndex]) gIndex++;

                //一轮结束，无论是否满足，饼干都是要下移一位
                sIndex++;
            }

            return gIndex;
        }



        public int FindContentChildren2(int[] g, int[] s)
        {
            /*
             * 找到最优解的思考：
             * 1.穷举出孩子和饼干的全排列，然后从中过滤出最优解；
             * 2.这种方式，会随着数据规模的增加，复杂度急剧增加；
             * 
             * 寻找近似最优解的方式：
             * 1.给孩子满足要求的最小饼干；
             * 2.通过这种方式满足了多少孩子，结果就是多少孩子了；
             */

            int gIndex = 0;
            int sIndex = 0;
            int returnCount = 0;

            var nG = g.OrderBy(i => i).ToList();
            var nS = s.OrderBy(i => i).ToList();

            while (gIndex < g.Length)
            {
                while(sIndex < s.Length)
                {
                    //说明这个孩子可以满足
                    if (nG[gIndex] <= nS[sIndex])
                    {
                        returnCount++;
                        sIndex++;
                        break;
                    }

                    //满足不了这个孩子，试着看看下一块儿饼干能否满足
                    sIndex++;
                }

                gIndex++;
            }

            return returnCount;
        }
    }
}
