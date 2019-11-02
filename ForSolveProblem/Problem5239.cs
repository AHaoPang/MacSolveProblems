using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForSolveProblem
{
    public class Problem5239 : IProblem
    {
        public void RunProblem()
        {
            var temp = CircularPermutation(2, 3);
            if (!ProblemHelper.ArrayIsEqual(temp.ToArray(), new int[] { 3, 2, 0, 1 })) throw new Exception();

            temp = CircularPermutation(3, 2);
            if (!ProblemHelper.ArrayIsEqual(temp.ToArray(), new int[] { 2, 6, 7, 5, 4, 0, 1, 3 })) throw new Exception();
        }

        public IList<int> CircularPermutation(int n, int start)
        {
            /*
             * 问题:按照要求给出一个数字的列表,相邻的数字只有一个二进制位不同
             * 思路:
             *  1.使用回溯的方法,只要有一个可行的解,就结束
             *  2.依据初始值来推演下一个数字
             *  3.依据题目中给出的n的取值范围可知,二进制的位数最多为16位
             *  4.那么每次推演,起始就是尝试修改初始值的一个位,得到的数字只要不在已经排好的列表里面就好了
             * 
             * 关键点:
             * 
             * 时间复杂度:
             * 空间复杂度:O(2^n)
             */

            //1.准备一个位数组,用来修改数字的单个位
            var bitNumArray = new int[16];
            bitNumArray[0] = 1;
            for (int i = 1; i < 16; i++)
                bitNumArray[i] = bitNumArray[i - 1] * 2;

            //2.表示不重复的数列
            var intValue = 1 << n;
            var forReturn = new HashSet<int>(intValue);
            forReturn.Add(start);
            Backtrace(n, 0, start, forReturn, bitNumArray);

            return forReturn.ToList();
        }

        private bool Backtrace(int n, int times, int curNum, ISet<int> nums, int[] bitNumArray)
        {
            if ((1 << n) - 1 == times)
                return true;

            for (int i = 0; i < bitNumArray.Length; i++)
            {
                //尝试修改一个位的值
                var tempValue = curNum ^ bitNumArray[i];
                if (nums.Contains(tempValue)) continue;

                nums.Add(tempValue);
                var resultTemp = Backtrace(n, times + 1, tempValue, nums, bitNumArray);
                if (resultTemp) return true;

                nums.Remove(tempValue);
            }

            return false;
        }
    }
}
