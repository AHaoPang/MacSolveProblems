using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem953 : IProblem
    {
        public void RunProblem()
        {
            var temp = IsAlienSorted(new string[] { "hello", "leetcode" }, "hlabcdefgijkmnopqrstuvwxyz");
            if (temp != true) throw new Exception();

            temp = IsAlienSorted(new string[] { "word", "world", "row" }, "worldabcefghijkmnpqstuvxyz");
            if (temp != false) throw new Exception();

            temp = IsAlienSorted(new string[] { "apple", "app" }, "abcdefghijklmnopqrstuvwxyz");
            if (temp != false) throw new Exception();
        }

        public bool IsAlienSorted(string[] words, string order)
        {
            /*
             * 1.先按照给定的字母顺序来排序
             * 2.若排序前后顺序一致，则OK
             * 3.若排序前后顺序不一致，则不OK
             * 4.主要体会一下依赖注入的这种感觉
             */

            var compareTemp = new AlienStrCompare(order);
            var orderedWords = words.OrderBy(i => i, compareTemp).ToArray();

            for (int i = 0; i < orderedWords.Length; i++)
                if (orderedWords[i] != words[i]) return false;

            return true;
        }

        public class AlienStrCompare : IComparer<string>
        {
            IDictionary<char, int> orderDic;

            public AlienStrCompare(string order)
            {
                orderDic = new Dictionary<char, int>();
                for (int i = 0; i < order.Length; i++) orderDic[order[i]] = i;
            }

            public int Compare(string x, string y)
            {
                for (int i = 0; i < x.Length && i < y.Length; i++)
                {
                    if (x[i] == y[i]) continue;
                    return orderDic[x[i]] < orderDic[y[i]] ? -1 : 1;
                }

                /* 进到这里的两种情况：两个单词一模一样、一个单词短 */
                if (x.Length == y.Length) return 0;
                return x.Length < y.Length ? -1 : 1;
            }
        }

        public bool IsAlienSorted1(string[] words, string order)
        {
            /*
             * 检查字符串数组中的字符串，是否是按照特定的顺序来排序的
             * 思路：
             *  1. 验证是否有序，那么只要判断相邻的两个单词就好了
             *  2. 判断方式就是，找到第一个不相同的字符，然后判断在特定顺序中的索引位置
             *  3. 需要特别注意的是，若一个字符串段，另一个字符串长，那么前者才应该排在前面
             *  
             * 时间复杂度：O(n)
             * 空间复杂度：O(1)
             */

            var charIndexDic = new Dictionary<char, int>();
            for (int i = 0; i < order.Length; i++) charIndexDic[order[i]] = i;

            for (int i = 0; i < words.Length - 1; i++)
            {
                var compareBoolean = Str1SmallerThanStr2(words[i], words[i + 1], charIndexDic);
                if (!compareBoolean) return false;
            }

            return true;
        }

        public static bool Str1SmallerThanStr2(string str1, string str2, IDictionary<char, int> orderDic)
        {
            for (int i = 0; i < str1.Length && i < str2.Length; i++)
            {
                if (str1[i] == str2[i]) continue;
                return orderDic[str1[i]] < orderDic[str2[i]];
            }

            /* 进到这里的两种情况：两个单词一模一样、一个单词短 */
            if (str1.Length == str2.Length) return true;
            return str1.Length < str2.Length;
        }
    }
}
