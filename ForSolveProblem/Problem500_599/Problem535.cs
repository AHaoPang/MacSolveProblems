using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem535 : IProblem
    {
        public void RunProblem()
        {
            var temp = new Codec();
            var encodeStr = temp.encode("https://leetcode.com/problems/design-tinyurl");
            var temp2 = temp.decode(encodeStr);
        }

        public class Codec
        {
            private long id;
            private Dictionary<long, string> idToUrl = new Dictionary<long, string>();
            private string domainHead = "http://tinyurl.com/";

            // Encodes a URL to a shortened URL
            public string encode(string longUrl)
            {
                idToUrl[id] = longUrl;
                id++;

                return domainHead + (id - 1).ToString();
            }

            // Decodes a shortened URL to its original URL.
            public string decode(string shortUrl)
            {
                var idStr = shortUrl.Replace(domainHead, "");

                long id = 0;
                if (!long.TryParse(idStr, out id)) return "";
                if (!idToUrl.ContainsKey(id)) return "";

                return idToUrl[id];
            }
        }
    }
}
