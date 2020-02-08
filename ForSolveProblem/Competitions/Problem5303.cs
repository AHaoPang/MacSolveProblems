using System;
using System.Collections.Generic;
using System.Text;

namespace ForSolveProblem
{
    public class Problem5303 : IProblem
    {
        public void RunProblem()
        {
            var temp = FreqAlphabets("10#11#12");
            if (temp != "jkab") throw new Exception();

            temp = FreqAlphabets("1326#");
            if (temp != "acz") throw new Exception();

            temp = FreqAlphabets("25#");
            if (temp != "y") throw new Exception();

            temp = FreqAlphabets("12345678910#11#12#13#14#15#16#17#18#19#20#21#22#23#24#25#26#");
            if (temp != "abcdefghijklmnopqrstuvwxyz") throw new Exception();
        }

        public string FreqAlphabets(string s)
        {
            var dicTemp = new Dictionary<string, string>();
            for (int i = 0; i < 9; i++)
                dicTemp[$"{i + 1}"] = ((char)('a' + i)).ToString();

            for (int j = 9; j < 26; j++)
                dicTemp[$"{j + 1}#"] = ((char)('a' + j)).ToString();

            var forReturn = new StringBuilder();
            for (int k = 0; k < s.Length; k++)
            {
                if (k + 2 < s.Length)
                {
                    var tempStr = s.Substring(k, 3);
                    if (dicTemp.ContainsKey(tempStr))
                    {
                        forReturn.Append(dicTemp[tempStr]);
                        k += 2;
                        continue;
                    }
                }

                forReturn.Append(dicTemp[s[k].ToString()]);
            }

            return forReturn.ToString();
        }
    }
}
