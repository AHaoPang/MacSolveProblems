using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem592 : IProblem
    {
        public void RunProblem()
        {
            var temp = FractionAddition("-1/2+1/2");
            if (temp != "0/1") throw new Exception();

            temp = FractionAddition("-1/2+1/2+1/3");
            if (temp != "1/3") throw new Exception();

            temp = FractionAddition("1/3-1/2");
            if (temp != "-1/6") throw new Exception();

            temp = FractionAddition("5/3+1/3");
            if (temp != "2/1") throw new Exception();
        }

        public string FractionAddition(string expression)
        {
            /*
             * 计算分数表达式
             * 思路：
             *  1.涉及字符串解析，最大公约数，最小公倍数等
             *  2.按照“+”拆分，得到的是各个参与运算的分数
             *  3.按照“/”拆分，得到的是“分子和分母”
             *  4.完成拆分，会得到一个二维数组，然后就该做二维数组的加法运算了
             *  5.分母部分，要得到“最小公倍数”
             *  6.结果部分，要用“最大公约数”去除
             *  
             * 时间复杂度：O(n)
             * 空间复杂度：O(n)
             */

            expression = GetNewStr(expression);

            //解析得到分数
            var fractionArray = expression.Split(new char[] { '+' }, StringSplitOptions.RemoveEmptyEntries);

            //解析得到二维数组
            var fractions = new int[fractionArray.Length, 2];
            for (int i = 0; i < fractionArray.Length; i++)
            {
                var nums = fractionArray[i].Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

                fractions[i, 0] = int.Parse(nums[0]);
                fractions[i, 1] = int.Parse(nums[1]);
            }

            //二维数组的计算
            int[,] curValue = new int[,] { { fractions[0, 0], fractions[0, 1] } };
            for (int j = 1; j < fractions.GetLength(0); j++)
            {
                //得到两个分母
                var down1Num = curValue[0, 1];
                var down2Num = fractions[j, 1];

                //得到公倍数
                var dup = GetMinDup(down1Num, down2Num);

                //得到乘数因子
                var d1 = dup / down1Num;
                var d2 = dup / down2Num;

                //分子相加得到结果
                var r = curValue[0, 0] * d1 + fractions[j, 0] * d2;

                //尝试约分
                var maxDup = GetMaxNums(r, dup);

                //开始进入下一轮
                curValue[0, 0] = r / maxDup;
                curValue[0, 1] = dup / maxDup;
            }

            return $"{GetNumStr(curValue[0, 0])}/{GetNumStr(curValue[0, 1])}";
        }

        /// <summary>
        /// 检测字符串中的“-”,如有必要，在前面添加“+”，为了后面的合理识别
        /// </summary>
        private string GetNewStr(string inputStr)
        {
            var forReturn = new StringBuilder(inputStr.Length);

            for (int i = 0; i < inputStr.Length; i++)
            {
                if (i > 0 && inputStr[i] == '-' && inputStr[i - 1] >= '0' && inputStr[i - 1] <= '9') forReturn.Append('+');

                forReturn.Append(inputStr[i]);
            }

            return forReturn.ToString();
        }

        /// <summary>
        /// 将分数转换为字符串
        /// </summary>
        private string GetNumStr(int n) => n >= 0 ? n.ToString() : $"-{Math.Abs(n).ToString()}";

        /// <summary>
        /// 得到最大公约数
        /// </summary>
        private int GetMaxNums(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);

            var maxNum = a >= b ? a : b;
            var minNum = a >= b ? b : a;

            while (maxNum > minNum && minNum != 0)
            {
                var temp = maxNum - minNum;

                maxNum = temp >= minNum ? temp : minNum;
                minNum = temp >= minNum ? minNum : temp;
            }

            return maxNum;
        }

        /// <summary>
        /// 得到最小公倍数
        /// </summary>
        private int GetMinDup(int a, int b) => a * b / GetMaxNums(a, b);
    }
}
