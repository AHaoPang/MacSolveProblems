using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem029 : IProblem
    {
        public void RunProblem()
        {
            var temp = Divide(10, 3);
            if (temp != 3) throw new Exception();

            var temp1 = Divide(-10, 3);
            if (temp1 != -3) throw new Exception();

            var temp2 = Divide(7, -3);
            if (temp2 != -2) throw new Exception();

            var temp3 = Divide(int.MinValue, -1);
            if (temp3 != int.MaxValue) throw new Exception();

            var temp4 = Divide(1, 1);
            if (temp4 != 1) throw new Exception();

            var temp5 = Divide(1038925803, -2147483648);
            if (temp5 != 0) throw new Exception();

            var temp6 = Divide(-1, 1);
            if (temp6 != -1) throw new Exception();
        }

        public int Divide(int dividend, int divisor)
        {
            /*
             * 两数相除，求商的思路：
             * 1.除数和被除数，满足一个计算公式：dividend = divisor*2^n + divisor*2^n-1 + ... + divisor*2^1 + divisor*2^0
             * 2.基于公式，发现这就是一个重复的过程，所以可以利用到递归的方式
             * 
             * 时间复杂度：从公式上看，就是O(m*logn),因为从逻辑上看，m的值很小，最大不超过32，因此复杂度是O(logn)
             * 空间复杂度：O(1)
             * 
             * 实现思路：
             * 鉴于正负号的关系，需要明确divisor的自增方向，即是要负增长，还是正增长
             * 
             * 考察点：
             * 1.递归运算
             * 2.位运算
             * 3.另一种意义上的二分？
             */

            //特殊判定条件1
            if (divisor == int.MinValue && dividend != int.MinValue) return 0;

            //同号得正，异号得负
            bool isPositive = false;
            if (dividend > 0 && divisor > 0)
                isPositive = true;
            else if (dividend < 0 && divisor < 0)
                isPositive = true;

            //负数时，要让除数和被除数的符号一致
            if (!isPositive) divisor = -divisor;

            int count = Recursive(dividend, divisor, dividend > 0);

            //特殊判定条件2
            if (isPositive && count == int.MinValue) count = int.MaxValue;

            return isPositive ? count : -count;
        }

        private int Recursive(int dividend, int divisor, bool dividendisPositive)
        {
            if (dividend == divisor) return 1;

            if (dividendisPositive)
            {
                /*正增长*/

                if (dividend < divisor) return 0;

                int floorCount = 0;
                int totalValue = divisor << floorCount;

                while (totalValue < dividend - totalValue)
                {
                    floorCount++;
                    totalValue = divisor << floorCount;
                }

                return (1 << floorCount) + Recursive(dividend - totalValue, divisor, dividendisPositive);
            }
            else
            {
                /*负增长*/

                if (dividend > divisor) return 0;

                int floorCount = 0;
                int totalValue = divisor << floorCount;

                while (totalValue > dividend - totalValue)
                {
                    floorCount++;
                    totalValue = divisor << floorCount;
                }

                return (1 << floorCount) + Recursive(dividend - totalValue, divisor, dividendisPositive);
            }
        }

        public int Divide1(int dividend, int divisor)
        {
            /*
             * 两数相除，在不借助工具库的前提下，求解商
             * 思路：
             * 1.商，本身就是“倍数”，那么除数的倍数首次大于被除数的时候，自增次数就是所需的值了
             * 
             * 时间复杂度：O(m/n)，当m是32位整型数字的极限，n为1时，计算复杂度就会异常的高
             * 空间复杂度：O(1)
             */

            //同号得正，异号得负
            bool isPositive = false;
            if (dividend > 0 && divisor > 0)
                isPositive = true;
            else if (dividend < 0 && divisor < 0)
                isPositive = true;

            if (!isPositive)
                divisor *= -1;

            int count = 0;
            int perValue = divisor;
            while ((dividend > 0 && dividend >= divisor) || (dividend < 0 && dividend <= divisor))
            {
                count++;
                divisor += perValue;
            }

            return isPositive ? count : count * -1;
        }
    }
}
