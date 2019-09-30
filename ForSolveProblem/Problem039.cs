using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem039 : IProblem
    {
        public void RunProblem()
        {
            var temp = CombinationSum(new int[] { 2, 3, 5 }, 8);
        }

        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            /*
             * 给定一些可选项，经过N次组合，到达目标值，那么有多少种组合
             * 思路：
             *  1.查找所有可能性的问题，最适合用回溯法；
             *  2.回溯需要有遍历的顺序和规则，进而抽象成从树的根到树的叶的过程；
             *  3.对可选项排序，依次从小到大的选择，多个步骤中，每个步骤的选择，不能比上个步骤选择的数小
             *  4.和为target的组合，则可以作为结果
             *  
             * 时间复杂度：对数组进行排序，是O(nlogn)，穷尽则是要找出所有的可能性，是O(n^m),最终是，O(n^m)
             * 空间复杂度：O(n^m)，即只有函数栈上的消耗
             * 
             * 考察点：
             *  1.回溯法，如果建立这样的抽象
             */

            IList<IList<int>> forReturn = new List<IList<int>>();

            var orderedCandidates = candidates.OrderBy(i => i).ToArray();
            RecurSive(orderedCandidates, 0, target, new List<int>(), forReturn);

            return forReturn;
        }

        private void RecurSive(int[] orderedCandidates, int lastPos, int target, IList<int> nums, IList<IList<int>> forReturn)
        {
            if (target == 0)
            {
                forReturn.Add(nums.ToList());
                return;
            }

            for (int i = lastPos; i < orderedCandidates.Length; i++)
            {
                if (target - orderedCandidates[i] < 0) break;

                nums.Add(orderedCandidates[i]);
                RecurSive(orderedCandidates, i, target - orderedCandidates[i], nums, forReturn);
                nums.RemoveAt(nums.Count - 1);
            }
        }
    }
}
