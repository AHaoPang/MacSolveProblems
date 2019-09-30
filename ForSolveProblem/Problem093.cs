using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem093 : IProblem
    {
        public void RunProblem()
        {
            var temp = RestoreIpAddresses("25525511135");

            temp = RestoreIpAddresses("010010");
        }

        public IList<string> RestoreIpAddresses(string s)
        {
            /*
             * IP地址解析
             * 思路：
             *  1.给定一个数字字符串，返回可能的IP地址
             *  2.IP地址的构造规则：4组数字构成，每组数字的取值范围是0~255
             *  3.按组来获取数字好了
             *  4.每组思考的事情是一样的，取1位、2位、3位
             *  5.判断获取到了第4组数字，那么就该打包到输出集合里面去了
             *
             * 时间复杂度：O(n)，树的深度是有上限的，树节点的枝也是有上限的
             * 空间复杂度：O(1)
             */

            IList<string> forReturn = new List<string>();

            Recursive(forReturn, s, 0, 0, new List<int>());

            return forReturn;
        }

        private void Recursive(IList<string> forReturn, string s, int group, int startIndex, IList<int> curNums)
        {
            if (group == 4)
            {
                if (startIndex == s.Length) forReturn.Add(string.Join(".", curNums));

                return;
            }

            for (int i = 1; i <= 3; i++)
            {
                //避免超出范围
                if (startIndex + i > s.Length) continue;

                //避免位数改变
                if (s[startIndex] == '0' && i > 1) break;
                var tempInt = int.Parse(s.Substring(startIndex, i));

                //var tempStr = s.Substring(startIndex, i);
                //var tempInt = int.Parse(tempStr);
                //if (tempInt.ToString().Length != tempStr.Length) continue;

                if (tempInt >= 0 && tempInt <= 255)
                {
                    curNums.Add(tempInt);
                    Recursive(forReturn, s, group + 1, startIndex + i, curNums);
                    curNums.RemoveAt(curNums.Count - 1);
                }
            }
        }
    }
}
