using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem090 : IProblem
    {
        public void RunProblem()
        {
            var temp = SubsetsWithDup(new int[] { 1, 2, 2 });
        }

        public IList<IList<int>> SubsetsWithDup(int[] nums)
        {
            /*
             * 考虑使用迭代的方式来解决
             * 思路：
             *  1.考虑n，n是n-1结果集的2倍，即原有结果集，再加上新的元素
             *  2.当元素重复的时候，只需要为部分结果集添加新元素即可
             */

            var forReturn = new List<IList<int>>();
            
            //把为空的情况，加上
            forReturn.Add(new List<int>());

            var orderedNums = nums.OrderBy(i => i).ToArray();

            //上一轮，新元素添加的起始位置
            int newElementStartPos = 0;
            for (int i = 0; i < orderedNums.Length; i++)
            {
                int j = 0;

                //元素重复时，从上一轮新加元素的位置开始做叠加
                if (i > 0 && orderedNums[i] == orderedNums[i - 1]) j = newElementStartPos;

                int endPos = forReturn.Count;

                newElementStartPos = endPos;

                for (; j < endPos; j++)
                {
                    var newListTemp = forReturn[j].ToList();
                    newListTemp.Add(orderedNums[i]);
                    forReturn.Add(newListTemp);
                }
            }

            return forReturn;
        }

        public IList<IList<int>> SubsetsWithDup1(int[] nums)
        {
            /*
             * 得到一个集合的所有幂等子集
             * 思路：
             *  1.若集合中的元素都是不重复的，那么子集的个数是2^n
             *  2.现在集合中出现了重复的元素，所以2^n个子集中，一定就出现了重复，依据题意是要排除掉的
             *  3.使用回溯来解决问题，回溯中的重复，使用“相同前缀”来做标识，若前缀相同，那么就说明遍历过了
             *  
             * 时间复杂度：O(2^n)
             * 空间复杂度：O(n)，递归的深度，至多是n层
             */

            int[] orderedNums = nums.OrderBy(i => i).ToArray();

            var forReturn = new List<IList<int>>();

            BackTrack(forReturn, orderedNums, 0, new List<int>());

            return forReturn;
        }

        private void BackTrack(IList<IList<int>> forReturn, int[] nums, int curLevel, IList<int> curList)
        {
            forReturn.Add(curList.ToList());

            /* 每一层，可选的元素范围是什么，但是不能包含重复的元素 */
            for (int i = curLevel; i < nums.Length; i++)
            {
                if (i > curLevel && nums[i] == nums[i - 1]) continue;

                curList.Add(nums[i]);
                BackTrack(forReturn, nums, i + 1, curList);
                curList.RemoveAt(curList.Count - 1);
            }
        }

        private HashSet<string> keySets = new HashSet<string>();

        private void BackTrack1(IList<IList<int>> forReturn, int[] nums, int curLevel, IList<int> curList)
        {
            if (curLevel == nums.Length)
            {
                var keyTemp = string.Join("|", curList);
                if (keySets.Contains(keyTemp)) return;
                keySets.Add(keyTemp);

                forReturn.Add(curList.ToList());
                return;
            }

            //不选择元素的情况
            BackTrack(forReturn, nums, curLevel + 1, curList);

            //选择元素的情况
            curList.Add(nums[curLevel]);
            BackTrack(forReturn, nums, curLevel + 1, curList);
            curList.RemoveAt(curList.Count - 1);
        }
    }
}
