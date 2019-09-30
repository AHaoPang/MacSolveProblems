using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem449 : IProblem
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

        public void RunProblem()
        {
            TreeNode t1 = new TreeNode(4);
            TreeNode t2 = new TreeNode(2);
            TreeNode t3 = new TreeNode(5);

            TreeNode t4 = new TreeNode(1);
            TreeNode t5 = new TreeNode(3);

            TreeNode t6 = new TreeNode(6);

            t1.left = t2;
            t1.right = t3;

            t2.left = t4;
            t2.right = t5;

            t3.right = t6;

            Codec c = new Codec();

            var temp = c.serialize(t1);

            var v = c.deserialize(temp);
        }

        public class Codec
        {

            // Encodes a tree to a single string.
            public string serialize(TreeNode root)
            {
                /*
                 * 将树序列化
                 * 思路：
                 *  1.利用前序遍历的方式，构造特殊的字符串
                 *  2.对于为null的部分，转换成N
                 *  
                 * 时间复杂度：O(n)，需要把所有节点都过滤一遍
                 * 空间复杂度：O(1)，除了函数栈空间外，以及输出的内容外，并不需要额外的空间
                 */

                if (root == null) return "N";

                return $"{root.val},{serialize(root.left)},{serialize(root.right)}";
            }

            // Decodes your encoded data to tree.
            public TreeNode deserialize(string data)
            {
                /*
                 * 将树反序列化
                 * 思路：
                 *  1.序列化使用的是前序遍历，读取的时候，是可以依次组装的
                 *  2.把一个字符串拆分，然后依次组装，可以想到的就是队列了，然后再结合使用递归
                 *  
                 * 时间复杂度：O(n)，整个字符串，是要遍历一遍的
                 * 空间复杂度：O(n)，除了返回的结果，还需要维护一个队列，里面存放了树的每个节点
                 */

                Queue<object> queueTemp = new Queue<object>(data.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries));

                return Recursive(queueTemp);
            }

            private TreeNode Recursive(Queue<object> queueTemp)
            {
                var nodeValueStr = queueTemp.Dequeue();

                if (nodeValueStr.ToString() == "N") return null;

                TreeNode root = new TreeNode(int.Parse(nodeValueStr.ToString()));

                root.left = Recursive(queueTemp);
                root.right = Recursive(queueTemp);

                return root;
            }
        }
    }
}
