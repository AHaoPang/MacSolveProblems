using System;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem5273 : IProblem
    {
        public void RunProblem()
        {
            var temp = SuggestedProducts(new string[] { "mobile", "mouse", "moneypot", "monitor", "mousepad" }, "mouse");

            temp = SuggestedProducts(new string[] { "havana" }, "havana");

            temp = SuggestedProducts(new string[] { "bags", "baggage", "banner", "box", "cloths" }, "bags");

            temp = SuggestedProducts(new string[] { "havana" }, "tatiana");
        }

        public IList<IList<string>> SuggestedProducts(string[] products, string searchWord)
        {
            var newArray = products.OrderBy(i => i, StringComparer.Ordinal).ToList();

            var forReturn = new List<IList<string>>();
            for (int i = 0; i < searchWord.Length; i++)
            {
                var curChar = searchWord[i];

                var nextArray = new List<string>();
                for (int j = 0; j < newArray.Count; j++)
                {
                    var curStr = newArray[j];

                    if (i >= curStr.Length || curChar != curStr[i]) continue;

                    nextArray.Add(curStr);
                }

                forReturn.Add(nextArray.Take(3).ToList());
                newArray = nextArray;
            }

            return forReturn;
        }
    }
}
