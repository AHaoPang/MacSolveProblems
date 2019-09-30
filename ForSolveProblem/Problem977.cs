using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem977 : IProblem
    {
        public void RunProblem()
        {
            var temp = SortedSquares(new int[] { -4, -1, 0, 3, 10 });
            if (!IsEqual(temp, new int[] { 0, 1, 9, 16, 100 })) throw new Exception();

            temp = SortedSquares(new int[] { -7, -3, 2, 3, 11 });
            if (!IsEqual(temp, new int[] { 4, 9, 9, 49, 121 })) throw new Exception();
        }

        private bool IsEqual(int[] arr1,int[] arr2)
        {
            if (arr1.Length != arr2.Length) return false;

            for(int i = 0;i < arr1.Length; i++)
                if (arr1[i] != arr2[i]) return false;

            return true;
        }

        public int[] SortedSquares(int[] A)
        {
            /*
             * 递增排序的数组，在平方和以后，依然递增排序
             * 思路：
             *  1.会扰乱顺序的，是哪些负数，负负得正，导致位置的变动
             *  2.可以先用二分法定位正数负数的分割点
             *  3.然后再用双指针的方式，依次遍历正数和负数，做比较后排序输出
             *  
             * 时间复杂度：O(n)，二分定位的复杂度是O(logn)，但是排序成新数组时，依然是O(n)
             * 空间复杂度：O(1)，除了要输出的内容外，没有使用可变的额外空间
             */

            //二分定位分割点
            int leftIndex = 0;
            int rightIndex = A.Length - 1;
            while (leftIndex <= rightIndex)
            {
                var middleIndex = leftIndex + (rightIndex - leftIndex) / 2;

                if (A[middleIndex] >= 0) rightIndex = middleIndex - 1;
                else leftIndex = leftIndex = middleIndex + 1;
            }

            //双指针反向遍历并比较平方和
            int postiveIndex = leftIndex;
            int negativeIndex = leftIndex - 1;
            List<int> forReturn = new List<int>(A.Length);
            while (postiveIndex < A.Length || negativeIndex >= 0)
            {
                if (postiveIndex < A.Length && negativeIndex >= 0)
                {
                    if (Math.Abs(A[postiveIndex]) <= Math.Abs(A[negativeIndex]))
                    {
                        forReturn.Add(A[postiveIndex] * A[postiveIndex]);
                        postiveIndex++;
                    }
                    else
                    {
                        forReturn.Add(A[negativeIndex] * A[negativeIndex]);
                        negativeIndex--;
                    }
                }
                else if (postiveIndex < A.Length)
                {
                    forReturn.Add(A[postiveIndex] * A[postiveIndex]);
                    postiveIndex++;
                }
                else
                {
                    forReturn.Add(A[negativeIndex] * A[negativeIndex]);
                    negativeIndex--;
                }
            }

            return forReturn.ToArray();
        }
    }
}
