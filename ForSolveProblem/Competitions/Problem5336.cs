using System;
using System.Text;

namespace ForSolveProblem
{
    public class Problem5336 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public string SortString(string s)
        {
            var charArray = new int[26];
            foreach (var sItem in s)
                charArray[sItem - 'a']++;

            var forReturn = new StringBuilder(s.Length);
            var count = 0;
            while (count < s.Length)
            {
                for (var i = 0; i < charArray.Length; i++)
                {
                    if (charArray[i] == 0) continue;

                    var curChar = (char)(i + 'a');
                    forReturn.Append(curChar);
                    count++;

                    charArray[i]--;
                }

                for (var i = charArray.Length - 1; i >= 0; i--)
                {
                    if (charArray[i] == 0) continue;

                    var curChar = (char)(i + 'a');
                    forReturn.Append(curChar);
                    count++;

                    charArray[i]--;
                }
            }

            return forReturn.ToString();
        }
    }
}
