using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForSolveProblem
{
    public class Problem824 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public string ToGoatLatin(string S)
        {
            var res = new StringBuilder();
            var charSet = new HashSet<char> { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
            var wordArray = S.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            for (var i = 0; i < wordArray.Length; i++)
            {
                var strTem = string.Join("", Enumerable.Repeat('a', i + 1));
                if (charSet.Contains(wordArray[i][0]))
                    res.Append($"{wordArray[i]}ma{strTem} ");
                else
                    res.Append($"{wordArray[i].Substring(1)}{wordArray[i][0]}ma{strTem} ");
            }

            return res.ToString().TrimEnd();
        }
    }
}
