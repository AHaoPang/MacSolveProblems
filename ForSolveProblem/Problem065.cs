using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem065 : IProblem
    {
        public void RunProblem()
        {
            var temp = IsNumber("0");
            if (temp == false) throw new Exception();

            temp = IsNumber(" 0.1 ");
            if (temp == false) throw new Exception();

            temp = IsNumber("abc");
            if (temp == true) throw new Exception();

            temp = IsNumber("1 a");
            if (temp == true) throw new Exception();

            temp = IsNumber("2e10");
            if (temp == false) throw new Exception();

            temp = IsNumber(" -90e3   ");
            if (temp == false) throw new Exception();

            temp = IsNumber(" 1e");
            if (temp == true) throw new Exception();

            temp = IsNumber("e3");
            if (temp == true) throw new Exception();

            temp = IsNumber(" 6e-1");
            if (temp == false) throw new Exception();

            temp = IsNumber(" 99e2.5 ");
            if (temp == true) throw new Exception();

            temp = IsNumber("53.5e93");
            if (temp == false) throw new Exception();

            temp = IsNumber(" --6 ");
            if (temp == true) throw new Exception();

            temp = IsNumber("-+3");
            if (temp == true) throw new Exception();

            temp = IsNumber("95a54e53");
            if (temp == true) throw new Exception();
        }

        public bool IsNumber(string s)
        {
            /*
             * 判断指定的字符串，是否是有效的数字
             * 思路：
             *  1.满足怎样的模式，才能算作是数字？ A[.[B]][e|EC]，这里是一个简单的匹配模式公式，覆盖了大部分情况
             *  2.数字是由3个部分组成的：整数部分、小数部分、指数部分
             *  3.整数部分，可以由 +/- 和 0~9 组成
             *  4.小数部分，可以由 0~9 组成
             *  5.指数部分，可以由 +/- 和 0~9 组成
             *  6.还要考虑一些特例的情况
             *  7.可以考虑使用“有限状态机”的方式来解决，思考可能的状态，并建立状态转换图
             *  
             * 时间复杂度：O(n)，字符串的一次遍历
             * 空间复杂度：O(1)，使用的额外空间是固定的，与输入的字符串长度无关
             * 
             * 考察点：
             *  1.有限状态机
             */

            string digital = "digital";
            string blank = "blank";
            string plusSub = "+-";
            string dot = ".";
            string eE = "eE";

            Dictionary<int, Dictionary<string, int>> stateDic = new Dictionary<int, Dictionary<string, int>>()
            {
                [1] = new Dictionary<string, int>() { { blank, 1 }, { digital, 2 }, { plusSub, 3 }, { dot, 4 } },
                [2] = new Dictionary<string, int>() { { digital, 2 }, { dot, 5 }, { blank, 9 }, { eE, 6 } },
                [3] = new Dictionary<string, int>() { { digital, 2 }, { dot, 4 } },
                [4] = new Dictionary<string, int>() { { digital, 5 } },
                [5] = new Dictionary<string, int>() { { digital, 5 }, { eE, 6 }, { blank, 9 } },
                [6] = new Dictionary<string, int>() { { digital, 8 }, { plusSub, 7 } },
                [7] = new Dictionary<string, int>() { { digital, 8 } },
                [8] = new Dictionary<string, int>() { { digital, 8 }, { blank, 9 } },
                [9] = new Dictionary<string, int>() { { blank, 9 } }
            };

            int initState = 1;
            foreach (var sItem in s)
            {
                string curStateString = "";
                switch (sItem)
                {
                    case '+':
                    case '-':
                        curStateString = plusSub;
                        break;

                    case '.':
                        curStateString = dot;
                        break;

                    case ' ':
                        curStateString = blank;
                        break;

                    case 'e':
                    case 'E':
                        curStateString = eE;
                        break;

                    default:
                        if (sItem >= '0' && sItem <= '9')
                            curStateString = digital;

                        break;
                }

                if (!stateDic[initState].ContainsKey(curStateString)) return false;

                initState = stateDic[initState][curStateString];
            }

            int[] successStates = new int[] { 2, 5, 8, 9 };
            return successStates.Contains(initState);
        }
    }
}
