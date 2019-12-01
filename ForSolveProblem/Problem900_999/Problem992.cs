using System;
using System.Collections.Generic;

namespace ForSolveProblem
{
    public class Problem992 : IProblem
    {
        public void RunProblem()
        {
            var temp = SubarraysWithKDistinct(new int[] { 1, 2, 1, 2, 3 }, 2);
            if (temp != 7) throw new Exception();

            temp = SubarraysWithKDistinct(new int[] { 1, 2, 1, 3, 4 }, 3);
            if (temp != 3) throw new Exception();
        }

        public int SubarraysWithKDistinct(int[] A, int K)
        {
            /*
             * 题目概述：子数组范围内有 K 个元素的个数
             * 
             * 思路：
             *  1.最开始想的是固定左边界,找到所有的有边界,这样的话,需要校验的内容有点儿多
             *  2.逆向思维,固定有边界,找所有的左边界,这个是比较顺的,3 个指针都可以朝着一个方向依次移动
             *  3.维护一个窗口类,里面记录了元素的种类和个数
             *
             * 关键点：
             *
             * 时间复杂度：O(n)
             * 空间复杂度：O(n)
             */

            var forReturn = 0;

            var leftMinIndex = 0;
            var win1 = new Window();
            var leftMaxIndex = 0;
            var win2 = new Window();
            for (int rightIndex = 0; rightIndex < A.Length; rightIndex++)
            {
                win1.AddData(A[rightIndex]);
                win2.AddData(A[rightIndex]);

                while (win1.ElementCount() > K) win1.DelData(A[leftMinIndex++]);
                while (win2.ElementCount() >= K) win2.DelData(A[leftMaxIndex++]);

                if (win1.ElementCount() == K) forReturn += leftMaxIndex - leftMinIndex;
            }

            return forReturn;
        }

        class Window
        {
            private Dictionary<int, int> m_innerDic;

            public Window() => m_innerDic = new Dictionary<int, int>();

            public void AddData(int data)
            {
                if (!m_innerDic.ContainsKey(data)) m_innerDic[data] = 0;
                m_innerDic[data]++;
            }

            public void DelData(int data)
            {
                if (!m_innerDic.ContainsKey(data)) return;

                m_innerDic[data]--;
                if (m_innerDic[data] == 0) m_innerDic.Remove(data);
            }

            public int ElementCount() => m_innerDic.Count;
        }
    }
}
