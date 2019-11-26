using System;
using System.Collections.Generic;

namespace ForSolveProblem
{
    public class Problem1207 : IProblem
    {
        public void RunProblem()
        {
            var temp = UniqueOccurrences(new int[] { 1, 2, 2, 1, 1, 3 });
            if (temp != true) throw new Exception();

            temp = UniqueOccurrences(new int[] { 1, 2 });
            if (temp != false) throw new Exception();

            temp = UniqueOccurrences(new int[] { -3, 0, 1, -3, 1, 1, 1, -3, 10, 0 });
            if (temp != true) throw new Exception();
        }

        public bool UniqueOccurrences(int[] arr)
        {
            var numCountArray = new int[2001];
            foreach (var arrItem in arr)
                numCountArray[arrItem + 1000]++;

            var countArray = new int[1001];
            foreach (var arrayItem in numCountArray)
            {
                if (arrayItem == 0) continue;
                if (countArray[arrayItem] != 0) return false;
                countArray[arrayItem] = 1;
            }

            return true;
        }

        public bool UniqueOccurrences1(int[] arr)
        {
            var dic = new Dictionary<int, int>(arr.Length);
            foreach (var arrItem in arr)
            {
                if (!dic.ContainsKey(arrItem)) dic[arrItem] = 0;
                dic[arrItem]++;
            }

            var hashSet = new HashSet<int>(dic.Count);
            foreach (var dicItem in dic)
            {
                if (hashSet.Contains(dicItem.Value)) return false;
                hashSet.Add(dicItem.Value);
            }

            return true;
        }
    }
}
