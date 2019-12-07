using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForSolveProblem
{
    public class Problem1209 : IProblem
    {
        public void RunProblem()
        {
            var temp = RemoveDuplicates("abcd", 2);
            if (temp != "abcd") throw new Exception();

            temp = RemoveDuplicates("deeedbbcccbdaa", 3);
            if (temp != "aa") throw new Exception();

            temp = RemoveDuplicates("pbbcggttciiippooaais", 2);
            if (temp != "ps") throw new Exception();
        }

        public string RemoveDuplicates(string s, int k)
        {
            /*
             * 题目概述：有点儿像消消乐
             * 
             * 思路：
             *  1.顺序检测字符串,当发现相同的字符时,需要做统计
             *  2.当统计值达到阈值的时候,就要做消除操作
             *  3.当消除完成以后,我们还要拿历史的字符与最新的字符做比较
             *  4.因此很容易就可以看出这是一个栈的应用场景
             *  5.栈中的元素需要维护两个信息:字符是什么,字符的个数是多少
             *
             * 关键点：
             *
             * 时间复杂度： O(n)
             * 空间复杂度： O(n)
             */

            var stackTemp = new Stack<StackEntity>(s.Length);
            foreach (var sItem in s)
            {
                if (!stackTemp.Any())
                {
                    stackTemp.Push(new StackEntity(sItem, 1));
                    continue;
                }

                var curHead = stackTemp.Peek();
                if (curHead.CurChar != sItem)
                {
                    stackTemp.Push(new StackEntity(sItem, 1));
                    continue;
                }

                curHead.CurCount++;
                if (curHead.CurCount == k) stackTemp.Pop();
            }

            var forReturn = new StringBuilder();
            while (stackTemp.Any())
            {
                var stackItem = stackTemp.Pop();
                var strTemp = new string(Enumerable.Repeat(stackItem.CurChar, stackItem.CurCount).ToArray());
                forReturn.Append(strTemp);
            }

            return new string(forReturn.ToString().Reverse().ToArray());
        }

        class StackEntity
        {
            public StackEntity(char curChar, int curCount)
            {
                CurChar = curChar;
                CurCount = curCount;
            }

            public char CurChar { get; set; }

            public int CurCount { get; set; }
        }
    }
}
