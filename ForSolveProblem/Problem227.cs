using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForSolveProblem
{
    public class Problem227 : IProblem
    {
        public void RunProblem()
        {
            var temp = Calculate("3+2*2");
            if (temp != 7) throw new Exception();

            temp = Calculate(" 3/2 ");
            if (temp != 1) throw new Exception();

            temp = Calculate(" 3+5 / 2 ");
            if (temp != 5) throw new Exception();

            temp = Calculate("2*3*4");
            if (temp != 24) throw new Exception();

            temp = Calculate("1-1+1");
            if (temp != 1) throw new Exception();

            temp = Calculate("0-2147483647");
            if (temp != -2147483647) throw new Exception();
        }

        public int Calculate(string s)
        {
            CalcManager calc = new CalcManager();
            foreach (var sItem in s)
            {
                if (sItem == ' ') continue;

                calc.GetInput(sItem);
            }

            return calc.GetResult();
        }

        /// <summary>
        /// 计算管理器
        /// </summary>
        class CalcManager
        {
            /// <summary>
            /// 存储数字的栈
            /// </summary>
            public Stack<int> NumStack;

            /// <summary>
            /// 存储符号的栈
            /// </summary>
            public Stack<char> OperaStack;

            /// <summary>
            /// 标明状态的属性
            /// </summary>
            public ICalcStatus InnerStatus;

            public CalcManager()
            {
                NumStack = new Stack<int>();
                OperaStack = new Stack<char>();
                InnerStatus = StartStatus.Instance;
            }

            /// <summary>
            /// 获取输入的字符,进而改变自身的状态
            /// </summary>
            public void GetInput(char c) => InnerStatus.CalcOpera(this, c);

            /// <summary>
            /// 返回计算结果
            /// </summary>
            public int GetResult()
            {
                if (OperaStack.Count > 0 && (OperaStack.Peek() == '*' || OperaStack.Peek() == '/'))
                {
                    var num2 = NumStack.Pop();
                    var num1 = NumStack.Pop();
                    var operaTemp = OperaStack.Pop();

                    var newNum = CalcOperaFun(num1, num2, operaTemp);
                    NumStack.Push(newNum);
                }

                if (OperaStack.Count > 0)
                {
                    var numArray = NumStack.ToArray();
                    var operaArray = OperaStack.ToArray();

                    var num1 = numArray.Last();
                    for (int i = operaArray.Length - 1; i >= 0; i--)
                    {
                        var num2 = numArray[i];
                        var operaTemp = operaArray[i];

                        num1 = CalcOperaFun(num1, num2, operaTemp);
                    }
                    return num1;
                }

                return NumStack.Pop();
            }

            /// <summary>
            /// 四则运算
            /// </summary>
            public int CalcOperaFun(int num1, int num2, char opera)
            {
                //return opera switch
                //{
                //    '+' => num1 + num2,
                //    '-' => num1 - num2,
                //    '*' => num1 * num2,
                //    '/' => num1 / num2,
                //    _ => 0,
                //};

                switch (opera)
                {
                    case '+':
                        return num1 + num2;
                    case '-':
                        return num1 - num2;
                    case '*':
                        return num1 * num2;
                    case '/':
                        return num1 / num2;
                    default:
                        return 0;
                }
            }
        }

        /// <summary>
        /// 计算状态接口
        /// </summary>
        interface ICalcStatus
        {
            /// <summary>
            /// 计算
            /// </summary>
            void CalcOpera(CalcManager manager, char curChar);
        }

        /// <summary>
        /// 起始状态
        /// </summary>
        class StartStatus : ICalcStatus
        {
            private StartStatus() { }

            public static StartStatus Instance = new StartStatus();

            public void CalcOpera(CalcManager manager, char curChar)
            {
                if (curChar == '+' || curChar == '-')
                {
                    manager.OperaStack.Push(curChar);
                    return;
                }

                if (curChar == '*' || curChar == '/')
                {
                    manager.OperaStack.Push(curChar);
                    manager.InnerStatus = new PreOperaStatus();
                    return;
                }

                manager.NumStack.Push(int.Parse(curChar.ToString()));
                manager.InnerStatus = PreNumStatus.Instance;
            }
        }

        /// <summary>
        /// 上一个符号是数字
        /// </summary>
        class PreNumStatus : ICalcStatus
        {
            private PreNumStatus() { }

            public static PreNumStatus Instance = new PreNumStatus();

            public void CalcOpera(CalcManager manager, char curChar)
            {
                if (curChar == '+' || curChar == '-')
                {
                    manager.OperaStack.Push(curChar);
                    manager.InnerStatus = StartStatus.Instance;
                    return;
                }

                if (curChar == '*' || curChar == '/')
                {
                    manager.OperaStack.Push(curChar);
                    manager.InnerStatus = new PreOperaStatus();
                    return;
                }

                var preNum = manager.NumStack.Pop();
                var newNum = preNum * 10 + int.Parse(curChar.ToString());
                manager.NumStack.Push(newNum);
            }
        }

        /// <summary>
        /// 上一个符号是运算符
        /// </summary>
        class PreOperaStatus : ICalcStatus
        {
            public PreOperaStatus() { }

            private bool m_preNum = false;

            public void CalcOpera(CalcManager manager, char curChar)
            {
                if (curChar == '+' || curChar == '-' || curChar == '*' || curChar == '/')
                {
                    var num2 = manager.NumStack.Pop();
                    var num1 = manager.NumStack.Pop();
                    var operaTemp = manager.OperaStack.Pop();

                    var newValue = manager.CalcOperaFun(num1, num2, operaTemp);
                    manager.NumStack.Push(newValue);

                    manager.OperaStack.Push(curChar);
                    if (curChar == '+' || curChar == '-')
                        manager.InnerStatus = StartStatus.Instance;
                    else
                        m_preNum = false;
                    return;
                }

                if (!m_preNum)
                {
                    manager.NumStack.Push(int.Parse(curChar.ToString()));
                    m_preNum = true;
                }
                else
                {
                    var preNum = manager.NumStack.Pop();
                    var newNum = preNum * 10 + int.Parse(curChar.ToString());
                    manager.NumStack.Push(newNum);
                }
            }
        }
    }
}
