using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem599 : IProblem
    {
        public void RunProblem()
        {
            var temp = FindRestaurant(new string[] { "Shogun", "Tapioca Express", "Burger King", "KFC" }, new string[] { "Piatti", "The Grill at Torrey Pines", "Hungry Hunter Steakhouse", "Shogun" });

            temp = FindRestaurant(new string[] { "Shogun", "Tapioca Express", "Burger King", "KFC" }, new string[] { "KFC", "Shogun", "Burger King" });
        }

        public string[] FindRestaurant(string[] list1, string[] list2)
        {
            /*
             * 寻找两个列表相同项索引最小和的项
             * 思路：
             *  1.已一个列表为基准，去参照另一个列表
             *  
             * 时间复杂度：O(n+m)
             * 空间复杂度：O(n)
             */

            var list1Dic = new Dictionary<string, int>();
            for (int i = 0; i < list1.Length; i++) list1Dic[list1[i]] = i;

            var minIndexSum = int.MaxValue;
            var forReturn = new List<string>();
            for (int j = 0; j < list2.Length; j++)
            {
                var stringItem = list2[j];
                if (!list1Dic.ContainsKey(stringItem)) continue;

                var indexSumTemp = list1Dic[stringItem] + j;
                if (minIndexSum < indexSumTemp) continue;

                if (minIndexSum > indexSumTemp)
                {
                    minIndexSum = indexSumTemp;
                    forReturn.Clear();
                }

                forReturn.Add(stringItem);
            }

            return forReturn.ToArray();
        }
    }
}
