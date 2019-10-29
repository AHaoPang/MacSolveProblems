using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForSolveProblem
{
    public class Problem5240 : IProblem
    {
        public void RunProblem()
        {
            var temp = MaxLength(new List<string>() { "un", "iq", "ue" });
            if (temp != 4) throw new Exception();

            temp = MaxLength(new List<string>() { "cha", "r", "act", "ers" });
            if (temp != 6) throw new Exception();

            temp = MaxLength(new List<string>() { "abcdefghijklmnopqrstuvwxyz" });
            if (temp != 26) throw new Exception();

            temp = MaxLength(new List<string>() { "ab", "ba", "cd", "dc", "ef", "fe", "gh", "hg", "ij", "ji", "kl", "lk", "mn", "nm", "op", "po" });
            if (temp != 16) throw new Exception();

            temp = MaxLength(new List<string>() { "enrgbdwhqpo", "bioedlpz", "nfampjeycstxbz", "almhiqdypr", "qaxldwmgk", "mpfgislz", "g", "yjlipemkuxqsctforbw", "udylqhogvfmwikat", "euzrimspyfanvlkhb", "ltekhadr", "wvagsjrzlobm" });
            if (temp != 20) throw new Exception();

            temp = MaxLength(new List<string>() { "dnshjtyweqga", "oruikdwylqcxzsjfe", "yv", "mgvpaczjebwyidoh", "ajhszfbwuyxivlend", "sezydofiwpabkxj", "fnueg", "d", "yruhmnfgk", "inlk", "ckjlfiugnzmhsxdy", "iupsvagkcn", "inmrvwyuajzopdsk", "qwmsxzyilkrjoc", "aemrkputxiqoldby", "pytlbaigkd" });
            if (temp != 20) throw new Exception();
        }

        public bool containSame(string a)
        {
            int al = a.Length;
            for (int i = 0; i < al; i++)
                for (int j = i + 1; j < al; j++)
                    if (a[i] == a[j])
                        return true;
            return false;
        }
        public bool containSame(string a, string b)
        {
            int al = a.Length;
            int bl = b.Length;
            for (int i = 0; i < al; i++)
                for (int j = 0; j < bl; j++)
                    if (a[i] == b[j])
                        return true;
            return false;
        }
        public int search(IList<string> arr, int length, string currstr, int num)
        {
            if (num == length)
                return currstr.Length;
            int max1 = 0, max2 = 0;
            if (!containSame(arr[num]) && !containSame(currstr, arr[num]))
                max1 = search(arr, length, currstr + arr[num], num + 1);
            max2 = search(arr, length, currstr, num + 1);
            return Math.Max(max1, max2);
        }
        public int MaxLength3(IList<string> arr)
        {
            return search(arr, arr.Count(), "", 0);
        }

        public int MaxLength2(IList<string> arr)
        {
            List<string> store = new List<string>();

            for (int i = 0; i < arr.Count; i++)
            {
                char[] cur = arr[i].ToCharArray();

                Array.Sort(cur);
                bool same = false;
                for (int j = 1; j < cur.Length; j++)
                {
                    if (cur[j] == cur[j - 1])
                    {
                        same = true;
                    }
                }

                if (same)
                {
                    continue;
                }

                for (int j = 0; j < store.Count; j++)
                {
                    for (int k = 0; k < cur.Length; k++)
                    {
                        int pos = store[j].IndexOf(cur[k]);

                        if (pos > -1)
                        {
                            break;
                        }

                        if (k == cur.Length - 1)
                        {
                            string n = store[j] + arr[i];
                            store.Add(n);
                        }
                    }
                }

                store.Add(arr[i]);

            }

            int max = 0;

            for (int i = 0; i < store.Count; i++)
            {
                max = Math.Max(max, store[i].Length);
            }

            return max;
        }

        public int MaxLength(IList<string> arr)
        {
            /*
             * 问题:找出可行解的最大字符串长度
             * 思路:
             *  1.数组中的每个字符串,都可以选择加入到结果中,以及不加入到结果中
             *  2.需要分多个步骤来完成,步骤数等于数组的长度
             *  3.以上这个问题,是很明显的回溯模型
             *  4.可以使用DP么?没找到方法,理论上想,子问题的最优解,并非父问题的最优解,所以无法使用DP
             *  5.那就使用经典的回溯好了,在其中适当剪枝即可
             * 
             * 关键点:
             * 
             * 时间复杂度:O(2^n)
             * 空间复杂度:O(n)
             */

            Backtrace(arr, 0, new HashSet<char>());
            return m_maxLength;
        }

        private int m_maxLength;

        private void Backtrace(IList<string> arr, int curIndex, ISet<char> curChars)
        {
            if (curIndex == arr.Count)
            {
                m_maxLength = Math.Max(m_maxLength, curChars.Count);
                return;
            }

            Backtrace(arr, curIndex + 1, curChars);

            var newCharSets = new HashSet<char>(arr[curIndex]);
            if (newCharSets.Count != arr[curIndex].Length) return;
            var newHashSets = curChars.Union(newCharSets).ToHashSet();
            if (newHashSets.Count != curChars.Count + arr[curIndex].Length) return;

            Backtrace(arr, curIndex + 1, newHashSets);
        }

        public int MaxLength1(IList<string> arr)
        {
            var forReturn = 0;

            var dp = new HashSet<char>[arr.Count, 2];
            for (int i = 0; i < arr.Count; i++)
            {
                dp[i, 0] = new HashSet<char>(arr[i]);
                if (dp[i, 0].Count != arr[i].Length)
                    dp[i, 0] = new HashSet<char>();

                dp[i, 1] = new HashSet<char>(dp[i, 0]);

                for (int j = i - 1; j >= 0; j--)
                {
                    for (int k = 0; k < 2; k++)
                    {
                        var tempSet = new HashSet<char>(dp[i, 0]);
                        var setTemp = unionTwoHashSet(tempSet, dp[j, k]);
                        if (setTemp.Count != dp[i, 0].Count + dp[j, k].Count) continue;

                        if (setTemp.Count > dp[i, 1].Count) dp[i, 1] = setTemp;
                    }
                }

                var maxLength = Math.Max(dp[i, 1].Count, dp[i, 0].Count);
                forReturn = Math.Max(maxLength, forReturn);
            }

            return forReturn;
        }

        private HashSet<char> unionTwoHashSet(ISet<char> set1, ISet<char> set2)
        {
            var length = set1.Count + set2.Count;

            set1.UnionWith(set2);

            if (set1.Count == length) return new HashSet<char>(set1);

            return new HashSet<char>();
        }
    }
}
