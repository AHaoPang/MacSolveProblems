using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem139 : IProblem
    {
        public void RunProblem()
        {
            string s = "leetcode";
            IList<string> wordDict = new List<string>() { "leet", "code" };
            var temp = new Problem139().WordBreak(s, wordDict);
            if (!temp) throw new Exception();

            s = "applepenapple";
            wordDict = new List<string>() { "apple", "pen" };
            temp = new Problem139().WordBreak(s, wordDict);
            if (!temp) throw new Exception();

            s = "catsandog";
            wordDict = new List<string>() { "cats", "dog", "sand", "and", "cat" };
            temp = new Problem139().WordBreak(s, wordDict);
            if (temp) throw new Exception();
        }

        public bool WordBreak(string s, IList<string> wordDict)
        {
            /*
             * 指定的字符串，是否可以由可选的几个单词组成
             * 思路：
             *  1.定义状态dp[i]，表示字符串0~i-1的部分，是否可由可选单词组成；       -->状态定义
             *  2.dp[0]，恒为 true，因为空子串肯定是可以的；                        -->初始条件
             *  3.dp[n] = dp[n-x] && wordDict.containkey(x)                       -->自上而下的分析，自下而上的去解决，可以避免重复的子问题，同时使用了最优子结构
             *  
             * 时间复杂度：O(n)，n表示字符串的长度
             * 空间复杂度：O(n)，存储了一个一维数组
             * 
             * 考察点：
             *  1.动态规划
             */

            bool[] dp = new bool[s.Length + 1];
            dp[0] = true;

            for (int i = 0; i < s.Length; i++)
            {
                for (int j = i; j >= 0; j--)
                {
                    if (dp[j] && wordDict.Contains(s.Substring(j, i - j + 1)))
                    {
                        dp[i + 1] = true;
                        break;
                    }
                }
            }

            return dp[s.Length];
        }

        Dictionary<string, bool> memoDic = new Dictionary<string, bool>();
        Dictionary<char, List<string>> charDic = new Dictionary<char, List<string>>();

        public bool WordBreak2(string s, IList<string> wordDict)
        {
            /*
             * 将一长串字符，拆分成已知的多个单词，是否可行
             * 思路：
             *  1.依据已知的单词，将串从头开始拆分，拆分成：已知的串+待拆分的串；-->大问题可以拆分成同类的小问题，可以考虑使用递归
             *  2.不同的拆分方法，最后可能面临相同的待拆分串；                  -->面临重复的子问题
             *  3.可以考虑使用备忘录的方式，将待拆分串与拆分结果关联起来；      -->做合理的剪枝，让回溯也能接近动态规划的效率
             *  
             * 时间复杂度：O(n*m)
             * 空间复杂度：O(n*m)
             * 
             * 考察点：
             *  1.回溯法 + 备忘录
             */

            //单词分组
            if (!charDic.Any())
                charDic = wordDict.ToLookup(i => i[0], j => j).ToDictionary(i => i.Key, j => j.ToList());

            //备忘录读取
            if (memoDic.ContainsKey(s)) return memoDic[s];

            //特殊情况处理
            if (string.IsNullOrWhiteSpace(s)) return true;

            //正常的业务比较
            var firstChar = s[0];
            var words = charDic.ContainsKey(firstChar) ? charDic[firstChar] : new List<string>();
            foreach (var wordItem in words)
            {
                if (s.Length < wordItem.Length) continue;
                if (s.Substring(0, wordItem.Length) != wordItem) continue;

                var newStr = new string(s.Skip(wordItem.Length).Take(s.Length - wordItem.Length).ToArray());
                if (WordBreak(newStr, wordDict))
                {
                    memoDic[newStr] = true;
                    return true;
                }
                else
                    memoDic[newStr] = false;
            }

            return false;
        }
    }
}
