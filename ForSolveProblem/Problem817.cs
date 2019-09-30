using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem817 : IProblem
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

        public int NumComponents(ListNode head, int[] G)
        {
            /*
             * 在单链表中寻找子链表，子链表中的元素必须存在于G中
             * 思路：
             *  1.单链表必须是单向顺序遍历的
             *  2.最好能在遍历的时候，就判断出来子链表
             *  3.那么判断的条件就是是否存在于G中，最快的判断方式就是Hash了，因此考虑将G放入Hash中
             *  
             * 时间复杂度：O(n+m)
             * 空间复杂度：O(m)
             */

            HashSet<int> hashG = new HashSet<int>(G);

            int forReturn = 0;
            bool isAdded = false;
            ListNode searchNode = head; //链表长度至少是1
            while(searchNode != null)
            {
                bool isInG = hashG.Contains(searchNode.val);

                //若当前节点在HashG中，且之前没统计过，就累加
                if (isInG && !isAdded)
                {
                    forReturn++;
                    isAdded = true;
                }

                //若当前元素的值不在HashG中，那么就中断统计，打算开启新的统计了
                if (!isInG) isAdded = false;

                searchNode = searchNode.next;
            }

            return forReturn;
        }
    }
}
