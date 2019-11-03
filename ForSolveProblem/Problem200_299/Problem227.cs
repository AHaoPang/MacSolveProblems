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

            temp = Calculate("100000000/1/2/3/4/5/6/7/8/9/10");
        }

        public int Calculate(string s)
        {
            /*
            * 问题: 基本运算实现
            * 思路:
            *  1.依次解析字符串中的每个字符
            *  2.将解析出来的数字放入数字栈
            *  3.将解析出来的运算符放入符号栈
            *  4.情景讨论
            *       4.1 当解析出来的是符号
            *           4.1.1 若符号栈里面有一个符号了,而且当前解析出来的是"+"和"-",那么优先吧数字栈里面的数字和符号栈里面的符号运算了,结果放入数字栈
            *       4.2 当解析出来的是数字,直接压栈
            *           4.2.1 若符号栈里面有一个符号了,且为"*"和"/",那么 运算 ,结果放入数字栈
            *           4.2.2 若符号栈里面有两个符号了,那么第二个符号一定是"*"和"/",那么运算,结果放入数字栈
            *       4.3 当每个字符都解析完了,查看符号栈是否有符号,有的话,计算
            *  5.最后数字栈中存储的就是结果了
            * 
            * 关键点:
            * 
            * 时间复杂度:O(n)
            * 空间复杂度:O(1)
            */

            var opeSets = new HashSet<char>() { '+', '-', '*', '/' };

            var numStack = new Stack<int>();
            var opeStack = new Stack<char>();
            for (int i = 0; i < s.Length;)
            {
                var sItem = s[i];

                if (opeSets.Contains(sItem))
                {
                    //已确认是符号
                    if (opeStack.Count == 1)
                        if (sItem == '+' || sItem == '-')
                            InnerOpera(numStack, opeStack);

                    opeStack.Push(sItem);
                    i++;
                }
                else
                {
                    //已确认非符号
                    var curStr = "";
                    while (i < s.Length && !opeSets.Contains(s[i]))
                    {
                        if (s[i] != ' ') curStr += s[i];

                        i++;
                    }

                    numStack.Push(int.Parse(curStr));

                    if (numStack.Count == 3)
                        InnerOpera(numStack, opeStack);
                    else if (numStack.Count == 2)
                        if (opeStack.Peek() == '*' || opeStack.Peek() == '/')
                            InnerOpera(numStack, opeStack);
                }
            }

            if (opeStack.Count == 1)
                InnerOpera(numStack, opeStack);

            return numStack.Pop();
        }

        /// <summary>
        /// 触发一次计算
        /// </summary>
        private void InnerOpera(Stack<int> numStack, Stack<char> opeStack)
        {
            var num2 = numStack.Pop();
            var num1 = numStack.Pop();
            var opeTemp = opeStack.Pop();
            var newNum = CalcOperaFunNew(num1, num2, opeTemp);

            numStack.Push(newNum);
        }

        /// <summary>
        /// 四则运算
        /// </summary>
        private int CalcOperaFunNew(int num1, int num2, char opera)
        {
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

        public int Calculate1(string s)
        {
            /*
             * 问题:基本计算器
             * 思路:
             *  1.挨个儿遍历输入的字符
             *  2.对于状态对象而言,他要处理的就是一个字符
             *  3.不同的状态对象,对传入字符的处理方式是不同的
             *  4.依据情景分析,会存在3种状态
             *      4.1 起始状态,即前面的字符不影响后面的状态操作
             *      4.2 数字状态,即前面的字符是数字
             *      4.3 符号状态,即前面的字符是"*"和"/"
             *  5.这3种状态的转变过程是:
             *      5.1 起始状态
             *          5.1.1 遇到符号"+"和"-",入符号栈,状态无需改变
             *          5.1.2 遇到符号"*"和"/",入符号栈,状态变为"符号状态"
             *          5.1.3 遇到数字,入数字栈,状态变为"数字状态"
             *      5.2 数字状态
             *          5.2.1 遇到符号"+"和"-",入符号栈,状态变为"起始状态"
             *          5.2.2 遇到符号"*"和"/",入符号栈,状态变为"符号状态"
             *          5.2.3 遇到数字,入数字栈,状态无需改变
             *      5.3 符号状态
             *          5.3.1 遇到符号,先做计算,若符号为"+"和"-",则变更为"起始状态"
             *          5.3.2 遇到数字,入数字栈,状态无需改变
             *  6.具体还涉及到一点儿细节,就不一一列举说明了
             * 
             * 关键点:
             * 
             * 时间复杂度:O(n)
             * 空间复杂度:O(1)
             */

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
