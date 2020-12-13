using System;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem501 : IProblem
    {
        public void RunProblem()
        {
            var t1 = new TreeNode(1);
            var t2 = new TreeNode(2);
            var t3 = new TreeNode(2);

            t1.right = t2;
            t2.left = t3;

            var t = FindMode(t1);
        }

        public int[] FindMode1(TreeNode root)
        {
            /*
             * ##### 1. 题目概述：二叉搜索树中的众数
             * 
             * ##### 2. 思路：
             *    - 特征：给定的树,是一个二叉搜索树,所以若为中序遍历,序列一定是单调递增的;众数是出现次数最多的数字,在递增序列中一定是连续出现的;
             *    - 方案：前序遍历树,统计连续出现的数字的个数,将满足条件的结果加入到结果集合中;
             *    - 结果：结果集合中的数据
             *
             * ##### 3. 知识点：树 中序遍历
             * 
             * ##### 4. 复杂度分析: 
             *    - 时间复杂度：O(n)
             *    - 空间复杂度：O(1)
             */

            if (root == null) return new int[0];

            m_maxCount = 0;
            m_maxNumList = new List<int>();

            m_curValue = int.MinValue;
            m_curCount = 0;

            Recursive(root);
            UpdateResult();

            return m_maxNumList.ToArray();
        }

        private int m_maxCount;
        private List<int> m_maxNumList;
        private int m_curValue;
        private int m_curCount;

        private void Recursive(TreeNode root)
        {
            if (root == null) return;

            Recursive(root.left);

            var curValue = root.val;
            if (curValue == m_curValue)
            {
                m_curCount++;
            }
            else
            {
                UpdateResult();

                m_curValue = curValue;
                m_curCount = 1;
            }

            Recursive(root.right);
        }

        private void UpdateResult()
        {
            if (m_curCount >= m_maxCount)
            {
                if (m_curCount > m_maxCount)
                {
                    m_maxCount = m_curCount;
                    m_maxNumList.Clear();
                }
                m_maxNumList.Add(m_curValue);
            }
        }

        #region Way2
        public int[] FindMode(TreeNode root)
        {
            _res = new List<int>();
            _maxCount = 0;

            _curCount = 0;
            _curNum = 0;

            if (root != null)
            {
                Dfs(root);
                ForUpdate();
            }
            return _res.ToArray();
        }

        private int _curNum;
        private int _curCount;

        private void Dfs(TreeNode root)
        {
            if (root == null) return;

            Dfs(root.left);

            if (root.val == _curNum)
            {
                //相等则累计
                _curCount++;
            }
            else
            {
                //不相等,则触发更新
                ForUpdate();

                _curCount = 1;
                _curNum = root.val;
            }

            Dfs(root.right);
        }

        private int _maxCount;
        private IList<int> _res;

        private void ForUpdate()
        {
            if (_curCount > _maxCount)
            {
                _res.Clear();
                _maxCount = _curCount;
                _res.Add(_curNum);
            }
            else if (_curCount == _maxCount)
            {
                _res.Add(_curNum);
            }
        } 
        #endregion
    }
}
