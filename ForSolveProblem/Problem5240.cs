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

        public int MaxLength(IList<string> arr)
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
