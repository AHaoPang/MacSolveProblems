using System;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem5298 : IProblem
    {
        public void RunProblem()
        {
            var temp = IsSolvable(new string[] { "SEND", "MORE" }, "MONEY");
            if (temp != true) throw new Exception();

            temp = IsSolvable(new string[] { "SIX", "SEVEN", "SEVEN" }, "TWENTY");
            if (temp != true) throw new Exception();

            temp = IsSolvable(new string[] { "THIS", "IS", "TOO" }, "FUNNY");
            if (temp != true) throw new Exception();

            temp = IsSolvable(new string[] { "LEET", "CODE" }, "POINT");
            if (temp != false) throw new Exception();
        }

        public bool IsSolvable(string[] words, string result)
        {
            m_words = words;
            m_result = result;
            m_charCount = words.Length + 1;

            var otherChar = new HashSet<char>();
            var headChar = new HashSet<char>();
            var tailChar = new HashSet<char>();

            foreach (var wordItem in words)
            {
                if (wordItem.Length > 1)
                    headChar.Add(wordItem[0]);

                tailChar.Add(wordItem.Last());

                foreach (var charItem in wordItem)
                    otherChar.Add(charItem);
            }

            if (result.Length > 1)
                headChar.Add(result[0]);
            tailChar.Add(result.Last());

            foreach (var resultItem in result)
                otherChar.Add(resultItem);

            var newLIst = tailChar.ToList();
            foreach (var otherItem in otherChar)
                if (!tailChar.Contains(otherItem)) newLIst.Add(otherItem);

            return Recursive(new Dictionary<char, int>(), headChar, newLIst, 0, new bool[10]);
        }

        public bool Recursive(Dictionary<char, int> charDic, HashSet<char> headSet, IList<char> otherSet, int curPos, bool[] visited)
        {
            if (curPos == otherSet.Count)
                return IsOk(charDic);

            if (m_charCount == curPos)
            {
                var result = IsOtherOk(charDic);
                if (result == false) return false;
            }

            var curChar = otherSet[curPos];
            for (int i = 0; i <= 9; i++)
            {
                if (i == 0 && headSet.Contains(curChar)) continue;
                if (visited[i]) continue;

                charDic[curChar] = i;
                visited[i] = true;

                var result = Recursive(charDic, headSet, otherSet, curPos + 1, visited);
                if (result) return true;

                charDic[curChar] = -1;
                visited[i] = false;
            }

            return false;
        }

        private string[] m_words;
        private string m_result;
        private int m_charCount;

        private bool IsOk(Dictionary<char, int> charDic)
        {
            var sumTemp = 0;

            foreach (var wordItem in m_words)
                sumTemp += TransNum(wordItem, charDic);

            var resultNum = TransNum(m_result, charDic);
            return resultNum == sumTemp;
        }

        private bool IsOtherOk(Dictionary<char, int> charDic)
        {
            var sumTemp = 0;
            foreach (var wordItem in m_words)
                sumTemp += charDic[wordItem.Last()];

            sumTemp %= 10;

            return sumTemp == charDic[m_result.Last()];
        }

        private int TransNum(string str, Dictionary<char, int> charDic)
        {
            var curNum = 0;
            foreach (var strItem in str)
                curNum = curNum * 10 + charDic[strItem];

            return curNum;
        }
    }
}
