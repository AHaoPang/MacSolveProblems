using System;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem744 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public char NextGreatestLetter(char[] letters, char target)
        {
            var charSet = new HashSet<char>(letters);
            for (var i = 1; i < 26; i++)
            {
                var targetChar = (char)(target + i);
                if (targetChar > 'z')
                    targetChar = (char)('a' + (targetChar - 'z' - 1));

                if (charSet.Contains(targetChar))
                    return targetChar;
            }

            return 'a';
        }
    }
}
