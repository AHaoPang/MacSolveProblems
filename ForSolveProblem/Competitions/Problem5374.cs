using System;
namespace ForSolveProblem
{
    public class Problem5374 : IProblem
    {
        public void RunProblem()
        {
            var temp = GetHappyString(1, 3);

            temp = GetHappyString(1, 4);

            temp = GetHappyString(3, 9);
        }

        public string GetHappyString(int n, int k)
        {
            var oneTotal = (int)Math.Pow(2, n - 1);
            var total = 3 * oneTotal;
            if (total < k) return "";

            var charArray = new[] { 'a', 'b', 'c' };
            var res = new char[n];

            var curIndex = 0;
            if (k <= oneTotal)
                curIndex = 0;
            else if (k <= oneTotal * 2)
                curIndex = 1;
            else
                curIndex = 2;
            res[0] = charArray[curIndex];
            k -= curIndex * oneTotal;

            for (var i = 1; i < n; i++)
            {
                oneTotal /= 2;
                var oneTemp = 0;
                var twoTemp = 0;
                switch (curIndex)
                {
                    case 0:
                            oneTemp = 1;
                        twoTemp = 2;
                        break;

                    case 1:
                        oneTemp = 0;
                        twoTemp = 2;
                        break;

                    case 2:
                        oneTemp = 0;
                        twoTemp = 1;
                        break;
                }

                if (k <= oneTotal)
                    curIndex = oneTemp;
                else
                {
                    curIndex = twoTemp;
                    k -= oneTotal;
                }

                res[i] = charArray[curIndex];
            }

            return new string(res);
        }
    }
}
