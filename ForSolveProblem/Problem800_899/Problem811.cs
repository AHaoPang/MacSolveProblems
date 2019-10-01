using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem811 : IProblem
    {
        public void RunProblem()
        {
            var temp = SubdomainVisits(new string[] { "9001 discuss.leetcode.com" });

            temp = SubdomainVisits(new string[] { "900 google.mail.com", "50 yahoo.com", "1 intel.mail.com", "5 wiki.org" });
        }

        public IList<string> SubdomainVisits(string[] cpdomains)
        {
            /*
             * 依据给定域名的访问次数，统计出所有域名的访问次数
             * 思路：
             *  1.对给定输入做解析，分析出包含的域名数量
             *  2.然后对域名访问数量做统计
             *  3.格式化输出即可
             *  
             * 时间复杂度：O(n)
             * 空间复杂度：O(n)
             */

            var domainCountDic = new Dictionary<string, int>(cpdomains.Length);
            foreach(var domainItem in cpdomains)
            {
                var countDomain = domainItem.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var countTemp = int.Parse(countDomain[0]);

                var domainArray = countDomain[1].Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
                var domainStr = string.Empty;
                for (int i = domainArray.Length - 1; i >= 0; i--)
                {
                    if (i == domainArray.Length - 1) domainStr = domainArray[i];
                    else domainStr = $"{domainArray[i]}.{domainStr}";

                    if (!domainCountDic.ContainsKey(domainStr)) domainCountDic[domainStr] = 0;
                    domainCountDic[domainStr] += countTemp;
                }
            }

            return domainCountDic.Select(i => $"{i.Value} {i.Key}").ToList();
        }
    }
}
