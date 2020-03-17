using System;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem1071 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public string GcdOfStrings(string str1, string str2)
        {
            /*
             * 题目概述：字符串最大公因子
             * 
             * 思路：
             *  1.不得不说,把两个字符串正反拼接然后判断的方法很漂亮,这是个拥有最大公因子的充要条件
             *  2.当满足上面那个充要条件以后,直接求得最大公约数,然后把字字符串提供出来就是要求得的结果
             *  3.这题真的是很 track 了
             *
             * 关键点：公约数 字符串
             *
             * 时间复杂度：O(n)
             * 空间复杂度：O(1)
             */

            if (str1 + str2 != str2 + str1) return "";

            return str1.Substring(0, Gcd(str1.Length, str2.Length));
        }

        private int Gcd(int i1, int i2) => i2 == 0 ? i1 : Gcd(i2, i1 % i2);

        public string GcdOfStrings3(string str1, string str2)
        {
            /*
             * 题目概述：字符串最大公因子
             * 
             * 思路：
             *  1.因子可以有很多,但要的是 最大公因子 -> 在这个地方栽跟头了
             *  2.使用统一的整数长度去比较,得到最大公因子 --> 起初各自求得公因子,然后做比较,这导致问题变的复杂,还不如一开始就直接做比较了
             *  3.找到公共的子长度,然后分别去判断是否是公因子,不行的话就减小长度再去判断,首次满足条件的就是结果了
             *
             * 关键点：字符串
             *
             * 时间复杂度：O(n)
             * 空间复杂度：O(n)
             */

            var minLength = Math.Min(str1.Length, str2.Length);
            for (var curLength = minLength; curLength >= 1; curLength--)
            {
                if (str1.Length % curLength != 0 || str2.Length % curLength != 0) continue;

                var str1Temp = str1.Substring(0, curLength);
                var str2Temp = str2.Substring(0, curLength);

                if (str1Temp != str2Temp) continue;

                if (IsOK(str1Temp, str1) && IsOK(str2Temp, str2))
                    return str1Temp;
            }

            return "";
        }

        private bool IsOK(string subStr, string str)
        {
            var newList = new List<string>();
            for (var i = 0; i < str.Length; i += subStr.Length)
                newList.Add(str.Substring(i, subStr.Length));

            return newList.All(i => i == subStr);
        }

        public string GcdOfStrings2(string str1, string str2)
        {
            var str1Range = GetStrRange(str1);
            var str2Range = GetStrRange(str2);

            return "";
        }

        private string GetStrRange(string str)
        {
            var initLength = str.Length / 2;
            while (initLength > 0)
            {
                if (str.Length % initLength == 0)
                {
                    var innerStrList = new List<string>();

                    for (var i = 0; i < str.Length; i += initLength)
                        innerStrList.Add(str.Substring(i, initLength));

                    var strTemp = innerStrList.First();
                    if (innerStrList.All(strItem => strItem == strTemp))
                        return strTemp;
                }

                initLength--;
            }

            return str;
        }

        private bool IsGcd(string str1, string str2)
        {
            var shortStr = str1.Length >= str2.Length ? str2 : str1;
            var longStr = str1.Length >= str2.Length ? str1 : str2;

            if (longStr.Length % shortStr.Length != 0) return false;

            var strList = new List<string>();
            for (var i = 0; i < longStr.Length; i += shortStr.Length)
                strList.Add(longStr.Substring(i, shortStr.Length));

            return strList.All(i => i == shortStr);
        }

        public string GcdOfStrings1(string str1, string str2)
        {
            /*
             * 题目概述：字符串的最大公因子
             * 
             * 思路：
             *  1.公因子可以认为是字符串的基本组成部分
             *  2.我们要找的是最小组成部分
             *  3.若两个字符串的最小组成部分相同,那么就返回结果,否则返回空字符串
             *  4.构成字符串的片段,要么是字符串的一半,要么就是字符串本身了
             *
             * 知识点：取余 数组
             *
             * 时间复杂度： O(n^2)
             * 空间复杂度： O(n)
             */

            var str1Gcd = GetStrGcd(str1);
            var str2Gcd = GetStrGcd(str2);

            return str1Gcd == str2Gcd ? str1Gcd : "";
        }

        private string GetStrGcd(string str)
        {
            var gcdStrList = new List<char>();
            for (var i = 0; i < str.Length / 2; i++)
            {
                gcdStrList.Add(str[i]);

                var j = i + 1;
                for (; j < str.Length; j++)
                {
                    var newPos = j % (i + 1);
                    if (gcdStrList[newPos] != str[j])
                        break;
                }

                if (j == str.Length && j % (i + 1) == 0) return new string(gcdStrList.ToArray());
            }

            return str;
        }
    }
}
