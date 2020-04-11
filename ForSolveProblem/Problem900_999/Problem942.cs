using System;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem942 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int[] DiStringMatch(string S)
        {
            var res = new List<int>(S.Length + 1);
            var minValue = 0;
            var maxValue = S.Length;
            foreach (var sItem in S)
            {
                if (sItem == 'I')
                    res.Add(minValue++);
                else
                    res.Add(maxValue--);
            }
            res.Add(minValue);

            return res.ToArray();
        }

        public int[] DiStringMatch1(string S)
        {
            var sList = S.ToList();

            if (sList.Last() == 'I')
                sList.Add('D');
            else
                sList.Add('I');

            var res = new int[sList.Count];

            var i = 0;
            for (var l = 0; l < sList.Count; l++)
                if (sList[l] == 'I')
                    res[l] = i++;

            for (var r = sList.Count - 1; r >= 0; r--)
                if (sList[r] == 'D')
                    res[r] = i++;

            return res;
        }
    }
}
