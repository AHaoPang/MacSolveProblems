using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem461 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int HammingDistance(int x, int y)
        {
            /*
             * 统计两个数字二进制位，相同位置上位不同的个数
             * 思路：
             *  1.异或运算的结果本身，就是对不同位的记录
             *  2.所以只需要统计异或结果中1的个数，就可以了
             *  
             * 时间复杂度：O(1)，最多有31个不同的位置，对于复杂度而言，这就是常量了
             * 空间复杂度：O(1)
             */

            var result = x ^ y;

            int forReturn = 0;
            while(result != 0)
            {
                forReturn++;
                result = result & (result - 1);
            }
            return forReturn;
        }
    }
}
