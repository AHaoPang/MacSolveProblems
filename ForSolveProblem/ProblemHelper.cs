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
            if (arr1.Length != arr1.Length) return false;

            var arr1Temp = needOrder ? arr1.OrderBy(i => i).ToArray() : arr1;
            var arr2Temp = needOrder ? arr2.OrderBy(i => i).ToArray() : arr2;

            for (int i = 0; i < arr1Temp.Length; i++)
                if (!arr1Temp[i].Equals(arr2Temp[i])) return false;

            return true;
        }
    }
}
