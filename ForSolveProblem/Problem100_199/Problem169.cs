using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem169 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int MajorityElement(int[] nums)
        {
            var initNum = nums.First();
            var numCount = 0;
            foreach (var numItem in nums)
            {
                if (initNum == numItem)
                    numCount++;
                else if (numCount == 0)
                {
                    initNum = numItem;
                    numCount++;
                }
                else
                    numCount--;
            }

            return initNum;
        }

        public int MajorityElement1(int[] nums)
        {
            if (nums.Length == 1 || nums.Length == 2) return nums.First();

            var arr1 = nums.Take(nums.Length / 2).ToArray();
            var arr2 = nums.Skip(nums.Length / 2).Take(nums.Length - nums.Length / 2).ToArray();

            var oneMax = MajorityElement(arr1);
            var twoMax = MajorityElement(arr2);

            if (oneMax == twoMax)
                return oneMax;
            else
                return nums.Count(i => i == oneMax) > nums.Count(j => j == twoMax) ? oneMax : twoMax;
        }

        public int Way1(int[] nums)
        {
            var count = nums.Length;

            var newArray = nums.OrderBy(i => i).ToList();

            if (count % 2 == 1)
                return newArray[count / 2];
            else
                return newArray[count / 2 - 1];
        }

        public int Way2(int[] nums)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();

            foreach (var item in nums)
            {
                if (!dic.ContainsKey(item))
                    dic[item] = 1;
                else
                    dic[item] += 1;
            }

            int maxValue = 0;
            int maxKey = 0;
            foreach (var item in dic)
            {
                if (item.Value > maxValue)
                {
                    maxValue = item.Value;
                    maxKey = item.Key;
                }
            }

            return maxKey;
        }
    }
}
