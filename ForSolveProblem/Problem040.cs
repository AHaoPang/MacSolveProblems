using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem040 : IProblem
    {
        public void RunProblem()
        {
            var temp = CombinationSum2(new int[] { 10, 1, 2, 7, 6, 1, 5 }, 8);

            var temp2 = CombinationSum2(new int[] { 2, 5, 2, 1, 2 }, 5);
        }

        public IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            /*
             * 从可选项中，找到所有总和为目标值的 组合
             * 思路：
             *  1.每个可选项只能使用一次
             *  2.为了让得到的结果不重复，回溯的时候必须是有序的
             *  
             * 时间复杂度：排序是O(nlogn)，一共要递归m层，即O(n^m)，最后就是O(n^m)，像这种穷举类的，基本上都是指数型的复杂度
             * 空间复杂度：O(n^m)，即仅包括递归调用栈
             * 
             * 考察点：
             *  1.递归
             *  2.回溯
             *  
             * 与上一个同类题的比较：
             *  1.每个可选项只能使用一次；
             *  2.增加一个限制条件，那么相当于做一些剪枝，即啥都不限制，条件是最多的，限制一点，情况就少一点~
             */

            var forReturn = new List<IList<int>>();

            //特殊情况处理，就无需进入回溯的递归方法中做无用功了
            if (candidates.Sum() < target) return forReturn;

            var orderedCandidates = candidates.OrderBy(i => i).ToArray();
            Recursive(orderedCandidates, 0, target, new List<int>(), forReturn);

            return forReturn;
        }

        private void Recursive(int[] orderedCandidates, int startPos, int target, IList<int> nums, IList<IList<int>> forReturn)
        {
            if (target == 0)
            {
                forReturn.Add(nums.ToList());
                return;
            }

            for (int i = startPos; i < orderedCandidates.Length; i++)
            {
                //提前剪枝
                if (target - orderedCandidates[i] < 0) break;

                //同一个层级，相同的数字选择过一次，就不要再选了
                if (i > startPos && orderedCandidates[i] == orderedCandidates[i - 1]) continue;

                nums.Add(orderedCandidates[i]);
                Recursive(orderedCandidates, i + 1, target - orderedCandidates[i], nums, forReturn);
                nums.RemoveAt(nums.Count - 1);
            }
        }
    }
}
