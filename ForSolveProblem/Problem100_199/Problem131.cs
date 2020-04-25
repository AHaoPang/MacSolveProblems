using System;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem131 : IProblem
    {
        public void RunProblem()
        {
            //var list1 = new List<IList<string>>();
            //var listChild1 = new List<string>();
            //listChild1.Add("111");
            //listChild1.Add("222");
            //list1.Add(listChild1);
            //var i1 = new DicItem() { IsOk = false, ResList = list1 };
            //var i2 = (DicItem)i1.Clone();
            //foreach (var item in i2.ResList)
            //    item.Add("333");

            var list = new List<int>() { 3, 5, 7, 1, 2, 4, 1, 1 };

            list.Sort((a, b) => a.CompareTo(b));
            var t = list.BinarySearch(3);

            var temp = Partition("aab");
        }

        public IList<IList<string>> Partition(string s)
        {
            m_res = new List<IList<string>>();

            var dp = new byte[s.Length * s.Length];
            for (var i = 0; i < s.Length; i++)
            {
                SaveDp(s, i, i, dp);
                SaveDp(s, i, i + 1, dp);
            }

            Recursive(new List<string>(), 0, s, dp);
            return m_res;
        }

        private void SaveDp(string s, int prePos, int lastPos, byte[] dp)
        {
            while (prePos >= 0 && lastPos < s.Length && s[prePos] == s[lastPos])
            {
                dp[prePos * s.Length + lastPos] = 1;

                prePos--;
                lastPos++;
            }
        }

        private IList<IList<string>> m_res;

        private void Recursive(IList<string> list, int curPos, string s, byte[] dp)
        {
            if (curPos == s.Length)
            {
                m_res.Add(new List<string>(list));
                return;
            }

            for (var i = curPos; i < s.Length; i++)
            {
                if (dp[curPos * s.Length + i] != 1) continue;

                list.Add(s.Substring(curPos, i - curPos + 1));
                Recursive(list, i + 1, s, dp);
                list.RemoveAt(list.Count - 1);
            }
        }

        public IList<IList<string>> Partition1(string s)
        {
            m_dic = new Dictionary<int, DicItem>(s.Length);
            m_dic[s.Length] = new DicItem() { IsOk = true, ResList = new List<IList<string>>() };

            return Recursive(s.ToArray(), 0).ResList;
        }

        private Dictionary<int, DicItem> m_dic;

        private DicItem Recursive(char[] cArr, int startPos)
        {
            if (m_dic.ContainsKey(startPos))
                return (DicItem)m_dic[startPos].Clone();

            var res = new List<IList<string>>();
            for (var i = startPos; i < cArr.Length; i++)
            {
                if (!IsPart(cArr, startPos, i)) continue;

                var entity = Recursive(cArr, i + 1);
                if (!entity.IsOk) continue;

                var curStr = new string(cArr.Skip(startPos).Take(i - startPos + 1).ToArray());
                if (!entity.ResList.Any())
                    res.Add(new List<string>() { curStr });
                else
                    foreach (var oItem in entity.ResList)
                    {
                        oItem.Insert(0, curStr);
                        res.Add(oItem);
                    }
            }

            if (res.Any())
                m_dic[startPos] = new DicItem() { IsOk = true, ResList = res };
            else
                m_dic[startPos] = new DicItem() { IsOk = false };

            return (DicItem)m_dic[startPos].Clone();
        }

        private bool IsPart(char[] cArr, int startPos, int endPos)
        {
            while (startPos < endPos)
                if (cArr[startPos++] != cArr[endPos--])
                    return false;

            return true;
        }

        private class DicItem : ICloneable
        {
            public bool IsOk { get; set; }
            public IList<IList<string>> ResList { get; set; }

            public object Clone()
            {
                var res = new DicItem() { IsOk = IsOk };
                if (ResList != null)
                    res.ResList = ResList
                        .Select(i => (IList<string>)i.Select(j => j).ToList())
                        .ToList();

                return res;
            }
        }

        #region Way2
        public IList<IList<string>> result = new List<IList<string>>();
        public IList<IList<string>> Partition2(string s)
        {
            if (s == null || s.Length == 0) return result;
            bool[,] dp = new bool[s.Length, s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                prePro(s, i, i, dp);
                prePro(s, i, i + 1, dp);
            }
            List<string> res = new List<string>();
            BackTrack(res, s, 0, dp);
            return result;

        }

        public void BackTrack(List<string> res, string s, int index, bool[,] dp)
        {
            if (index == s.Length)
            {
                result.Add(new List<string>(res));
                return;
            }
            for (int i = index; i < s.Length; i++)
            {
                if (!dp[index, i])
                    continue;

                res.Add(s.Substring(index, i - index + 1));
                BackTrack(res, s, i + 1, dp);
                res.RemoveAt(res.Count - 1);
            }
        }

        public void prePro(string s, int i, int j, bool[,] dp)
        {
            while (i >= 0 && j < s.Length && s[i] == s[j])
            {
                dp[i, j] = true;
                i--;
                j++;
            }
        }
        #endregion

        #region Way3
        Dictionary<int, List<IList<string>>> dict = new Dictionary<int, List<IList<string>>>();
        public IList<IList<string>> Partition4(string s)
        {


            if (string.IsNullOrEmpty(s) || s.Length == 0)
                return new List<IList<string>> { };

            //Ilist<string> path;

            return Partition(0, s);
        }

        List<IList<string>> Partition(int index, string s)
        {
            if (dict.ContainsKey(index)) return dict[index];
            if (index == s.Length - 1)
            {
                return new List<IList<string>>
                {
                    new List<string>{s[s.Length-1].ToString()}
                };
            }
            else if (index >= s.Length)
            {
                return null;
            }
            else
            {
                var res = new List<IList<string>>();
                for (var i = index; i < s.Length; i++)
                {
                    if (Check(s, index, i))
                    {
                        var str = s.Substring(index, i - index + 1);
                        if (i == s.Length - 1)
                        {
                            res.Add(new List<string> { str });
                            continue;
                        }

                        var temp = Partition(i + 1, s);
                        if (temp != null)
                        {
                            foreach (var array in temp)
                            {
                                var tlist = new List<string> { str };
                                tlist.AddRange(array);
                                res.Add(tlist);
                            }
                        }
                    }
                }
                res = res.Count > 0 ? res : null;
                dict[index] = res;
                return res;

            }
        }




        bool Check(string s, int index, int i)
        {
            if (index == i)
            {
                return true;
            }
            if (index > i)
            {
                return false;
            }
            while (index < i)
            {
                if (s[index] != s[i]) return false;
                index++;
                i--;
            }
            return true;

        }
        #endregion
    }
}
