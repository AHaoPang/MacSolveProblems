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

            var temp = Partition("aab");
        }

        public IList<IList<string>> Partition(string s)
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
    }
}
