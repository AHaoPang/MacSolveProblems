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
            var temp = GenerateSentences(new List<IList<string>>()
            {
                new List<string>(){"happy","joy"},
                new List<string>(){"sad","sorrow"},
                new List<string>(){"joy","cheerful"},
            }, "I am happy today but was sad yesterday");

            temp = GenerateSentences(new List<IList<string>>()
            {
                new List<string>(){"a","QrbCl"},
            }, "d QrbCl ya ya NjZQ");
        }

        public IList<string> GenerateSentences(IList<IList<string>> synonyms, string text)
        {
            var textSplitArray = text.Split(' ');

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

            Recursion(textSplitArray, 0, synList);

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
