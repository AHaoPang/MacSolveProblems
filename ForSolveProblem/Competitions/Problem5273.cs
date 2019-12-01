using System;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem5273 : IProblem
    {
        public void RunProblem()
        {
            var temp = SuggestedProducts(new string[] { "mobile", "mouse", "moneypot", "monitor", "mousepad" }, "mouse");

            temp = SuggestedProducts(new string[] { "havana" }, "havana");

            temp = SuggestedProducts(new string[] { "bags", "baggage", "banner", "box", "cloths" }, "bags");

            temp = SuggestedProducts(new string[] { "havana" }, "tatiana");
        }

        public IList<IList<string>> SuggestedProducts(string[] products, string searchWord)
        {
            /*
            * 题目概述：依据用户的输入,返回推荐的几个字符串
            * 
            * 思路：
            *   1.产品的规模并不大,只有 1000 个,完全可以先对这 1000 个产品做排序
            *   2.每检查一个字符,其实就是对字符串数组的一次过滤,而每次过滤以后,都只拿前 3 个,而过滤后的结果,会参与到下一轮的过滤中
            *
            * 关键点：
            *
            * 时间复杂度： O(1000*1000),即,每个产品的前缀都和要搜索的前缀一样,搜索最长 1000 产品最多 1000
            * 空间复杂度： O(1)
            */

            var loopArray = products.OrderBy(i => i, StringComparer.Ordinal).ToList();

            var forReturn = new List<IList<string>>();
            for (int i = 0; i < searchWord.Length; i++)
            {
                var curChar = searchWord[i];

                var nextArray = new List<string>();
                for (int j = 0; j < loopArray.Count; j++)
                {
                    var curStr = loopArray[j];

                    if (i >= curStr.Length || curChar != curStr[i]) continue;

                    nextArray.Add(curStr);
                }

                forReturn.Add(nextArray.Take(3).ToList());
                loopArray = nextArray;
            }

            return forReturn;
        }
    }
}
