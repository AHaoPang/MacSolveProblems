using System;
using System.Collections.Generic;
using System.Text;

namespace ForSolveProblem
{
    public class Problem804 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int UniqueMorseRepresentations(string[] words)
        {
            if (m_map == null)
                m_map = GetMap();

            var strSet = new HashSet<string>();
            foreach (var wordItem in words)
            {
                var s = new StringBuilder();
                foreach (var c in wordItem)
                    s.Append(m_map[c - 'a']);

                strSet.Add(s.ToString());
            }

            return strSet.Count;
        }

        private static string[] m_map;

        private string[] GetMap()
        {
            return new[]
            {
                ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.."
            };
        }
    }
}
