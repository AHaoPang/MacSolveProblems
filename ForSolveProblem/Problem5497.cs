using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForSolveProblem
{
    public class Problem5497 : IProblem
    {
        public void RunProblem()
        {
            var tem = FindLatestStep(new[] { 3, 5, 1, 2, 4 }, 1);
            if (tem != 4) throw new Exception();

            tem = FindLatestStep(new[] { 3, 1, 5, 4, 2 }, 2);
            if (tem != -1) throw new Exception();

            tem = FindLatestStep(new[] { 1 }, 1);
            if (tem != 1) throw new Exception();

            tem = FindLatestStep(new[] { 2, 1 }, 2);
            if (tem != 2) throw new Exception();

            tem = FindLatestStep(new[] { 1, 2 }, 1);
            if (tem != 1) throw new Exception();
        }

        public int FindLatestStep(int[] arr, int m)
        {
            var orderList = new SortedList<int, int>();

            var res = -1;
            var flagArr = new int[arr.Length + 2];
            var set = new HashSet<int>();
            for (var i = 0; i < arr.Length; i++)
            {
                var arrItem = arr[i];
                flagArr[arrItem] = 1;

                var leftHas = flagArr[arrItem - 1] > 0;
                var rightHas = flagArr[arrItem + 1] > 0;

                if (leftHas || rightHas)
                {
                    if (leftHas && rightHas)
                    {
                        //找到比当前大的第1个,然后修改值
                        var rightMaxkey = FindMaxKey(orderList, arrItem);

                        var leftNode = orderList[arrItem - 1];
                        orderList.Remove(arrItem - 1);
                        if (set.Contains(arrItem - 1))
                            set.Remove(arrItem - 1);
                        
                        orderList[rightMaxkey] += leftNode + 1;

                        if (set.Contains(rightMaxkey))
                            set.Remove(rightMaxkey);
                        else if (orderList[rightMaxkey] == m)
                            set.Add(rightMaxkey);

                    }
                    else if (leftHas)
                    {
                        var leftNode = orderList[arrItem - 1];
                        orderList.Remove(arrItem - 1);
                        if (set.Contains(arrItem - 1))
                            set.Remove(arrItem - 1);

                        orderList[arrItem] = leftNode + 1;
                        if (orderList[arrItem] == m)
                            set.Add(arrItem);
                    }
                    else
                    {
                        //找到比当前位置大的第1个,然后修改值
                        var rightMaxkey = FindMaxKey(orderList, arrItem);
                        orderList[rightMaxkey] += 1;

                        if (set.Contains(rightMaxkey))
                            set.Remove(rightMaxkey);
                        else if (orderList[rightMaxkey] == m)
                            set.Add(rightMaxkey);
                    }
                }
                else
                {
                    orderList[arrItem] = 1;

                    if (orderList[arrItem] == m)
                        set.Add(arrItem);
                }

                if (set.Any())
                    res = i + 1;
            }

            return res;
        }

        private int FindMaxKey(SortedList<int, int> sortList, int curKey)
        {
            var keys = sortList.Keys;
            var l = 0;
            var r = keys.Count - 1;
            while (l <= r)
            {
                var m = l + (r - l) / 2;
                if (keys[m] <= curKey)
                    l = m + 1;
                else
                    r = m - 1;
            }

            return keys[l];
        }
    }
}
