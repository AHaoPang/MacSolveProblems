using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem458 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int PoorPigs(int buckets, int minutesToDie, int minutesToTest)
        {
            /*
             * 使用数学知识做理论分析好了
             * 思路：
             *  1. 1只猪在1小时内，能提供5个结果，如果Total <= 5，那么1只猪就够了
             *  2. 2只猪呢，其实是 5*5  ，如果 Total <= 25 ，那么2只猪就够了
             *  3. 所以，这是一个基数的问题
             *  
             * 时间复杂度：O(logn)
             * 空间复杂度：O(1)
             */

            int resultPer = minutesToTest / minutesToDie + 1;

            int forReturn = 0;
            int resultCount = 1;
            while (resultCount < buckets)
            {
                forReturn++;
                resultCount *= resultPer;
            }

            return forReturn;
        }
    }
}
