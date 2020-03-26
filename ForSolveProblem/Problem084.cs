using System;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem084 : IProblem
    {
        public void RunProblem()
        {
            var temp = LargestRectangleArea(new[] { 2, 1, 5, 6, 2, 3 });
        }

        public int LargestRectangleArea(int[] heights)
        {
            var stack = new Stack<int>(heights.Length + 1);
            stack.Push(-1);

            var res = 0;
            for (var i = 0; i < heights.Length; i++)
            {
                while (stack.Peek() != -1 && heights[stack.Peek()] >= heights[i])
                    res = Math.Max(res, heights[stack.Pop()] * (i - stack.Peek() - 1));

                stack.Push(i);
            }

            while (stack.Peek() != -1)
                res = Math.Max(res, heights[stack.Pop()] * (heights.Length - stack.Peek() - 1));

            return res;
        }

        public int LargestRectangleArea2(int[] heights)
        {
            var simpleStack = new int[heights.Length];

            var lIndex = -1;
            var leftToRightIncreaseArray = new int[heights.Length];
            for (var i = 0; i < heights.Length; i++)
            {
                while (lIndex >= 0 && heights[simpleStack[lIndex]] >= heights[i])
                    lIndex--;

                leftToRightIncreaseArray[i] = lIndex == -1 ? -1 : simpleStack[lIndex];
                simpleStack[++lIndex] = i;
            }

            var rIndex = heights.Length;
            var rightToLeftIncreaseArray = new int[heights.Length];
            for (var j = heights.Length - 1; j >= 0; j--)
            {
                while (rIndex < heights.Length && heights[simpleStack[rIndex]] >= heights[j])
                    rIndex++;

                rightToLeftIncreaseArray[j] = rIndex == heights.Length ? heights.Length : simpleStack[rIndex];
                simpleStack[--rIndex] = j;
            }

            var res = 0;
            for (var i = 0; i < heights.Length; i++)
            {
                var width = rightToLeftIncreaseArray[i] - leftToRightIncreaseArray[i] - 1;
                res = Math.Max(res, width * heights[i]);
            }

            return res;
        }

        public int LargestRectangleArea1(int[] heights)
        {
            /*
             * ##### 1. 题目概述：柱状图中的最大矩形
             * 
             * ##### 2. 思路：
             *    - 特征：
             *         1.可以从高度为 1 开始,逐渐增加高度,找到最大的矩形,如此一来时间复杂度会很高;
             *         2.最大的矩形的高,一定是覆盖柱子中最矮的那个的高度,宽度一定是比它还矮或者边界的位置;
             *         3.可以假设每个柱子的高度就是最终矩形的高度,而宽度则是离他最近的比他矮的柱子
             *         4.所以对于每根柱子而言,都要找它附近里的最近的矮柱子的位置
             *    - 方案：满足单调栈的应用场景,分别在两个方向上找到更矮柱子的位置,得到宽,自己是高,那么矩形面积就可以计算了
             *    - 结果：以每个柱子为准,找到最大的宽高乘积
             *
             * ##### 3. 知识点：单调栈
             * 
             * ##### 4. 复杂度分析: 
             *    - 时间复杂度：O(n)
             *    - 空间复杂度：O(n)
             */

            var link = new LinkedList<int>();
            var orderArray = new int[heights.Length];
            for (var i = 0; i < heights.Length; i++)
            {
                while (link.Any() && heights[link.Last()] >= heights[i])
                    link.RemoveLast();

                orderArray[i] = link.Any() ? link.Last() : -1;
                link.AddLast(i);
            }

            var reverseLink = new LinkedList<int>();
            var reverseArray = new int[heights.Length];
            for (var j = heights.Length - 1; j >= 0; j--)
            {
                while (reverseLink.Any() && heights[reverseLink.Last()] >= heights[j])
                    reverseLink.RemoveLast();

                reverseArray[j] = reverseLink.Any() ? reverseLink.Last() : heights.Length;
                reverseLink.AddLast(j);
            }

            var res = 0;
            for (var i = 0; i < heights.Length; i++)
            {
                var width = reverseArray[i] - orderArray[i] - 1;
                res = Math.Max(res, width * heights[i]);
            }

            return res;
        }
    }
}
