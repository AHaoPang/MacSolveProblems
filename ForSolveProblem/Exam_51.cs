using System;
namespace ForSolveProblem
{
    public class Exam_51 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int ReversePairs(int[] nums)
        {
            SplitAndMerge(nums, 0, nums.Length - 1);
            return m_res;
        }

        private int m_res;

        private void SplitAndMerge(int[] nums, int start, int end)
        {
            if (start >= end) return;

            var mid = start + (end - start) / 2;
            SplitAndMerge(nums, start, mid);
            SplitAndMerge(nums, mid + 1, end);

            var lIndex = start;
            var rIndex = mid + 1;
            var newArr = new int[end - start + 1];
            var aIndex = 0;
            while (lIndex <= mid || rIndex <= end)
            {
                var lValue = long.MaxValue;
                if (lIndex <= mid)
                    lValue = nums[lIndex];

                var rValue = long.MaxValue;
                if (rIndex <= end)
                    rValue = nums[rIndex];

                if (lValue <= rValue)
                {
                    newArr[aIndex] = nums[lIndex];
                    m_res += aIndex - (lIndex - start);
                    aIndex++;
                    lIndex++;
                }
                else
                    newArr[aIndex++] = nums[rIndex++];
            }

            var nStartIndex = start;
            for (var i = 0; i < newArr.Length; i++)
                nums[nStartIndex++] = newArr[i];
        }
    }
}
