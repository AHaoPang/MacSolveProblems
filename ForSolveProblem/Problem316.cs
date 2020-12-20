using System;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem316 : IProblem
    {
        public Problem316()
        {
            var temp = RemoveDuplicateLetters("bcabc");
            if (temp != "abc")
                throw new Exception();

            temp = RemoveDuplicateLetters("cbacdcbc");
            if (temp != "acdb")
                throw new Exception();
        }

        public void RunProblem()
        {
            throw new NotImplementedException();
        }


        public string RemoveDuplicateLetters(string s)
        {
            /*
             * ##### 1. 题目概述：
             *  1.1 给定一个字符串
             *  1.2 删掉字符串中的重复字母
             *  1.3 剩下字符的字典序最小
             *  1.4 字符串的长度是 10^4 级别，所以最好使用的是 O(n) 或者 O(logn) 之类的算法
             * 
             * ##### 2. 思路：
             *    - 特征：
             *      1. 越是排在前面的字符的字典序小，越是可以保证整个字典序小，高位权重大
             *    - 方案：
             *      1. 类似贪心的方式；字典序小的字符，应该尽量的靠前才对；
             *      2. 分段升序；
             *      
             *      3. 处理到了一个字符
             *          3.1 已经在序列中了，那么就丢弃
             *          3.2 序列中没有，那么就入栈
             *          3.3 入栈前要检查一下栈中现有的元素
             *          3.4 看栈中的上一个字符，比它的字典序大，且上一个字符在以后还会出现，那么就丢弃上一个元素，否则直接入栈
             *    - 结果：
             *
             * ##### 3. 知识点：栈，字符串
             * 
             * ##### 4. 复杂度分析: 
             *    - 时间复杂度： O(n)
             *    - 空间复杂度：O(n)
             */

            //1.确定各个字符最后一次出现的位置
            var charLastPosArr = new int[26];
            for (var i = 0; i < s.Length; i++)
                charLastPosArr[s[i] - 'a'] = i;

            //2.明确各个字符是否出现过
            var charHasAdded = new bool[26];
            var resStack = new Stack<char>();
            for (var i = 0; i < s.Length; i++)
            {
                //栈中已经出现过了，跳过; -> 单调递增的序列，删掉前面的字符，会让整个字符串的字典序变大
                if (charHasAdded[s[i] - 'a']) continue;

                while (resStack.Any() && resStack.Peek() > s[i] && charLastPosArr[resStack.Peek() - 'a'] > i)
                    charHasAdded[resStack.Pop() - 'a'] = false;

                resStack.Push(s[i]);
                charHasAdded[s[i] - 'a'] = true;
            }

            //4.结果输出
            return new string(resStack.Reverse().ToArray());
        }
    }
}
