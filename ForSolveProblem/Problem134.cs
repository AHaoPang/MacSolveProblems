using System;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem134 : IProblem
    {
        public void RunProblem()
        {
            var temp = CanCompleteCircuit(new[] { 1, 2, 3, 4, 5 }, new[] { 3, 4, 5, 1, 2 });
        }

        public int CanCompleteCircuit(int[] gas, int[] cost)
        {
            var total = 0;
            var curValue = 0;
            var curIndex = 0;
            for(var i = 0;i < gas.Length; i++)
            {
                total += gas[i] - cost[i];
                curValue += gas[i] - cost[i];

                if(curValue < 0)
                {
                    curValue = 0;
                    curIndex = i + 1;
                }
            }

            return total >= 0 ? curIndex : -1;
        }

        public int CanCompleteCircuit1(int[] gas, int[] cost)
        {
            var enArr = new List<ItemEntity>();
            for (var i = 0; i < gas.Length; i++)
                enArr.Add(new ItemEntity(i, gas[i] - cost[i]));

            while (enArr.Count > 1)
            {
                if (enArr.First().SumValue < 0)
                {
                    var firstTemp = enArr.First();
                    enArr.RemoveAt(0);
                    enArr.Add(firstTemp);
                }

                var list1 = new List<ItemEntity>();
                list1.Add(enArr.First());
                for (var i = 1; i < enArr.Count; i++)
                {
                    if (list1.Last().SumValue > 0 || list1.Last().SumValue * enArr[i].SumValue >= 0)
                        list1.Last().SumValue += enArr[i].SumValue;
                    else
                        list1.Add(enArr[i]);
                }

                enArr = list1;
            }

            return enArr[0].SumValue >= 0 ? enArr[0].NumIndex : -1;
        }

        private class ItemEntity
        {
            public ItemEntity(int i, int s)
            {
                NumIndex = i;
                SumValue = s;
            }
            public int NumIndex { get; set; }
            public int SumValue { get; set; }

            public override string ToString() => SumValue.ToString();
        }
    }
}
