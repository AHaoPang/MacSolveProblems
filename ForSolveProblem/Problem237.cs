using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem237 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }

        public void DeleteNode(ListNode node)
        {
            /*
             * 删除单链表的一个节点
             * 思路：
             *  1.链表的删除有很多形式，题目给出的就是一种方式，即直接给你要删除的节点
             *  2.别人调用此方法时，其实也说明了，这个节点一定不可能是尾节点
             *  3.这个的删除需要打破一定的定式思维，即“节点的值是不可变的”的这种定势
             *  4.那么依据已有条件，单链表没有上个节点的地址，肯定是删除不了当前的节点了，但是我们是可以修改值的。
             *  5.综上，步骤是这样的：把下个节点的值给当前的节点，然后把下个节点删掉；
             *  
             * 时间复杂度：O(1)，基本上就是两个节点的操作了
             * 空间复杂度：O(1)，使用的额外空间是固定的
             * 
             * 考察点：
             *  1.单链表的了解以及操作
             */

            node.val = node.next.val;
            node.next = node.next.next;
        }
    }
}
