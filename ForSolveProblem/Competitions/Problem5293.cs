using System;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem5293 : IProblem
    {
        public void RunProblem()
        {
            var temp = MaxFreq("aababcaab", 2, 3, 4);
            if (temp != 2) throw new Exception();

            temp = MaxFreq("aaaa", 1, 3, 3);
            if (temp != 2) throw new Exception();

            temp = MaxFreq("aabcabcab", 2, 2, 3);
            if (temp != 3) throw new Exception();

            temp = MaxFreq("abcde", 2, 3, 3);
            if (temp != 0) throw new Exception();
        }

        public int MaxFreq(string s, int maxLetters, int minSize, int maxSize)
        {
            var window = new Window();
            foreach (var sItem in s)
                window.GetChar(sItem, maxLetters, minSize, maxSize);

            return window.GetResult();
        }

        public class Window
        {
            private Dictionary<string, int> m_innerCount;
            private Dictionary<char, int> m_innerWordCount;
            private Queue<char> m_innerQueue;

            public Window()
            {
                m_innerCount = new Dictionary<string, int>();
                m_innerWordCount = new Dictionary<char, int>();
                m_innerQueue = new Queue<char>();
            }

            public void GetChar(char c, int maxLetters, int minSize, int maxSize)
            {
                m_innerQueue.Enqueue(c);
                if (!m_innerWordCount.ContainsKey(c)) m_innerWordCount[c] = 0;
                m_innerWordCount[c]++;

                if (m_innerQueue.Count < minSize) return;

                while (m_innerWordCount.Count > maxLetters || m_innerQueue.Count > maxSize)
                {
                    var popChar = m_innerQueue.Dequeue();
                    m_innerWordCount[popChar]--;
                    if (m_innerWordCount[popChar] == 0) m_innerWordCount.Remove(popChar);
                }

                if (m_innerQueue.Count < minSize) return;

                var curString = new string(m_innerQueue.ToArray());
                if (!m_innerCount.ContainsKey(curString)) m_innerCount[curString] = 0;
                m_innerCount[curString]++;

                var queueCount = m_innerQueue.Count;
                var initIndex = 1;
                while (queueCount > minSize)
                {
                    var newStr = curString.Substring(initIndex++);
                    if (!m_innerCount.ContainsKey(newStr)) m_innerCount[newStr] = 0;
                    m_innerCount[newStr]++;

                    queueCount--;
                }
            }

            public int GetResult()
            {
                if (!m_innerCount.Any()) return 0;

                return m_innerCount.Max(i => i.Value);
            }
        }
    }
}
