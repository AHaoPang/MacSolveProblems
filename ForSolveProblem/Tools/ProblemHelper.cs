using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    /// <summary>
    /// 解题辅助类的工具
    /// </summary>
    public static class ProblemHelper
    {
        /// <summary>
        /// 判断两个数组是相等的（内部的值一致）
        /// </summary>
        public static bool ArrayIsEqual<T>(T[] arr1, T[] arr2, bool needOrder = true)
        {
            if (arr1.Length != arr2.Length) return false;

            var arr1Temp = needOrder ? arr1.OrderBy(i => i).ToArray() : arr1;
            var arr2Temp = needOrder ? arr2.OrderBy(i => i).ToArray() : arr2;

            for (int i = 0; i < arr1Temp.Length; i++)
                if (!arr1Temp[i].Equals(arr2Temp[i])) return false;

            return true;
        }

        /// <summary>
        /// 为字符串构造 next 数组
        /// 此数组是配合 KMP 算法来使用的,数组的索引和值,都表示字符串中对应字符的数组下标
        /// 使用了 DP 的算法原理,即后面的值是基于前面的值计算得到的
        /// </summary>
        private static int[] GetKMPNextArray(string s)
        {
            var forReturn = Enumerable.Repeat(-1, s.Length).ToArray();
            for (var i = 1; i < s.Length; i++)
            {
                var j = forReturn[i - 1];
                while (j >= 0 && s[j + 1] != s[i])
                    j = forReturn[j];

                if (s[j + 1] == s[i])
                    forReturn[i] = j + 1;
            }

            return forReturn;
        }
    }
}
