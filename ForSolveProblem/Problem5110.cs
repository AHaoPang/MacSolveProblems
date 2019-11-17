using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForSolveProblem
{
    public class Problem5110 : IProblem
    {
        public void RunProblem()
        {
            List<string> listTemp = new List<string>()
            {
                "A",
                "a",
                "C",
                "c"
            };

            listTemp.Sort((w1, w2) =>
            {
                var c1 = w1.First();
                var c2 = w2.First();

                return c1 == c2 ? 0 :
                        c1 > c2 ? 1 :
                        -1;
            });

            listTemp.Sort();

            listTemp.Sort(StringComparer.Ordinal);
            listTemp.Sort(StringComparer.OrdinalIgnoreCase);

            var list2 = listTemp.OrderBy(i => i).ToList();

            var list3 = listTemp.OrderBy(i => i, StringComparer.Ordinal);

            var temp = GenerateSentences(new List<IList<string>>()
            {
                new List<string>(){"happy","joy"},
                new List<string>(){"sad","sorrow"},
                new List<string>(){"joy","cheerful"},
            }, "I am happy today but was sad yesterday");

            var temp2 = GenerateSentences(new List<IList<string>>()
            {
                new List<string>(){"a","QrbCl"},
            }, "d QrbCl ya ya NjZQ");
        }

        public IList<string> GenerateSentences(IList<IList<string>> synonyms, string text)
        {
            var synList = new List<ISet<string>>();
            foreach (var synItem in synonyms)
            {
                var firstWord = synItem[0];
                var secondWord = synItem[1];

                var isFind = false;
                for (int i = 0; i < synList.Count; i++)
                {
                    if (synList[i].Contains(firstWord) || synList[i].Contains(secondWord))
                    {
                        synList[i].Add(firstWord);
                        synList[i].Add(secondWord);

                        isFind = true;
                        break;
                    }
                }

                if (isFind) continue;

                synList.Add(new HashSet<string>() { firstWord, secondWord });
            }

            Recursion(text.Split(' '), 0, synList);

            return m_forReturn;
        }

        private IList<string> m_forReturn = new List<string>();

        private void Recursion(string[] textArray, int curIndex, IList<ISet<string>> synList)
        {
            if (curIndex == textArray.Length)
            {
                m_forReturn.Add(string.Join(' ', textArray));
                return;
            }

            var curString = textArray[curIndex];

            string[] loopStr = new string[0];
            for (int i = 0; i < synList.Count; i++)
            {
                if (synList[i].Contains(curString))
                {
                    loopStr = synList[i].OrderBy(w => w, StringComparer.Ordinal).ToArray();
                    break;
                }
            }

            if (!loopStr.Any())
                Recursion(textArray, curIndex + 1, synList);
            else
            {
                for (int j = 0; j < loopStr.Length; j++)
                {
                    textArray[curIndex] = loopStr[j];
                    Recursion(textArray, curIndex + 1, synList);
                }
            }
        }
    }
}
