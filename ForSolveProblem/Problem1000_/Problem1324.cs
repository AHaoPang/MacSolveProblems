using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForSolveProblem
{
    public class Problem1324 : IProblem
    {
        public void RunProblem()
        {
            var temp = PrintVertically("HOW ARE YOU");
            if (!ProblemHelper.ArrayIsEqual(temp.ToArray(), new string[] { "HAY", "ORO", "WEU" }))
                throw new Exception();

            temp = PrintVertically("TO BE OR NOT TO BE");
            if (!ProblemHelper.ArrayIsEqual(temp.ToArray(), new string[] { "TBONTB", "OEROOE", "   T" }))
                throw new Exception();

            temp = PrintVertically("CONTEST IS COMING");
            if (!ProblemHelper.ArrayIsEqual(temp.ToArray(), new string[] { "CIC", "OSO", "N M", "T I", "E N", "S G", "T" }))
                throw new Exception();

        }

        public IList<string> PrintVertically(string s)
        {
            var wordArray = s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var maxLength = wordArray.Max(i => i.Length);

            var forReturn = new List<IList<char>>();
            for (int i = 0; i < maxLength; i++)
                forReturn.Add(new List<char>());

            foreach (var wordItem in wordArray)
            {
                var i = 0;
                for (; i < wordItem.Length; i++)
                    forReturn[i].Add(wordItem[i]);

                for (; i < maxLength; i++)
                    forReturn[i].Add(' ');
            }

            return forReturn.Select(i => new string(i.ToArray()).TrimEnd()).ToList();
        }
    }
}
