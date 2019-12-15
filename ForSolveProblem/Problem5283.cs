using System;
namespace ForSolveProblem
{
    public class Problem5283 : IProblem
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

        public int GetDecimalValue(ListNode head)
        {
            var forReturn = 0;

            while (head != null)
            {
                var curValue = head.val;
                forReturn = forReturn * 2 + curValue;

                head = head.next;
            }

            return forReturn;
        }
    }
}
