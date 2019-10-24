using System;
using System.Collections.Generic;
using System.Text;

namespace ForSolveProblem
{
    public class Problem777 : IProblem
    {
        public void RunProblem()
        {
            var temp = CanTransform("RXXLRXRXL", "XRLXXRRLX");
            if (temp != true) throw new Exception();

            temp = CanTransform("X", "L");
            if (temp != false) throw new Exception();

            temp = CanTransform("XXRXXLXXXX", "XXXXRXXLXX");
            if (temp != false) throw new Exception();
        }

        public bool CanTransform(string start, string end)
        {
            /*
            * 问题:判断 start 是否可以变换为 end
            * 思路:
            *  1. 题目和例子貌似不一致,从结果来看,从start到end,只能将"XL"变换为"LX",将"RX"变换为"XR"
            *  2. 因此在start种L只能左移,R只能右移,而且L和R不能彼此穿过
            *  3. 基于对题目的分析,使用两个指针依次指向两个字符串,判断指向的字符
            *       3.1 若字符相等,且满足下面的条件时,才可进入下一轮的判断
            *           3.1.1 当指向L时, startIndex >= endIndex 
            *           3.1.2 当指向R时, startIndex <= endIndex 
            *       3.2 一直判断到两个指针都指向了字符串的末尾处,才说明可以转换
            * 
            * 关键点:
            * 
            * 时间复杂度:O(n)
            * 空间复杂度:O(1)
            */

            var startIndex = 0;
            var endIndex = 0;

            while (startIndex < start.Length || endIndex < end.Length)
            {
                while (startIndex < start.Length && start[startIndex] == 'X') startIndex++;
                while (endIndex < end.Length && end[endIndex] == 'X') endIndex++;

                if (startIndex < start.Length && endIndex < end.Length)
                {
                    if (start[startIndex] == end[endIndex])
                    {
                        if (start[startIndex] == 'L' && startIndex < endIndex) break;
                        if (start[startIndex] == 'R' && startIndex > endIndex) break;

                        startIndex++;
                        endIndex++;
                    }
                    else break;
                }
                else
                {
                    if (startIndex < start.Length && start[startIndex] != 'X') break;
                    if (endIndex < end.Length && end[endIndex] != 'X') break;
                }
            }

            return (startIndex == endIndex) && (startIndex == start.Length);
        }
    }
}
