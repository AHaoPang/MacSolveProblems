using System;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem5385 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int MaxDiff(int num)
        {
            var numChar = num.ToString().ToCharArray();

            var maxChar = numChar.ToArray();
            var c = 'a';
            for (var i = 0; i < maxChar.Length; i++)
            {
                if (maxChar[i] != '9')
                {
                    c = maxChar[i];
                    maxChar[i] = '9';
                    break;
                }
            }
            if (c != 'a')
            {
                for (var i = 0; i < maxChar.Length; i++)
                    if (maxChar[i] == c)
                        maxChar[i] = '9';
            }

            var minChar = numChar.ToArray();
            var mC = 'a';
            if (minChar.Length == 1)
            {
                minChar[0] = '1';
            }
            else if (minChar[0] != '0' && minChar.Count(i => i != '0') == 1)
            {
                minChar[0] = '1';
            }
            else if (minChar.All(c => c == minChar[0]))
            {
                minChar[0] = '1';
                for (var i = 0; i < minChar.Length; i++)
                    minChar[i] = '1';
            }
            else if (minChar[0] != '1')
            {
                mC = minChar[0];
                minChar[0] = '1';
                for (var i = 0; i < minChar.Length; i++)
                    if (minChar[i] == mC)
                        minChar[i] = '1';
            }
            else
            {
                for (var i = 1; i < minChar.Length; i++)
                {
                    if (minChar[i] != '0' && minChar[i] != minChar[0])
                    {
                        mC = minChar[i];
                        minChar[i] = '0';
                        break;
                    }
                }

                for (var i = 1; i < minChar.Length; i++)
                    if (minChar[i] == mC)
                        minChar[i] = '0';
            }

            var maxNum = int.Parse(new string(maxChar).Replace(c, '9'));
            var minNum = int.Parse(new string(minChar));

            return maxNum - minNum;
        }
    }
}
