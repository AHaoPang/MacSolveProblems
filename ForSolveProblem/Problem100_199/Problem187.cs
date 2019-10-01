using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem187 : IProblem
    {
        public void RunProblem()
        {
            var temp = FindRepeatedDnaSequences("AAAAACCCCCAAAAACCCCCCAAAAAGGGTTT");
        }

        public IList<string> FindRepeatedDnaSequences(string s)
        {
            /*
             * 查找重复的DNA片段
             * 思路：
             *  1.片段长度是固定的，且连续的
             *  2.那么当知道总长为n,片场长为m时，总共的片段数会是：n-m+1
             *  3.那么如何快速判断片段一致呢
             *  4.其实最优的方法就是遍历一次，得到特征值，具有相同特征值的字符串就是提供所求的
             *  5.字段是个相当不错的选择
             *  
             * 时间复杂度：O(n)
             * 空间复杂度：O(n*m)
             */

            Dictionary<string, int> forReturnDic = new Dictionary<string, int>();

            for(int i = 0;i < s.Length - 10 + 1; i++)
            {
                var keyTemp = s.Substring(i, 10);

                if (!forReturnDic.ContainsKey(keyTemp)) forReturnDic[keyTemp] = 0;

                forReturnDic[keyTemp] += 1;
            }

            var forReturn = new List<string>();
            foreach(var dicItem in forReturnDic)
                if (dicItem.Value > 1) forReturn.Add(dicItem.Key);
            return forReturn;
        }
    }
}
