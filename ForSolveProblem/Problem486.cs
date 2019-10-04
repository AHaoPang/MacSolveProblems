using System;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem486 : IProblem
    {
        public void RunProblem()
        {
            var temp = PredictTheWinner(new int[] { 1, 5, 2 });
            if (temp != false) throw new Exception();

            temp = PredictTheWinner(new int[] { 1, 5, 233, 7 });
            if (temp != true) throw new Exception();

            temp = PredictTheWinner(new int[] { 1, 2 });
            if (temp != true) throw new Exception();
        }

        public bool PredictTheWinner(int[] nums)
        {
            /*
             * 题目概述：玩一个游戏，预测下首发是否是赢家
             * 
             * 思路：
             *  1. 这是一个挑选数字后汇总的游戏
             *  2. 每轮玩家都会有两个选择，玩家当然会选择让自己赢的那个选择了
             *
             * 关键点：
             *
             * 时间复杂度： O(n)
             * 空间复杂度： O(n)
             */

            return BackTrace(nums, 0, nums.Length - 1, new List<int>(), new List<int>(), 1);
        }


        private bool BackTrace(int[] nums, int leftIndex, int rightIndex, IList<int> oneCollection, IList<int> twoCollection, int times)
        {
            if (leftIndex > rightIndex)
            {
                var countTemp = 0;
                for (int i = 0; i < oneCollection.Count || i < twoCollection.Count; i++)
                {
                    if (i < oneCollection.Count && i < twoCollection.Count) countTemp += oneCollection[i] - twoCollection[i];
                    else if (i < oneCollection.Count) countTemp += oneCollection[i];
                    else countTemp -= twoCollection[i];
                }

                return countTemp >= 0;
            }

            var isOne = (times & 1) == 1;

            //选左
            var leftValue = nums[leftIndex];
            if (isOne) oneCollection.Add(leftValue);
            else twoCollection.Add(leftValue);
            var resultTemp = BackTrace(nums, leftIndex + 1, rightIndex, oneCollection, twoCollection, times + 1);

            if (isOne)
            {
                oneCollection.RemoveAt(oneCollection.Count - 1);
                if (resultTemp) return true;
            }
            else
            {
                twoCollection.RemoveAt(twoCollection.Count - 1);
                if (!resultTemp) return false;
            }

            //选右
            var rightValue = nums[rightIndex];
            if (isOne) oneCollection.Add(rightValue);
            else twoCollection.Add(rightValue);

            var resultTemp2 = BackTrace(nums, leftIndex, rightIndex - 1, oneCollection, twoCollection, times + 1);

            if (isOne) oneCollection.RemoveAt(oneCollection.Count - 1);
            else twoCollection.RemoveAt(twoCollection.Count - 1);

            return resultTemp2;
        }
    }
}
