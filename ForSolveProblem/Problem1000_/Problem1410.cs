using System;
using System.Collections.Generic;

namespace ForSolveProblem
{
    public class Problem1410 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public string EntityParser(string text)
        {
            return text
                .Replace("&frasl;", "/")
                .Replace("&quot;", "\"")
                .Replace("&apos;", "\'")
                .Replace("&amp;", "&")
                .Replace("&gt;", ">")
                .Replace("&lt;", "<");
        }

        public string EntityParser1(string text)
        {
            var dic = new Dictionary<string, char>()
            {
                {"&frasl;",'/' },
                {"&quot;",'"' },
                {"&apos;",'\'' },
                {"&amp;",'&' },
                {"&gt;",'>' },
                {"&lt;",'<' },
            };

            var resChar = new List<char>(text.Length);
            for (var i = 0; i < text.Length; i++)
            {
                if (text[i] != '&')
                {
                    resChar.Add(text[i]);
                    continue;
                }

                var str = "";
                if (i + 3 < text.Length && text[i + 3] == ';')
                    str = text.Substring(i, 4);
                else if (i + 4 < text.Length && text[i + 4] == ';')
                    str = text.Substring(i, 5);
                else if (i + 5 < text.Length && text[i + 5] == ';')
                    str = text.Substring(i, 6);
                else if (i + 6 < text.Length && text[i + 6] == ';')
                    str = text.Substring(i, 7);

                if (dic.ContainsKey(str))
                {
                    i += str.Length - 1;
                    resChar.Add(dic[str]);
                    continue;
                }

                resChar.Add(text[i]);
            }

            return new string(resChar.ToArray());
        }
    }
}
