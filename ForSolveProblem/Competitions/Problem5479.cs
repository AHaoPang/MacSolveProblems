using System;
using System.Collections.Generic;

namespace ForSolveProblem
{
    public class Problem5479 : IProblem
    {
        public Problem5479()
        {
        }

        public void RunProblem()
        {
            var temp = ThousandSeparator(987);
            if (temp != "987") throw new Exception();

            temp = ThousandSeparator(1234);
            if (temp != "1.234") throw new Exception();

            temp = ThousandSeparator(123456789);
            if (temp != "123.456.789") throw new Exception();

            temp = ThousandSeparator(0);
            if (temp != "0") throw new Exception();
        }

        public string ThousandSeparator(int n)
        {
            var str = n.ToString();

            var res = new List<char>();
            var c = 0;
            for (var j = str.Length - 1; j >= 0; j--)
            {
                res.Add(str[j]);

                c++;
                if (c == 3)
                {
                    c = 0;
                    res.Add('.');
                }
            }

            res.Reverse();
            return new string(res.ToArray()).TrimStart('.');
        }
    }
}
