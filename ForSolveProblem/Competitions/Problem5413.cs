using System;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem5413 : IProblem
    {
        public void RunProblem()
        {
            var temp = ArrangeWords("Keep calm and code on");

        }

        public string ArrangeWords(string text)
        {
            var strArr = text
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .OrderBy(i => i.Length)
                .Select(i => i.ToLower())
                .ToArray();

            var newWord = strArr[0].ToArray();
            if (newWord[0] >= 'a')
                newWord[0] = (char)(newWord[0] - ('a' - 'A'));
            strArr[0] = new string(newWord);

            return string.Join(" ", strArr);
        }
    }
}
