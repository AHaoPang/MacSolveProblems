using System;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem466 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int GetMaxRepetitions(string s1, int n1, string s2, int n2)
        {
            char[] chars1 = s1.ToCharArray(), chars2 = s2.ToCharArray();
            int l1 = s1.Length, l2 = s2.Length;
            Dictionary<int, int> lineEndIndex = new Dictionary<int, int>();
            Dictionary<int, int> prevSum = new Dictionary<int, int>();
            int s2mark = 0, count = 0;
            int circleBegin = -1, circleEnd = -1;
            lineEndIndex.Add(0, -1);
            for (int i = 0; i < n1; i++)
            {
                for (int j = 0; j < l1; j++)
                {
                    if (chars1[j] == chars2[s2mark])
                    {
                        s2mark = (s2mark + 1) % l2;
                        if (s2mark == 0) count++;
                    }
                }
                prevSum.Add(i, count);
                if (lineEndIndex.ContainsKey(s2mark))
                {
                    circleEnd = i;
                    circleBegin = Math.Min(lineEndIndex[s2mark] + 1, circleEnd);
                    break;
                }
                lineEndIndex.Add(s2mark, i);
            }

            if (circleEnd == -1) return count / n2;
            int beforeRes = circleBegin > 0 ? prevSum[circleBegin - 1] : 0;
            int middleRes = (n1 - circleBegin) / (circleEnd - circleBegin + 1) * (prevSum[circleEnd] - beforeRes);
            int res = (n1 - circleBegin) % (circleEnd - circleBegin + 1);
            int afterRes = 0;
            if (res > 0)
            {
                afterRes = prevSum[circleBegin + res - 1] - beforeRes;
            }
            return (beforeRes + middleRes + afterRes) / n2;
        }


        public int GetMaxRepetitions1(string s1, int n1, string s2, int n2)
        {
            var s1Com = GetStrComposed(s1);
            var s2Com = GetStrComposed(s2);

            if (!IsOk(s1Com, s2Com)) return 0;

            var r1 = OneToMulti(s1, s2);
            if (r1 != 0)
                return n1 * r1 / n2;

            var r2 = MultiToOne(s1, s2);
            return n1 / r2 / n2;
        }

        private Dictionary<char, int> GetStrComposed(string s)
        {
            var res = new Dictionary<char, int>();
            foreach (var c in s)
            {
                if (!res.ContainsKey(c))
                    res[c] = 0;

                res[c]++;
            }

            return res;
        }

        private bool IsOk(Dictionary<char, int> d1, Dictionary<char, int> d2)
        {
            var set1 = new HashSet<char>(d1.Keys);
            var set2 = new HashSet<char>(d2.Keys);

            return set2.Except(set1).Count() == 0;
        }

        private int OneToMulti(string s1, string s2)
        {
            var i1 = 0;
            var i2 = 0;
            var res = 0;
            while (i1 < s1.Length)
            {
                if (s1[i1] == s2[i2])
                {
                    i2++;
                    if (i2 == s2.Length)
                    {
                        i2 = 0;
                        res++;
                    }
                }

                i1++;
            }

            return res;
        }

        private int MultiToOne(string s1, string s2)
        {
            var i1 = 0;
            var i2 = 0;
            var res = 1;
            while (i2 < s2.Length)
            {
                if (s1[i1] == s2[i2])
                    i2++;

                i1++;
                if (i1 == s1.Length)
                {
                    i1 = 0;
                    res++;
                }
            }

            return res;
        }
    }
}
