using System;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem849 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int MaxDistToClosest(int[] seats)
        {
            var first1Index = Array.IndexOf(seats, 1);
            var last1Index = Array.LastIndexOf(seats, 1);

            var res = Math.Max(first1Index, seats.Length - last1Index - 1);

            var lIndex = first1Index;
            for (var rIndex = lIndex + 1; rIndex <= last1Index; rIndex++)
            {
                if (seats[rIndex] == 1)
                {
                    res = Math.Max(res, GetDistance(lIndex, rIndex));
                    lIndex = rIndex;
                }
            }

            return res;
        }

        public int MaxDistToClosest2(int[] seats)
        {
            var res = 0;

            var lIndex = -1;
            var rIndex = 0;
            for (; rIndex < seats.Length; rIndex++)
            {
                if (seats[rIndex] == 1)
                {
                    if (lIndex == -1)
                        res = Math.Max(res, rIndex);
                    else
                        res = Math.Max(res, GetDistance(lIndex, rIndex));

                    lIndex = rIndex;
                }
            }

            res = Math.Max(res, seats.Length - lIndex - 1);

            return res;
        }

        private int GetDistance(int l, int r)
        {
            var dist = r - l - 1;
            var lon = dist / 2;
            if ((dist & 1) == 1)
                lon++;

            return lon;
        }

        public int MaxDistToClosest1(int[] seats)
        {
            var copyArray = new int[seats.Length];
            seats.CopyTo(copyArray, 0);

            var distance = -1;
            for (var i = 0; i < seats.Length; i++)
            {
                if (seats[i] == 1)
                {
                    distance = 0;
                    continue;
                }

                if (distance != -1)
                {
                    distance++;
                    copyArray[i] = distance;
                }
            }

            var reverseDistance = -1;
            for (var j = seats.Length - 1; j >= 0; j--)
            {
                if (seats[j] == 1)
                {
                    reverseDistance = 0;
                    continue;
                }

                if (reverseDistance != -1)
                {
                    reverseDistance++;
                    if (copyArray[j] == 0 || copyArray[j] > reverseDistance)
                        copyArray[j] = reverseDistance;
                }
            }

            return copyArray.Max();
        }
    }
}
