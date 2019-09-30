using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem400 : IProblem
    {
        public void RunProblem()
        {
            var temp = FindNthDigit(11);
            if (temp != 0) throw new Exception();

            temp = FindNthDigit(44);
            if (temp != 2) throw new Exception();

            temp = FindNthDigit(2147483647);
            if(temp != 2) throw new Exception();
        }

        public int FindNthDigit(int n)
        {
            /*
             * 找到整数序列中的第N个数字（肯定是0~9中的一个数字）
             * 思路：
             *  1.查看数列的规律，个位数：9个 十位数 90*2个 百位数 900*3个...
             *  2.依据个数，大体判断是多少位数
             *  3.整除位数，看看是第几个
             *  4.取余，判断到底是哪一个位，即可
             *  
             * 时间复杂度：O(1)
             * 空间复杂度：O(1)
             */

            if (n <= 9) return n;

            //确定在哪个区间范围
            int remainN = n;
            int rangeCount = 9;
            int posCount = 1;
            while (remainN - rangeCount * posCount > 0)
            {
                remainN -= rangeCount * posCount;

                rangeCount *= 10;
                posCount++;

                if (posCount == 10) break;
            }

            //判断是哪一个数
            int baseNum = 1;
            for (int i = 1; i < posCount; i++)
                baseNum *= 10;

            int numT = (int)(remainN / posCount);

            //查看取余的值是多少
            if (remainN % posCount == 0)
            {
                int nT = baseNum + numT - 1;

                var lengthTemp = nT.ToString().Length;
                return int.Parse(nT.ToString()[lengthTemp - 1].ToString());
            }
            else
            {
                int nT = baseNum + numT;

                return int.Parse(nT.ToString()[(int)(remainN % posCount) - 1].ToString());
            }

        }
    }
}
