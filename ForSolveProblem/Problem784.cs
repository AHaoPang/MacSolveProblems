using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem784 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public IList<string> LetterCasePermutation(string S)
        {
            /*
             * 思路：回溯的分支策略
             * 1.发现一个字符，就出现2个分支，1个是大写字母，1个是小写字母；
             * 2.检测完所有的字符，那么就收集结果；
             * 3.本题要求解的是所有的可能性，所以使用回溯刚好完全满足这种需求；
             * 
             * 时间复杂度：O(2^n)
             * 空间复杂度：O(1)，除了递归本身外，没有额外随规模增长的存储
             */

            RecurSive(S, 0);
            return forReturn;
        }

        private IList<string> forReturn = new List<string>();

        private void RecurSive(string input,int curIndex)
        {
            if(curIndex >= input.Length)
            {
                forReturn.Add(input);
                return;
            }

            var curChar = input[curIndex];

            if (curChar >= 'a' && curChar <= 'z')
                RecurSive(input.Substring(0, curIndex) + (char)('A' + (curChar - 'a')) + input.Substring(curIndex + 1), curIndex + 1);
            else if (curChar >= 'A' && curChar <= 'Z')
                RecurSive(input.Substring(0, curIndex) + (char)('a' + (curChar - 'A')) + input.Substring(curIndex + 1), curIndex + 1);

            RecurSive(input, curIndex + 1);
        }
    }
}
