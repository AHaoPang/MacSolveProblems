using System;
namespace ForSolveProblem
{
    public class Problem5343 : IProblem
    {
        public void RunProblem()
        {
            var temp = IsPossible(new int[] { 9, 3, 5 });
            if (temp != true) throw new Exception();

            temp = IsPossible(new int[] { 1, 1, 1, 2 });
            if (temp != false) throw new Exception();

            temp = IsPossible(new int[] { 8, 5 });
            if (temp != true) throw new Exception();

            temp = IsPossible(new int[] { 1000000000, 1 });
            
        }

        public bool IsPossible(int[] target)
        {
            if (target.Length == 1) return target[0] == 1;

            var priorityQueue = new PriorityQueue<long>(true, target.Length);
            long curSum = 0;
            for (int i = 0; i < target.Length; i++)
            {
                var curNum = target[i];
                priorityQueue.AddData(curNum);
                curSum += curNum;
            }

            var bigNum = priorityQueue.GetData();
            while (priorityQueue.HasData())
            {
                if (bigNum == 1) return true;

                var nextNum = priorityQueue.GetData();

                var otherSum = curSum - bigNum;
                var newNum = bigNum;
                while (newNum >= nextNum && newNum > 1)
                {
                    newNum -= otherSum;
                    if (newNum <= 0) return false;
                }

                curSum -= bigNum - newNum;
                priorityQueue.AddData(newNum);
                bigNum = nextNum;
            }

            return false;
        }
    }
}
