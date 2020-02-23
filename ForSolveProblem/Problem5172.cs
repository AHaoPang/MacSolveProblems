using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForSolveProblem
{
    public class Problem5172 : IProblem
    {
        public void RunProblem()
        {
            var temp = LargestMultipleOfThree(new int[] { 8, 1, 9 });
            if (temp != "981") throw new Exception();

            var temp2 = LargestMultipleOfThree(new int[] { 8, 6, 7, 1, 0 });
            if (temp2 != "8760") throw new Exception();

            temp = LargestMultipleOfThree(new int[] { 0, 0, 0, 0 });
            if (temp != "0") throw new Exception();

            var temp3 = LargestMultipleOfThree(new int[] { 5, 8 });
            if (temp3 != "") throw new Exception();
        }

        public string LargestMultipleOfThree(int[] digits)
        {
            var numArray = new int[10];
            foreach (var digitItem in digits)
                numArray[digitItem]++;

            var resultNum = 0;
            for (var i = 0; i < numArray.Length; i++)
            {
                resultNum += numArray[i] * i;
                resultNum %= 3;
            }

            var forReturn = "";
            if (resultNum == 0)
            {
                //全部组成的结果
                forReturn = GetNumStr(numArray);
            }
            else if (resultNum == 1)
            {
                //余数为 1

                //余数为 1 的取1 个,没有的话,余数为 2 的取 2 个
                var r = GetNum(numArray, 1, 1);
                if (r.Item1)
                {
                    foreach (var itemNum in r.Item2)
                        numArray[itemNum]--;

                    forReturn = GetNumStr(numArray);
                }
                else
                {
                    r = GetNum(numArray, 2, 2);
                    if (r.Item1)
                    {
                        foreach (var itemNum in r.Item2)
                            numArray[itemNum]--;

                        forReturn = GetNumStr(numArray);
                    }
                }
            }
            else
            {
                //余数为 2

                //余数为 2 的取 1 个,没有的话,余数为 1 的取 2 个
                var r = GetNum(numArray, 2, 1);
                if (r.Item1)
                {
                    foreach (var itemNum in r.Item2)
                        numArray[itemNum]--;

                    forReturn = GetNumStr(numArray);
                }
                else
                {
                    r = GetNum(numArray, 1, 2);
                    if (r.Item1)
                    {
                        foreach (var itemNum in r.Item2)
                            numArray[itemNum]--;

                        forReturn = GetNumStr(numArray);
                    }
                }
            }

            if(forReturn.Length > 0)
            {
                var f = forReturn.TrimStart('0');
                if (f.Length == 0)
                    f = "0";

                return f;
            }

            return forReturn;
        }

        private string GetNumStr(int[] numArray)
        {
            var stringbuilder = new StringBuilder();
            for (var i = 9; i >= 0; i--)
            {
                var numCount = numArray[i];
                if (numCount == 0) continue;

                var s = string.Join("", Enumerable.Repeat(i.ToString(), numCount));
                stringbuilder.Append(s);
            }

            return stringbuilder.ToString();
        }

        private Tuple<bool, List<int>> GetNum(int[] numArray, int i, int count)
        {
            var forReturnNumArray = new List<int>();
            for (; i < 9; i += 3)
            {
                if (numArray[i] == 0) continue;
                if (forReturnNumArray.Count >= count) break;

                var curCount = numArray[i];
                var minCount = Math.Min(count, curCount);
                for (var j = 0; j < minCount; j++)
                    forReturnNumArray.Add(i);
            }

            if (forReturnNumArray.Count < count)
                return Tuple.Create<bool, List<int>>(false, null);

            return Tuple.Create(true, forReturnNumArray.Take(count).ToList());
        }
    }
}
