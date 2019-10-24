using System;
using System.Collections.Generic;
using System.Text;

namespace ForSolveProblem
{
    public class Problem5231 : IProblem
    {
        public void RunProblem()
        {
            var v = RemoveSubfolders(new string[] { "/a", "/a/b", "/c/d", "/c/d/e", "/c/f" });

            v = RemoveSubfolders(new string[] { "/a", "/a/b/c", "/a/b/d" });

            v = RemoveSubfolders(new string[] { "/a/b/c", "/a/b/d", "/a/b/ca" });
        }

        public IList<string> RemoveSubfolders(string[] folder)
        {
            /*
             * 先对字符串做排序
             * 1.第一个字符串,一定是父文件夹
             * 2.以此为基础判断其它的文件夹
             *      2.1 匹配则跳过
             *      2.2 不匹配,则说明发现了新的父文件夹
             *      2.3 使用新的父文件夹去继续匹配
             *      
             * 3.时间复杂度:O(nlogn) 排序nlogn 循环一次 n
             * 4.空间复杂度:O(n)
             */

            Array.Sort(folder);

            var forReturn = new List<string>(folder.Length);

            var fatherTemp = folder[0];
            forReturn.Add(fatherTemp);

            var lengthTemp = fatherTemp.Length + 1;
            for (int i = 1; i < folder.Length; i++)
            {
                if (folder[i].Length < lengthTemp || fatherTemp + '/' != folder[i].Substring(0, lengthTemp))
                {
                    forReturn.Add(folder[i]);
                    fatherTemp = folder[i];
                    lengthTemp = fatherTemp.Length + 1;
                }
            }

            return forReturn;
        }

        public IList<string> RemoveSubfolders1(string[] folder)
        {
            /*
            * 问题:在给定的文件夹列表中,去掉子文件夹
            * 思路:
            *  1. 借用Trie树的构建思路,另外做特殊处理
            *  2. 将文件夹路径,按照"\"分隔,得到多个组成部分,把他们构造到Trie树当中
            *  3. 对于树中的每个节点,需要记录的是:
            *       3.1 节点存储的字符串
            *       3.2 当前节点,是否是文件夹的终点
            *       3.3 如果不是文件夹的终点,有多少子文件夹
            *  4. 先构建Trie树,然后使用回溯法遍历得到的结果,就是解
            * 
            * 关键点:
            * 
            * 时间复杂度:O(n)
            * 空间复杂度:O(n)
            */

            var treeTemp = new TreeManager();
            foreach (var folderItem in folder) treeTemp.AddNode(folderItem);

            return treeTemp.ForReturn();
        }

        /// <summary>
        /// 树节点
        /// </summary>
        class TreeNode
        {
            public TreeNode(string curS)
            {
                CurStr = curS;
                NextNodesDic = new Dictionary<string, TreeNode>();
            }

            /// <summary>
            /// 当前节点存储的字符串
            /// </summary>
            public string CurStr { get; set; }

            /// <summary>
            /// 标识是否是目录的终点
            /// </summary>
            public bool IsEnd { get; set; }

            /// <summary>
            /// 子树节点
            /// </summary>
            public IDictionary<string, TreeNode> NextNodesDic { get; set; }
        }

        /// <summary>
        /// 一整棵树
        /// </summary>
        class TreeManager
        {
            /// <summary>
            /// 树的根节点
            /// </summary>
            private TreeNode m_root;

            public TreeManager()
            {
                m_root = new TreeNode("/");
            }

            /// <summary>
            /// 继续构建树
            /// </summary>
            public void AddNode(string s)
            {
                var rootNodeTemp = m_root;

                var sArray = s.Split("/", StringSplitOptions.RemoveEmptyEntries);
                var fontNode = rootNodeTemp;
                foreach (var sItem in sArray)
                {
                    if (fontNode.NextNodesDic.ContainsKey(sItem))
                    {
                        fontNode = fontNode.NextNodesDic[sItem];

                        if (fontNode.IsEnd) break;
                    }
                    else
                    {
                        fontNode.NextNodesDic[sItem] = new TreeNode(sItem);
                        fontNode = fontNode.NextNodesDic[sItem];
                    }
                }

                fontNode.IsEnd = true;
            }

            /// <summary>
            /// 返回有效的子树
            /// </summary>
            public IList<string> ForReturn()
            {
                foreach (var rootItem in m_root.NextNodesDic)
                    Backtrace(rootItem.Value, new List<string>());

                return m_forReturn;
            }

            /// <summary>
            /// 回溯法获取
            /// </summary>
            private void Backtrace(TreeNode node, IList<string> curArray)
            {
                curArray.Add(node.CurStr);
                if (node.IsEnd)
                {
                    m_forReturn.Add("/" + string.Join('/', curArray));
                    return;
                }

                foreach (var childItem in node.NextNodesDic)
                {
                    Backtrace(childItem.Value, curArray);
                    curArray.RemoveAt(curArray.Count - 1);
                }
            }

            /// <summary>
            /// 存储有效的子树
            /// </summary>
            private IList<string> m_forReturn = new List<string>();
        }
    }
}
