using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem389 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public char FindTheDifference(string s, string t)
        {
            /*
             * 找到两个字符串中，那个多出来不同的字符
             * 思路：
             *  1.t是由s随机组合，再新加字符来得到的
             *  2.所以，理论上只要分别统计两个字符串中各字符的个数，最后就能得到那个多出来的字符了，时间复杂度O(n+m)，空间复杂度O(1)[因为空间大小是固定的，毕竟小写字母的数量是有限的]
             *  3.但以上方法需要遍历多次，其实如果使用异或的话，会有更好的解法
             *  4.异或本来就可以消除相同的部分，留下不同的部分，如果两个字符串s和t，只有一个字符不同，那么使用异或的这种特性是最合适的
             *  
             * 时间复杂度:O(n+m)
             * 空间复杂度:O(1)
             */

            int forReturn = 0;

            foreach(var sItem in s)
                forReturn ^= sItem;

            foreach(var tItem in t)
                forReturn ^= tItem;

            return (char)forReturn;
        }
    }
}
