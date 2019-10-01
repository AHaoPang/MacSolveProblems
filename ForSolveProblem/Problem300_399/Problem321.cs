using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem321 : IProblem
    {
        public void RunProblem()
        {
            int[] nums1 = new int[] { 3, 4, 6, 5 };
            int[] nums2 = new int[] { 9, 1, 2, 5, 8, 3 };
            int k = 5;

            var temp = MaxNumber(nums1, nums2, k);
            if (!IsEqual(temp, new int[] { 9, 8, 6, 5, 3 })) throw new Exception();

            nums1 = new int[] { 6, 7 };
            nums2 = new int[] { 6, 0, 4 };
            k = 5;

            temp = MaxNumber(nums1, nums2, k);
            if (!IsEqual(temp, new int[] { 6, 7, 6, 0, 4 })) throw new Exception();

            nums1 = new int[] { 3, 9 };
            nums2 = new int[] { 8, 9 };
            k = 3;

            temp = MaxNumber(nums1, nums2, k);
            if (!IsEqual(temp, new int[] { 9, 8, 9 })) throw new Exception();

            nums1 = new int[] { 9, 1, 2, 5, 8, 3 };
            nums2 = new int[] { 3, 4, 6, 5 };
            k = 5;

            temp = MaxNumber(nums1, nums2, k);
            if (!IsEqual(temp, new int[] { 9, 8, 6, 5, 3 })) throw new Exception();

            nums1 = new int[] { 2, 5, 6, 4, 4, 0 };
            nums2 = new int[] { 7, 3, 8, 0, 6, 5, 7, 6, 2 };
            k = 15;

            temp = MaxNumber(nums1, nums2, k);
            if (!IsEqual(temp, new int[] { 7, 3, 8, 2, 5, 6, 4, 4, 0, 6, 5, 7, 6, 2, 0 })) throw new Exception();
        }

        private bool IsEqual(int[] arr1, int[] arr2)
        {
            if (arr1.Length != arr2.Length) return false;

            for (int i = 0; i < arr1.Length; i++)
                if (arr1[i] != arr2[i]) return false;

            return true;
        }

        public int[] MaxNumber(int[] nums1, int[] nums2, int k)
        {
            /*
             * 从两个数组中取出k个数字，在保证元素相对位置不变的情况下，得到最大的数
             * 思路：
             *  1.若要取出K个数，那么两个数组该如何分配，--> 列举出所有的可能组合
             *  2.对于一个数组而言，对于要求提供的若干数字，要尽量保证最大，--> 条件给定时，尽量提供出来最大的数
             *  3.两个数组都给出了最大的数，那么接下来就要使用双指针的方式来组合出来最大的数
             *  
             * 时间复杂度：O(k*(m+n))，假设有k种组合，那么从每个数组中取数的复杂度就是k*(m+n)
             * 空间复杂度：O(k)，要存储多种情况，然后从中选出最大的
             */

            //1.得到所有可能的组合
            var possibleCombine = GetPossibleCombine(nums1.Count(), nums2.Count(), k);

            List<int[]> possibleResult = new List<int[]>();
            foreach (var combineItem in possibleCombine)
            {
                //2.依据给定的条件，尽可能给出最大的值
                var arr1 = GetSubMaxNumber(nums1, combineItem.Item1);
                var arr2 = GetSubMaxNumber(nums2, combineItem.Item2);

                //3.组合两个子数组提供的最大值
                possibleResult.Add(GetSubCombineMaxNumber(arr1, arr2));
            }

            //4.比较多种情况的结果，取到最大的
            return GetMaxNumber(possibleResult, k);
        }

        private List<Tuple<int, int>> GetPossibleCombine(int n1Count, int n2Count, int k)
        {
            List<Tuple<int, int>> forReturn = new List<Tuple<int, int>>();

            for (int i = 0; i <= n1Count; i++)
            {
                if (k - i > n2Count || k - i < 0) continue;

                forReturn.Add(Tuple.Create(i, k - i));
            }

            return forReturn;
        }

        private int[] GetSubMaxNumber(int[] num, int l)
        {
            List<int> forReturn = new List<int>();

            GetSubMaxNumberRecursive(forReturn, num, 0, l);

            return forReturn.ToArray();
        }

        private void GetSubMaxNumberRecursive(List<int> forReturn, int[] num, int leftIndex, int curTurn)
        {
            if (curTurn == 0) return;

            int maxValue = 0;
            int maxValueIndex = leftIndex;
            for (int i = leftIndex; i < num.Length - curTurn + 1; i++)
            {
                if (maxValue >= num[i]) continue;

                maxValue = num[i];
                maxValueIndex = i;
            }

            forReturn.Add(num[maxValueIndex]);

            GetSubMaxNumberRecursive(forReturn, num, maxValueIndex + 1, curTurn - 1);
        }

        private int[] GetSubCombineMaxNumber(int[] sub1, int[] sub2)
        {
            List<int> forReturn = new List<int>();

            int sub1Index = 0;
            int sub2Index = 0;
            while (sub1Index < sub1.Length || sub2Index < sub2.Length)
            {
                int sub1Value = -1;
                if (sub1Index < sub1.Length) sub1Value = sub1[sub1Index];

                int sub2Value = -1;
                if (sub2Index < sub2.Length) sub2Value = sub2[sub2Index];

                if (sub1Value == sub2Value)
                {
                    if (ReturnChoosed(sub1, sub2, sub1Index, sub2Index) == 1)
                    {
                        forReturn.Add(sub1Value);
                        sub1Index++;
                    }
                    else
                    {
                        forReturn.Add(sub2Value);
                        sub2Index++;
                    }
                }
                else if (sub1Value > sub2Value)
                {
                    forReturn.Add(sub1Value);
                    sub1Index++;
                }
                else
                {
                    forReturn.Add(sub2Value);
                    sub2Index++;
                }
            }

            return forReturn.ToArray();
        }

        private int ReturnChoosed(int[] sub1, int[] sub2, int sub1Index, int sub2Index)
        {
            if (sub1Index == sub1.Length) return 2;
            if (sub2Index == sub2.Length) return 1;

            if (sub1[sub1Index] > sub2[sub2Index]) return 1;
            else if (sub1[sub1Index] < sub2[sub2Index]) return 2;
            else return ReturnChoosed(sub1, sub2, sub1Index + 1, sub2Index + 1);
        }

        private int[] GetMaxNumber(List<int[]> possibleResult, int k)
        {
            int forReturn = 0;
            HashSet<int> removeLine = new HashSet<int>();

            for (int i = 0; i < k; i++)
            {
                int curMaxValue = 0;
                for (int j = 0; j < possibleResult.Count; j++)
                {
                    if (removeLine.Contains(j)) continue;

                    if (curMaxValue < possibleResult[j][i]) curMaxValue = possibleResult[j][i];
                }

                for (int j = 0; j < possibleResult.Count; j++)
                    if (curMaxValue > possibleResult[j][i]) removeLine.Add(j);
            }

            for (int l = 0; l < possibleResult.Count; l++)
            {
                if (removeLine.Contains(l)) continue;

                forReturn = l;
                break;
            }

            return possibleResult[forReturn];
        }
    }
}
