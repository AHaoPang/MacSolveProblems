using System;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem5337 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int FindTheLongestSubstring(string s)
        {
            var forReturn = 0;

            var allStates = (int)Math.Pow(2, 5);
            var stateArray = Enumerable.Repeat(int.MinValue, allStates).ToArray();
            stateArray[0] = -1;

            var curState = 0;
            for (var i = 0; i < s.Length; i++)
            {
                var sItem = s[i];
                switch (sItem)
                {
                    case 'a':
                        curState ^= 1;
                        break;

                    case 'e':
                        curState ^= 2;
                        break;

                    case 'i':
                        curState ^= 4;
                        break;

                    case 'o':
                        curState ^= 8;
                        break;

                    case 'u':
                        curState ^= 16;
                        break;
                }

                if (stateArray[curState] == int.MinValue)
                    stateArray[curState] = i;
                else
                    forReturn = Math.Max(forReturn, i - stateArray[curState]);
            }

            return forReturn;
        }
    }
}
