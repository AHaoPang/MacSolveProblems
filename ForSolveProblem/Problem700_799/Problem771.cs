using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem771 : IProblem
    {
        public void RunProblem()
        {
            var temp = NumJewelsInStones("aA", "aAAbbbb");
            if (temp != 3) throw new Exception();

            temp = NumJewelsInStones("z", "ZZ");
            if (temp != 0) throw new Exception();
        }

        public int NumJewelsInStones(string J, string S)
        {
            /*
             * 在自己拥有的石头中，查找备案证明是宝石的石头
             * 思路：
             *  1.做个手册，能快速确定一个石头是不是宝石，用HashTable很合适
             *  2.遍历自己手中的石头，然后统计
             *  
             * 时间复杂度：O(n+m)，看遍所有的宝石和自己的石头
             * 空间复杂度：O(m)，索引所有的宝石
             */

            var jewelsSet = new HashSet<char>(J);

            var forReturn = 0;
            foreach (var sItem in S) if (jewelsSet.Contains(sItem)) forReturn++;

            return forReturn;
        }
    }
}
