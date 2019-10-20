using System;
using System.Collections;
using System.Collections.Generic;

namespace ForSolveProblem
{
    public class Problem712 : IProblem
    {
        public int MinimumDeleteSum(string s1, string s2)
        {
            /*
             * 题目概述：为了让两个字符串相同,所需要删除的最少字符 Ascii 和是多少
             * 
             * 思路：
             *  1. 定义状态:dp[i][j] i 和 j 表示字符串 s1 和 s2 的字符指针,i 和 j都是从 1 开始,dp[i][j]为字符串相同时,所需删除的最少字符 Ascii 和
             *  2. 方法的返回值是 dp[s1.length][s2.length]
             *  3. 状态转移方程:
             *      3.1 s1[i] == s2[j],dp[i][j] = dp[i-1][j-1]
             *      3.2 s1[i] != s2[j],dp[i][j] = min( dp[i-1][j]+s1[i],dp[i][j-1]+s2[j] )
             *
             * 关键点：
             *
             * 时间复杂度：O(m*n)
             * 空间复杂度：O(m*n)
             */

            var dp = new int[s1.Length + 1, s2.Length + 1];

            for (int i = 0; i < s1.Length; i++)
                dp[i + 1, 0] = dp[i, 0] + s1[i];
            for (int j = 0; j < s2.Length; j++)
                dp[0, j + 1] = dp[0, j] + s2[j];

            for (int i = 1; i <= s1.Length; i++)
                for (int j = 1; j <= s2.Length; j++)
                    dp[i, j] = s1[i - 1] == s2[j - 1] ? dp[i, j] = dp[i - 1, j - 1] : Math.Min(dp[i - 1, j] + s1[i - 1], dp[i, j - 1] + s2[j - 1]);

            return dp[s1.Length, s2.Length];
        }

        public int MinimumDeleteSum1(string s1, string s2)
        {
            /*
             * 题目概述：为了让两个字符串相等,需要删除的最少字符和是多少
             * 
             * 思路：
             *  1. 本方法使用回溯的方式来求解
             *  2. 两个指针 s1Index 和 s2Index 分别指向各自的字符串中的字符
             *  3. 若两个字符相等,那么两个指针都向后移动
             *  4. 若两个字符不相等,那么有 2 个选择,可以移动1 个指针,也可以移动另一个指针
             *  5. 若一个指针指向边界,那么就要让另一个指针也指向边界
             *
             * 关键点：
             *  1. 为了加速而建立的备忘录,可以设置为,到达同一个位置时,索引和越小越好,大的,直接抛弃
             *
             * 时间复杂度：O(2^(m+n))
             * 空间复杂度：O(m+n)
             */

            m_minAsciiValue = int.MaxValue;
            BackTrace(s1, s2, 0, 0, 0, new Dictionary<string, int>(100000));
            return m_minAsciiValue;
        }

        private int m_minAsciiValue;

        private void BackTrace(string s1, string s2, int s1Index, int s2Index, int totalValue, IDictionary<string, int> dic)
        {
            if (s1Index == s1.Length && s2Index == s2.Length)
            {
                m_minAsciiValue = Math.Min(m_minAsciiValue, totalValue);
                return;
            }

            var keyStr = $"{s1Index}_{s2Index}";
            if (dic.ContainsKey(keyStr) && dic[keyStr] <= totalValue) return;
            dic[keyStr] = totalValue;

            if (s1Index == s1.Length)
            {
                // s1 end
                BackTrace(s1, s2, s1Index, s2Index + 1, totalValue + s2[s2Index], dic);
            }
            else if (s2Index == s2.Length)
            {
                // s2 end
                BackTrace(s1, s2, s1Index + 1, s2Index, totalValue + s1[s1Index], dic);
            }
            else
            {
                // s1 s2 not end
                if (s1[s1Index] == s2[s2Index])
                {
                    //char equal
                    BackTrace(s1, s2, s1Index + 1, s2Index + 1, totalValue, dic);
                }
                else
                {
                    //char not equal
                    BackTrace(s1, s2, s1Index + 1, s2Index, totalValue + s1[s1Index], dic);
                    BackTrace(s1, s2, s1Index, s2Index + 1, totalValue + s2[s2Index], dic);
                }
            }
        }

        public void RunProblem()
        {
            var temp = MinimumDeleteSum("sea", "eat");
            if (temp != 231) throw new Exception();

            temp = MinimumDeleteSum("delete", "leet");
            if (temp != 403) throw new Exception();

            temp = MinimumDeleteSum("igijekdtywibepwonjbwykkqmrgmtybwhwjiqudxmnniskqjfbkpcxukrablqmwjndlhblxflgehddrvwfacarwkcpmcfqnajqfxyqwiugztocqzuikamtvmbjrypfqvzqiwooewpzcpwhdejmuahqtukistxgfafrymoaodtluaexucnndlnpeszdfsvfofdylcicrrevjggasrgdhwdgjwcchyanodmzmuqeupnpnsmdkcfszznklqjhjqaboikughrnxxggbfyjriuvdsusvmhiaszicfa", "ikhuivqorirphlzqgcruwirpewbjgrjtugwpnkbrdfufjsmgzzjespzdcdjcoioaqybciofdzbdieegetnogoibbwfielwungehetanktjqjrddkrnsxvdmehaeyrpzxrxkhlepdgpwhgpnaatkzbxbnopecfkxoekcdntjyrmmvppcxcgquhomcsltiqzqzmkloomvfayxhawlyqxnsbyskjtzxiyrsaobbnjpgzmetpqvscyycutdkpjpzfokvi");
        }
    }
}
