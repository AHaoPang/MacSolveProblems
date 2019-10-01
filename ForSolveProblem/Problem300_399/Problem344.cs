using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem344 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public void ReverseString(char[] s)
        {
            /*
             * 字符串的反转
             * 思路：
             *  1.考虑使用双指针的方式
             *  2.前面的指针负责往后扔东西，后面的指针负责往前面扔东西，直到他俩错开，则终止
             *  
             * 时间复杂度：O(n)，与字符串的长度有关，循环一次即可
             * 空间复杂度：O(1)，使用固定大小的额外空间
             * 
             * 考察点：
             *  1.双指针的使用
             */

            int sIndex = 0;
            int eIndex = s.Length - 1;
            
            while(sIndex < eIndex)
            {
                var temp = s[sIndex];
                s[sIndex] = s[eIndex];
                s[eIndex] = temp;

                sIndex++;
                eIndex--;
            }
        }
    }
}
