using System;
using System.Collections.Generic;
using System.Text;

namespace ForSolveProblem
{
    public class Problem1528 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public string RestoreString(string s, int[] indices)
        {
            var resArr = new char[s.Length];
            for (var i = 0; i < indices.Length; i++)
            {
                var v = indices[i];
                resArr[v] = s[i];
            }

            return new string(resArr);
        }
    }
}
