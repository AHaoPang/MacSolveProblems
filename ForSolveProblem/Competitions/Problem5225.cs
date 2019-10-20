using System;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem5225 : IProblem
    {
        public int MaxEqualFreq(int[] nums)
        {
            /*
             * 题目概述：从给定的数组中,找出一个最长前缀,将前缀中去掉一个元素,剩下的元素个数都相同
             * 
             * 思路：
             *  1. 从题目中能看出按照个数分组的情况,那么我们从一开始就应该知道各个分组的情况,然后再尝试动态改变分组内的元素
             *  2. 统计整个数组的分组情况
             *  3. 开始判断
             *      3.1 仅有一个分组
             *          3.1.1 组内元素个数均为1 满足条件
             *          3.1.2 组件仅1个元素 满足条件
             *      3.2 有多个分组,就依次缩小前缀数组,并作出如下判断
             *          3.2.1 如果仅剩下两个分组,那么查看组内元素个数为 1 个的分组
             *              3.2.1.1 key-1 == 0 满足条件;
             *              3.2.1.2 key-1 == 另一个 key 满足条件;
             *              3.2.1.3 其它情况下,则需要继续缩减前缀数组的长度了
             *
             * 关键点：
             *
             * 时间复杂度：O(n)
             * 空间复杂度：O(n)
             */

            //得到各元素个数统计
            var numCount = nums.ToLookup(i => i, j => j).ToDictionary(i => i.Key, j => j.Count());

            //得到相同个数元素的分组
            var numGroupByCount = numCount.GroupBy(i => i.Value, j => j.Key).ToDictionary(i => i.Key, j => j.ToHashSet());

            //特殊条件判断
            if (numGroupByCount.Count == 1 && numGroupByCount.First().Value.Count == 1) return nums.Length; //3.1.2 组件仅1个元素 满足条件
            if (numGroupByCount.Count == 1 && numGroupByCount.First().Key - 1 == 0) return nums.Length; //3.1.1 组内元素个数均为1 满足条件

            //循环前的判断
            var firstVerify = GroupVerify(numGroupByCount);
            if (firstVerify) return nums.Length;

            for (int i = nums.Length - 1; i >= 1; i--)
            {
                var curNum = nums[i];

                ChangeGroupNum(numGroupByCount, numCount, curNum);

                var verifyResult = GroupVerify(numGroupByCount);
                if (verifyResult) return i;
            }

            //返回结果
            return 1;
        }

        private bool GroupVerify(IDictionary<int, HashSet<int>> dic)
        {
            if (dic.Count > 2) return false;

            var firstDicItem = dic.First();
            var lastDicItem = dic.Last();

            if (firstDicItem.Value.Count == 1)
            {
                if (firstDicItem.Key - 1 == 0) return true;
                if (firstDicItem.Key - 1 == lastDicItem.Key) return true;
            }

            if (lastDicItem.Value.Count == 1)
            {
                if (lastDicItem.Key - 1 == 0) return true;
                if (lastDicItem.Key - 1 == firstDicItem.Key) return true;
            }

            return false;
        }

        private void ChangeGroupNum(IDictionary<int, HashSet<int>> dic, IDictionary<int, int> dicNumCount, int numElement)
        {
            var numCount = dicNumCount[numElement];
            dicNumCount[numElement]--;

            dic[numCount].Remove(numElement);
            if (dic[numCount].Count == 0) dic.Remove(numCount);

            var newKey = numCount - 1;
            if (newKey == 0) return;

            if (!dic.ContainsKey(newKey)) dic[newKey] = new HashSet<int>();

            dic[newKey].Add(numElement);
        }

        public void RunProblem()
        {
            var temp = MaxEqualFreq(new int[] { 2, 2, 1, 1, 5, 3, 3, 5 });
            if (temp != 7) throw new Exception();

            temp = MaxEqualFreq(new int[] { 1, 1, 1, 2, 2, 2, 3, 3, 3, 4, 4, 4, 5 });
            if (temp != 13) throw new Exception();

            temp = MaxEqualFreq(new int[] { 1, 1, 1, 2, 2, 2 });
            if (temp != 5) throw new Exception();

            temp = MaxEqualFreq(new int[] { 10, 2, 8, 9, 3, 8, 1, 5, 2, 3, 7, 6 });
            if (temp != 8) throw new Exception();
        }
    }
}
