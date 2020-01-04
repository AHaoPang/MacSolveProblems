using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem937 : IProblem
    {
        public void RunProblem()
        {
            var temp = ReorderLogFiles(new string[]
            {
                "a1 9 2 3 1","g1 act car","zo4 4 7","ab1 off key dog","a8 act zoo"
            });
        }

        public string[] ReorderLogFiles(string[] logs)
        {
            /*
             * 题目概述：按照指定的规则重新排列日志文件
             * 
             * 思路：
             *  1.依据每条日志的最后一个字符,来判断是数字日志,还是字母日志
             *  2.数字日志,直接添加到一个集合中去
             *  3.字母日志,则需要添加到一个字典中去,key 是新组装的,value 才是原来的字符串,接下来会对 key 做字母排序
             *  4.字母日志中的 key 的组织方式为"字母日志 标识符",字母日志按照字母顺序排序,当字母日志都一样时,才使用标识符,其实就是把标识符的排序优先级降到最低
             *
             * 关键点：
             *
             * 时间复杂度：O(nlogn)
             * 空间复杂度：O(n)
             */

            var numList = new List<string>(logs.Length);
            var strDic = new Dictionary<string, string>(logs.Length);

            foreach (var logItem in logs)
            {
                var lastChar = logItem.Last();

                if (lastChar >= '0' && lastChar <= '9')
                    numList.Add(logItem);
                else
                {
                    var twoArray = logItem.Split(' ', 2, StringSplitOptions.RemoveEmptyEntries);
                    strDic[$"{twoArray[1]} {twoArray[0]}"] = logItem;
                }
            }

            var forReturn = new List<string>(logs.Length);

            forReturn.AddRange(strDic.OrderBy(item => item.Key, StringComparer.Ordinal).Select(i => i.Value));
            forReturn.AddRange(numList);

            return forReturn.ToArray();
        }
    }
}
