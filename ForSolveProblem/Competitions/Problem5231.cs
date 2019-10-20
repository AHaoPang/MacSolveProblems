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

        class TreeNode
        {
            public TreeNode(string curS)
            {
                curStr = curS;
                nextNodesDic = new Dictionary<string, TreeNode>();
            }

            public string curStr { get; set; }

            public bool isEnd { get; set; }

            public IDictionary<string, TreeNode> nextNodesDic { get; set; }
        }

        class TreeEntity
        {
            private TreeNode m_root;

            public TreeEntity()
            {
                m_root = new TreeNode("/");
            }

            public void AddNode(string s)
            {
                var rootNodeTemp = m_root;

                var sArray = s.Split("/", StringSplitOptions.RemoveEmptyEntries);
                var fontNode = rootNodeTemp;
                foreach (var sItem in sArray)
                {
                    if (fontNode.nextNodesDic.ContainsKey(sItem))
                    {
                        fontNode = fontNode.nextNodesDic[sItem];
                        if (fontNode.isEnd) break;
                    }
                    else
                    {
                        fontNode.nextNodesDic[sItem] = new TreeNode(sItem);
                        fontNode = fontNode.nextNodesDic[sItem];
                    }
                }

                fontNode.isEnd = true;
            }

            public IList<string> ForReturn()
            {
                foreach (var rootItem in m_root.nextNodesDic)
                    RecurSive(rootItem.Value, new List<string>());

                return m_forReturn;
            }

            private void RecurSive(TreeNode node, IList<string> curArray)
            {
                curArray.Add(node.curStr);
                if (node.isEnd)
                {
                    m_forReturn.Add("/" + string.Join('/', curArray));
                    return;
                }

                foreach (var childItem in node.nextNodesDic)
                {
                    RecurSive(childItem.Value, curArray);
                    curArray.RemoveAt(curArray.Count - 1);
                }
            }

            private IList<string> m_forReturn = new List<string>();
        }

        public IList<string> RemoveSubfolders(string[] folder)
        {
            var c = new TreeEntity();

            foreach (var folderItem in folder)
                c.AddNode(folderItem);

            return c.ForReturn();
        }
    }
}
