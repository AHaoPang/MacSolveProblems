using System;
using System.Collections.Generic;
using System.Text;

namespace ForSolveProblem
{
    public class Problem165 : IProblem
    {
        public void RunProblem()
        {
            var temp = CompareVersion("1.0.1", "1");
            if (temp != 1) throw new Exception();

            temp = CompareVersion("7.5.2.4", "7.5.3");
            if (temp != -1) throw new Exception();

            temp = CompareVersion("1.01", "1.001");
            if (temp != 0) throw new Exception();

            temp = CompareVersion("0.1", "1.1");
            if (temp != -1) throw new Exception();

            temp = CompareVersion("1.0", "1.0,0");
            if (temp != 0) throw new Exception();
        }

        public int CompareVersion(string version1, string version2)
        {
            /*
            * 问题:比较两个版本号的大小
            * 思路:
            *  1.依据"."来分割字符串,将字符串转换为数字来比较
            *  2.问题可转换为比较数值数组
            * 
            * 关键点:
            * 
            * 时间复杂度:O(n)
            * 空间复杂度:O(n)
            */

            var arr1 = version1.Split('.', StringSplitOptions.RemoveEmptyEntries);
            var arr2 = version2.Split('.', StringSplitOptions.RemoveEmptyEntries);

            var arr1Index = 0;
            var arr2Index = 0;
            while (arr1Index < arr1.Length || arr2Index < arr2.Length)
            {
                var arr1Value = 0;
                if (arr1Index < arr1.Length)
                {
                    int.TryParse(arr1[arr1Index], out arr1Value);
                    arr1Index++;
                }

                var arr2Value = 0;
                if (arr2Index < arr2.Length)
                {
                    int.TryParse(arr2[arr2Index], out arr2Value);
                    arr2Index++;
                }

                if (arr1Value > arr2Value) return 1;
                if (arr1Value < arr2Value) return -1;
            }

            return 0;
        }
    }
}
