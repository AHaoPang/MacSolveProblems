using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem5325 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int NumberOfSubstrings(string s)
        {
            var charCountArray = new int[3];
            var queueTemp = new Queue<char>();

            var forReturn = 0;
            for (var i = 0; i < s.Length; i++)
            {
                var curChar = s[i];

                queueTemp.Enqueue(curChar);
                charCountArray[curChar - 'a']++;

                while (charCountArray.All(arrItem => arrItem != 0))
                {
                    forReturn += s.Length - i;

                    var popChar = queueTemp.Dequeue();
                    charCountArray[popChar - 'a']--;
                }
            }

            return forReturn;
        }
    }
}
