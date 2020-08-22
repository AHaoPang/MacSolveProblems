using System;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem076 : IProblem
    {
        public void RunProblem()
        {
            var temp = MinWindow("a", "aa");
            if (temp != "") throw new Exception();

            temp = MinWindow("bbaa", "aba");
            if (temp != "baa") throw new Exception();
        }

        public string MinWindow(string s, string t)
        {
            var resLength = int.MaxValue;
            var resStr = "";

            var dic = t.GroupBy(i => i).ToDictionary(i => i.Key, j => j.Count());
            var tEntity = new DicEntity(dic);

            var charSets = tEntity.GetCharSets();
            var r = DicEntity.BuilderCountDicEntity(charSets);
            var rIndex = 0;
            var lIndex = -1;
            while (rIndex < s.Length)
            {
                r.AddChar(s[rIndex]);

                while (r.Equals(tEntity))
                {
                    if (resLength > rIndex - lIndex)
                    {
                        resLength = rIndex - lIndex;
                        resStr = s.Substring(lIndex + 1, rIndex - lIndex);
                    }

                    lIndex++;
                    r.SubChar(s[lIndex]);
                }

                rIndex++;
            }

            return resStr;
        }

        private class DicEntity
        {
            private DicEntity() { }
            public DicEntity(IDictionary<char, int> dic)
            {
                CharDic = dic;
                ItemCount = dic.Sum(i => i.Value);
            }

            public int ItemCount { get; set; }
            public IDictionary<char, int> CharDic { get; set; } = new Dictionary<char, int>();

            public HashSet<char> GetCharSets() => new HashSet<char>(CharDic.Keys);

            public override int GetHashCode() => 1;

            public override bool Equals(object obj)
            {
                var another = (DicEntity)obj;

                if (ItemCount < another.ItemCount)
                    return false;

                if (CharDic.Count != another.CharDic.Count)
                    return false;

                foreach (var item in CharDic)
                    if (item.Value < another.CharDic[item.Key])
                        return false;

                return true;
            }

            public static CountDicEntity BuilderCountDicEntity(ISet<char> charSets)
            {
                return new CountDicEntity(charSets);
            }

            public class CountDicEntity : DicEntity
            {
                public CountDicEntity(ISet<char> charSets) => m_charSets = new HashSet<char>(charSets);

                private ISet<char> m_charSets = new HashSet<char>();

                public void AddChar(char c)
                {
                    if (!m_charSets.Contains(c))
                        return;

                    if (!CharDic.ContainsKey(c))
                        CharDic[c] = 0;

                    CharDic[c]++;
                    ItemCount++;
                }

                public void SubChar(char c)
                {
                    if (CharDic.ContainsKey(c))
                    {
                        CharDic[c]--;
                        ItemCount--;
                        if (CharDic[c] == 0)
                            CharDic.Remove(c);
                    }
                }
            }
        }
    }
}
