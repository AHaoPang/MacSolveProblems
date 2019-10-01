using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem693 : IProblem
    {
        public void RunProblem()
        {
            var temp = HasAlternatingBits(5);
            if (temp != true) throw new Exception();

            temp = HasAlternatingBits(7);
            if (temp != false) throw new Exception();

            temp = HasAlternatingBits(11);
            if (temp != false) throw new Exception();

            temp = HasAlternatingBits(10);
            if (temp != true) throw new Exception();

            temp = HasAlternatingBits(4);
            if (temp != false) throw new Exception();
        }

        public bool HasAlternatingBits(int n)
        {
            /* 快速的构造了模具和掩码 */
            var result = (n >> 1) ^ n;
            return (result & (result + 1)) == 0;
        }

        public bool HasAlternatingBits1(int n)
        {
            /*
             * 验证给定数字的二进制位满足特定的格式，即0和1交替出现
             * 思路：
             *  1.给定的数字一定是正整数
             *  2.验证的边界一定是从第1个1开始的，一直到二进制位的结束
             *  3.可以考虑得到这个边界，然后构造出模具
             *  4.模具与原数做与运算，结果为0，说明满足要求
             *  
             * 时间复杂度：O(1)
             * 空间复杂度：O(1)
             */

            //确定二进制位的边界
            int posCount = 0;
            int nTemp = n;
            while (nTemp != 0)
            {
                posCount++;
                nTemp >>= 1;
            }

            //构造模具
            int verifyNum = 0;
            for (int i = posCount - 1; i > 0; i -= 2)
                verifyNum |= (1 << i - 1);

            //构造掩码
            int maskNum = 0;
            for (int i = 0; i < posCount; i++)
                maskNum |= (1 << i);

            //验证结果
            return (n ^ verifyNum) == maskNum;
        }
    }
}
