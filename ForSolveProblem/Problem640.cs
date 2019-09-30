using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem640 : IProblem
    {
        public void RunProblem()
        {
            var temp = SolveEquation("x+5-3+x=6+x-2");
            if (temp != "x=2") throw new Exception();

            temp = SolveEquation("x=x");
            if (temp != "Infinite solutions") throw new Exception();

            temp = SolveEquation("2x=x");
            if (temp != "x=0") throw new Exception();

            temp = SolveEquation("2x+3x-6x=x+2");
            if (temp != "x=-1") throw new Exception();

            temp = SolveEquation("x=x+2");
            if (temp != "No solution") throw new Exception();
        }

        public string SolveEquation(string equation)
        {
            /*
             * 方程求解
             * 思路：
             *  1. 依然是对字符串的解析过程了
             *  2. 我们的解析和计算目标是将 x及其系数放在等号的一边 将常数放在等号的另一边
             *  3. 依据“=”,将字符串分为 等号左边 和 等号右边
             *  4. 解析字符串，得到带x的字符串 和 不带x的字符串，分别累计求和
             *  5. 对等号左右两边的做抵消操作
             *  6. 最后的等式，形如： ax = b；开始分别讨论
             *      6.1 b == 0 && a == 0 无限解
             *      6.2 a == 0 无解
             *      6.3 x == b / a
             */

            //按照等号来分隔
            var leftRightStrArray = equation.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);

            //左右串单独处理
            Tuple<int, int>[] leftRightCollection = new Tuple<int, int>[2];
            var calcIndex = 0;
            foreach (var leftRightItem in leftRightStrArray)
            {
                var newStr = new StringBuilder(leftRightItem.Length);
                foreach (var leftItem in leftRightItem)
                {
                    if (leftItem == '-') newStr.Append('+');
                    newStr.Append(leftItem);
                }

                var newStrForCalc = newStr.ToString();
                var numsArray = newStrForCalc.Split(new char[] { '+' }, StringSplitOptions.RemoveEmptyEntries);

                int x_num = 0;
                int num_Temp = 0;
                foreach (var numItem in numsArray)
                {
                    if (numItem.Last() == 'x')
                    {
                        var newStrTemp = numItem.TrimEnd('x');

                        if (string.IsNullOrWhiteSpace(newStrTemp)) x_num++;
                        else if (newStrTemp == "-") x_num--;
                        else x_num += int.Parse(numItem.TrimEnd('x'));
                    }
                    else
                        num_Temp += int.Parse(numItem);
                }

                leftRightCollection[calcIndex++] = Tuple.Create(x_num, num_Temp);
            }

            var x_num_Temp = leftRightCollection[0].Item1 - leftRightCollection[1].Item1;
            var num_temp_Temp = leftRightCollection[1].Item2 - leftRightCollection[0].Item2;

            if (num_temp_Temp == 0 && x_num_Temp == 0) return "Infinite solutions";
            else if (x_num_Temp == 0) return "No solution";
            else return $"x={num_temp_Temp / x_num_Temp}";
        }
    }
}
