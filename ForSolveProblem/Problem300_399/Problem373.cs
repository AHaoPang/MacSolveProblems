using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem373 : IProblem
    {
        public void RunProblem()
        {
            int[] nums1 = new int[] { -476570184, -423568801, -385585840, -375390924, -364630569, -359795128, -281872968, -126410430, -75677925, -54214495, -49178055, -32637211, -32198215, 3413177, 19045759, 62248526, 67551536, 113606647, 155411580, 164755463, 164781059, 203133270, 277305105, 284913246, 285973110, 296436629, 325431544, 357294459, 378678394, 399786157 };
            int[] nums2 = new int[] { -408663357, -404578641, -376531700, -311642519, -294905976, -232001207, -183530032, -141524508, -115652480, -70696522, -63386299, -54656543, -32316999, 29714175, 33993996, 45020708, 62165363, 84210823, 93905151, 102177224, 209285622, 288668099, 328300713, 338684779, 342861859, 384940859, 408019604, 410097843, 458721542, 475395296 };
            int k = 1000;

            var temp = KSmallestPairs(nums1, nums2, k);
        }

        public IList<int[]> KSmallestPairs(int[] nums1, int[] nums2, int k)
        {
            /*
             * 采用位置标记法，依次找到最小的位置
             * 
             * 数组1，相当于一个赛道的多名队员
             * 数组2，相当于每个队员的活动范围
             * 
             * 每轮都是要抉择出一个或者几个最佳组合
             * 
             * 时间复杂度：O(k*n)
             * 空间复杂度：O(n)，因为额外维护了一个一维数组
             */

            var forReturn = new List<int[]>();

            int num1Length = nums1.Length;
            int num2Length = nums2.Length;
            if (num1Length == 0 || num2Length == 0) return forReturn;

            int[] posArrayTemp = new int[num1Length];

            while (forReturn.Count < k)
            {
                int minPosx = -1;
                int minNum1 = 0;
                int minNum2 = 0;
                for (int i = 0; i < num1Length; i++)
                {
                    if (posArrayTemp[i] < num2Length && (minPosx == -1 || nums1[i] + nums2[posArrayTemp[i]] < minNum1 + minNum2))
                    {
                        minNum1 = nums1[i];
                        minNum2 = nums2[posArrayTemp[i]];
                        minPosx = i;
                    }
                }

                if (minPosx == -1) break;

                forReturn.Add(new int[] { nums1[minPosx], nums2[posArrayTemp[minPosx]] });
                posArrayTemp[minPosx]++;
            }

            return forReturn;
        }

        public IList<int[]> KSmallestPairsV2(int[] nums1, int[] nums2, int k)
        {
            /*
             * 实现思路：
             * 1.枚举出所有的组合；
             * 2.收集的时候就做排序；
             * 3.将结果中的前K个返回；
             * 
             * 时间复杂度：O(m*n)，以为要找出所有可能的组合
             * 空间复杂度：O(n*n)，要存放所有可能的组合
             * 
             * 本代码亮点：使用了“排序字典”，那么在数据插入的时候，效率会比较高，大概是O(logn)，内部的实现机制是使用了“红黑树”
             * 但是如何能不用遍历出所有的组合情况，就会更好了
             */

            SortedDictionary<int, List<Tuple<int, int>>> sDic = new SortedDictionary<int, List<Tuple<int, int>>>();

            for (int i = 0; i < Math.Min(nums1.Length, k); i++)
            {
                for (int j = 0; j < Math.Min(nums2.Length, k); j++)
                {
                    var key = nums1[i] + nums2[j];

                    if (!sDic.ContainsKey(key))
                        sDic[key] = new List<Tuple<int, int>>();

                    sDic[key].Add(Tuple.Create(nums1[i], nums2[j]));
                }
            }

            IList<int[]> forReturn = new List<int[]>();

            foreach (var dicItem in sDic)
            {
                foreach (var dicValueItem in dicItem.Value)
                {
                    if (forReturn.Count >= k) break;

                    forReturn.Add(new int[] { dicValueItem.Item1, dicValueItem.Item2 });
                }

                if (forReturn.Count >= k) break;
            }

            return forReturn;
        }
    }
}
