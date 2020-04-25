using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem5389 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public IList<IList<string>> DisplayTable(IList<IList<string>> orders)
        {
            var foodSet = new HashSet<string>();
            var tableArr = new Dictionary<string, int>[501];

            foreach (var orderItem in orders)
            {
                var foodName = orderItem[2];
                foodSet.Add(foodName);

                var t = int.Parse(orderItem[1]);
                if (tableArr[t] == null)
                    tableArr[t] = new Dictionary<string, int>();

                if (!tableArr[t].ContainsKey(foodName))
                    tableArr[t][foodName] = 0;

                tableArr[t][foodName]++;
            }

            var res = new List<IList<string>>();

            var titalList = new List<string>();
            titalList.Add("Table");
            var orArray = foodSet.OrderBy(i => i, StringComparer.Ordinal).ToArray();
            titalList.AddRange(orArray);
            res.Add(titalList);

            for (var i = 1; i < tableArr.Length; i++)
            {
                if (tableArr[i] == null) continue;

                var listTemp = new List<string>();
                listTemp.Add(i.ToString());

                for (var j = 0; j < orArray.Length; j++)
                {
                    var foodName = orArray[j];
                    if (!tableArr[i].ContainsKey(foodName))
                        listTemp.Add("0");
                    else
                        listTemp.Add(tableArr[i][foodName].ToString());
                }

                res.Add(listTemp);
            }

            return res;
        }
    }
}
