using System;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem5390 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int MinNumberOfFrogs(string croakOfFrogs)
        {
            var arr = new int[5];

            var res = -1;
            foreach (var c in croakOfFrogs)
            {
                switch (c)
                {
                    case 'c':
                        arr[0]++;
                        break;

                    case 'r':
                        arr[1]++;
                        break;

                    case 'o':
                        arr[2]++;
                        break;

                    case 'a':
                        arr[3]++;
                        break;

                    case 'k':
                        arr[4]++;

                        res = Math.Max(res, arr[0] - arr[4] + 1);
                        break;
                }

                for (var i = 0; i < arr.Length - 1; i++)
                {
                    if (arr[i + 1] > arr[i])
                        return -1;
                }
            }

            var n = arr[0];
            if (arr.Any(i => i != n)) return -1;

            return res;
        }
    }
}
