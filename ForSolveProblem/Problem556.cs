using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem556 : IProblem
    {
        public void RunProblem()
        {
            var temp = NextGreaterElement(1999999999);
        }

        public int NextGreaterElement(int n)
        {
            /*
             * 解决方案一：
             * 具有输入值相同元素的所有可能性中，比输入值大的所有元素中的最小值，求解思路：
             * 1.分析出来输入值都有哪些元素；-->得到一个统计字典
             * 2.使用递归的方式，排列组合出所有可能的情况； -->若比n小，那么就丢弃好了，免得参与排序增加复杂度了，而且要做好适当的范围限制
             * 3.对所有情况做排序，那么目标值就是与n相同值的下一个元素了
             * 
             * 注意：
             * 32位整型数的排列组合，有可能出现大于32位整数表示范围的情况，所以本函数使用Long类型来做覆盖好了
             * 
             * 时间复杂度：穷举所有可能性，需要O(n!)，最大的32位数，是10位，所以，最坏情况有3,628,800‬种可能性，即使剪枝也只是减少一个数量级，然后排列的复杂度是O(nlogn);
             * 空间复杂度：存储所有可能性，是O(n!)
             * 
             * 以上这种算法并不可取了，复杂度太高了
             */

            /*
             * 解决方案二：
             * 1.将各位数字拆出来
             * 2.逆序遍历，找到首次数字降低的索引位置
             * 3.再正序遍历，找到比索引位置数大的最小数
             * 4.将索引位置之后的数，顺序排序即可
             * 
             * 时间复杂度：拆数字 O(位)，逆序遍历 O(位)，正序遍历 O(位) 再排序O(位log位)，最终是:O(位log位)
             * 空间复杂度：存储所有的位置 O(位)
             */

            //1.将各位数字拆出来
            Stack<int> stackNums = new Stack<int>();
            int tempN = n;
            while (tempN != 0)
            {
                var readyAddQueueItem = tempN % 10;
                stackNums.Push(readyAddQueueItem);
                tempN /= 10;
            }
            int[] nums = stackNums.ToArray();

            //2.逆序遍历，找到首次数字降低的索引位置
            int maxNums = 0;
            int i = nums.Length - 1;
            for (; i >= 0; i--)
            {
                if (i == nums.Length - 1) maxNums = nums[i];
                else
                {
                    if (maxNums <= nums[i]) maxNums = nums[i];
                    else break;
                }
            }
            if (i == -1) return -1;
            int firstReduceNum = i;

            //3.再正序遍历，找到比索引位置数大的最小数
            int j = firstReduceNum + 1;
            int firstIncreaseNum = nums[firstReduceNum + 1];
            int firstIncreaseIndex = firstReduceNum + 1;
            for (; j < nums.Length; j++)
            {
                if (nums[j] > nums[firstReduceNum] && nums[j] < firstIncreaseNum)
                {
                    firstIncreaseNum = nums[j];
                    firstIncreaseIndex = j;
                }
            }

            int tempInt = nums[firstReduceNum];
            nums[firstReduceNum] = nums[firstIncreaseIndex];
            nums[firstIncreaseIndex] = tempInt;

            //4.将索引位置之后的数，顺序排序即可
            var newArray = nums.Skip(firstReduceNum+1).Take(nums.Length - 1 - firstReduceNum).OrderBy(item => item).ToArray();
            int newArrayIndex = 0;
            for (int k = firstReduceNum + 1; k < nums.Length; k++)
                nums[k] = newArray[newArrayIndex++];

            long forReturn = 0;
            foreach (var numItem in nums)
                forReturn = forReturn * 10 + numItem;

            return forReturn > int.MaxValue ? -1 : (int)forReturn;
        }
    }
}
