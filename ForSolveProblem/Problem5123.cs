using System;
using System.Collections;
using System.Collections.Generic;

namespace ForSolveProblem
{
    public class Problem5123 : IProblem
    {
        public void RunProblem()
        {
            var temp = new CombinationIterator("abc", 2);

        }

        public class CombinationIterator
        {
            private IList<string> m_innerStrArray;
            private int m_innerIndex;

            public CombinationIterator(string characters, int combinationLength)
            {
                m_innerStrArray = new List<string>();
                m_innerIndex = 0;
                Recursion(characters, 0, combinationLength, new char[combinationLength], 0);
            }

            private void Recursion(string characters, int startIndex, int count, char[] rightNowArray, int curIndex)
            {
                if (curIndex == count)
                {
                    m_innerStrArray.Add(new string(rightNowArray));
                    return;
                }

                for (int i = startIndex; i <= characters.Length - (count - curIndex); i++)
                {
                    rightNowArray[curIndex] = characters[i];
                    Recursion(characters, i + 1, count, rightNowArray, curIndex + 1);
                }
            }

            public string Next()
            {
                return m_innerStrArray[m_innerIndex++];
            }

            public bool HasNext()
            {
                return m_innerIndex < m_innerStrArray.Count;
            }
        }
    }
}
