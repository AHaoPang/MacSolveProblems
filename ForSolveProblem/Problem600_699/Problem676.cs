using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem676 : IProblem
    {
        public void RunProblem()
        {
            var dic = new MagicDictionary();
            dic.BuildDict(new string[] { "hello", "leetcode" });

            var temp = dic.Search("hello");
            if (temp != false) throw new Exception();

            temp = dic.Search("hhllo");
            if (temp != true) throw new Exception();

            temp = dic.Search("hell");
            if (temp != false) throw new Exception();

            temp = dic.Search("leetcoded");
            if (temp != false) throw new Exception();
        }

        public class MagicDictionary
        {
            private IDictionary<string, IList<string>> m_innerDic;

            /** Initialize your data structure here. */
            public MagicDictionary()
            {
                m_innerDic = new Dictionary<string, IList<string>>();
            }

            /** Build a dictionary through a list of words */
            public void BuildDict(string[] dict)
            {
                foreach (var dictItem in dict)
                {
                    for (int i = 0; i < dictItem.Length; i++)
                    {
                        var newCharArray = dictItem.ToArray();
                        newCharArray[i] = '*';
                        var newString = new string(newCharArray);

                        if (!m_innerDic.ContainsKey(newString)) m_innerDic[newString] = new List<string>();
                        m_innerDic[newString].Add(dictItem);
                    }
                }
            }

            /** Returns if there is any word in the trie that equals to the given word after modifying exactly one character */
            public bool Search(string word)
            {
                for (int i = 0; i < word.Length; i++)
                {
                    var newCharArray = word.ToArray();
                    newCharArray[i] = '*';
                    var newString = new string(newCharArray);

                    if (m_innerDic.ContainsKey(newString))
                    {
                        if (m_innerDic[newString].Count > 1) return true;
                        if (m_innerDic[newString].First() != word) return true;
                    }
                }

                return false;
            }
        }
    }
}
