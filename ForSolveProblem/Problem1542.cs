using System;
using System.Collections.Generic;
using System.Text;

namespace ForSolveProblem
{
    public class Problem1542 : IProblem
    {
        public void RunProblem()
        {
            var temp = LongestAwesome("3242415");
            if (temp != 5) throw new Exception();

            temp = LongestAwesome("12345678");
            if (temp != 1) throw new Exception();

            temp = LongestAwesome("213123");
            if (temp != 6) throw new Exception();

            temp = LongestAwesome("00");
            if (temp != 2) throw new Exception();
        }

        public int LongestAwesome(string s)
        {
            /*
             * 组成字符串的字符个数仅有10个;
             * 具有回文特性的区间,各组成部分,必然有且仅有1个字符的个数是奇数个
             * 得到这样一个区间,必然意味着参与前缀和的两个区间,有且仅有1个位是不同的
             * 
             * 1.使用二进制表示前缀和的奇数和偶数状态
             * 2.使用字典来存储已经出现过的状态 重复出现的状态不记录,因为区间要尽可能的大
             * 3.能够构成"回文特性区间"的状态一共有2种情况
             *      3.1 状态相同,那么求差后得到的一定是 全偶,满足条件
             *      3.2 仅仅一个位不同,那么求差后得到的是1个奇数,满足条件
             * 4.找到最大的长度
             * 
             * 时间复杂度:O(n)
             * 空间复杂度:O(1) 最多存储 2^10 个数,也就是 1024
             */
            var dicNum = new Dictionary<char, int>()
            {
                {'0',0 },
                {'1',1 },
                {'2',2 },
                {'3',3 },
                {'4',4 },
                {'5',5 },
                {'6',6 },
                {'7',7 },
                {'8',8 },
                {'9',9 },
            };
            var dic = new Dictionary<int, int>();
            dic[0] = -1;

            var res = 0;
            var count = 0;
            for (var i = 0; i < s.Length; i++)
            {
                var c = s[i];
                count ^= (1 << dicNum[c]);

                if (dic.ContainsKey(count))
                    res = Math.Max(res, i - dic[count]);

                for (var j = 0; j < 10; j++)
                {
                    var temp = count ^ (1 << j);
                    if (dic.ContainsKey(temp))
                        res = Math.Max(res, i - dic[temp]);
                }

                if (!dic.ContainsKey(count))
                    dic[count] = i;
            }

            return res;
        }
    }
}
