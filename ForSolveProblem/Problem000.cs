using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem000 : IProblem
    {
        public void RunProblem()
        {
            var arr = new int[] {6, 4, 7, 3, 6, 9,3, 12 };
            Sort(arr, 0, 7);
        }

        private void Sort(int[] arr, int start, int stop)
        {
            /*
             * 思考：主要是对双指针的灵活运用，解决这个问题的关键是，分清双指针的职责！
             * 使用快速排序的方式来对数组做排序
             * 时间复杂度：O(nlogn)
             * 空间复杂度：O(1)
             */

            if (stop - start < 1) return;

            int pivotIndex = start;
            int firstIndex = start + 1;
            int lastIndex = stop;

            while(firstIndex <= lastIndex)
            {
                while (arr[firstIndex] <= arr[pivotIndex]) firstIndex++;
                while (arr[lastIndex] > arr[pivotIndex]) lastIndex--;

                if(firstIndex < lastIndex)
                {
                    var temp1 = arr[lastIndex];
                    arr[lastIndex] = arr[firstIndex];
                    arr[firstIndex] = temp1;
                }
            }

            var temp2 = arr[lastIndex];
            arr[lastIndex] = arr[pivotIndex];
            arr[pivotIndex] = temp2;

            Sort(arr, start, lastIndex - 1);
            Sort(arr, lastIndex + 1, stop);
        }
    }
}
