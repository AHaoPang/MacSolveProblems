using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem166 : IProblem
    {
        public void RunProblem()
        {
            var temp = FractionToDecimal(1, 2);
            if (temp != "0.5") throw new Exception();

            temp = FractionToDecimal(2, 1);
            if (temp != "2") throw new Exception();

            temp = FractionToDecimal(2, 3);
            if (temp != "0.(6)") throw new Exception();

            temp = FractionToDecimal(4, 333);
            if (temp != "0.(012)") throw new Exception();

            temp = FractionToDecimal(1, 6);
            if (temp != "0.1(6)") throw new Exception();

            temp = FractionToDecimal(0, 3);
            if (temp != "0") throw new Exception();
        }

        public string FractionToDecimal(int numerator, int denominator)
        {
            /*
             * 计算整数除法的小数结果，对于无限循环的部分，要加上特殊的标识
             * 思路：
             *  1.为了避免溢出，应该在更大的空间里面做计算，比如说long
             *  2.符号位一定要判断清楚，判断是否是负数
             *  3.对余数要判断清楚
             *      3.1 若余数为0，说明可以除尽
             *      3.2 若余数出现重复，说明开始进入无限循环的过程了
             *      
             * 时间复杂度：O(1)
             * 空间复杂度：O(1)
             */

            if (numerator == 0) return "0";

            List<char> forReturnCharArray = new List<char>();
            if ((numerator >= 0) == !(denominator >= 0)) forReturnCharArray.Add('-');

            long numeratorLong = Math.Abs((long)numerator);
            long denominatorLong = Math.Abs((long)denominator);

            if (numeratorLong > denominatorLong)
            {
                forReturnCharArray.AddRange((numeratorLong / denominatorLong).ToString());

                if (numeratorLong % denominatorLong == 0) return new string(forReturnCharArray.ToArray());
                else numeratorLong = (numeratorLong % denominatorLong) * 10;
            }
            else
            {
                forReturnCharArray.Add('0');
                numeratorLong *= 10;
            }

            forReturnCharArray.Add('.');

            Dictionary<long, int> resultPosDic = new Dictionary<long, int>();
            long resultTemp = numeratorLong;
            do
            {
                long remainTemp = resultTemp;

                if (resultPosDic.ContainsKey(remainTemp))
                {
                    forReturnCharArray.Insert(resultPosDic[resultTemp], '(');
                    forReturnCharArray.Add(')');
                    break;
                }

                if (denominatorLong > resultTemp)
                {
                    forReturnCharArray.Add('0');
                    resultTemp *= 10;
                }
                else
                {
                    forReturnCharArray.AddRange((resultTemp / denominatorLong).ToString());
                    resultTemp = (resultTemp % denominatorLong) * 10;
                }

                resultPosDic[remainTemp] = forReturnCharArray.Count - 1;
            }
            while (resultTemp != 0);

            return new string(forReturnCharArray.ToArray());
        }
    }
}
