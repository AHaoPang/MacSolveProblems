using System;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem5314 : IProblem
    {
        public void RunProblem()
        {
            var temp = MinJumps(new int[] { 100, -23, -23, 404, 100, 23, 23, 23, 3, 404 });
            if (temp != 3) throw new Exception();

            temp = MinJumps(new int[] { 7 });
            if (temp != 0) throw new Exception();

            temp = MinJumps(new int[] { 7, 6, 9, 6, 9, 6, 9, 7 });
            if (temp != 1) throw new Exception();

            temp = MinJumps(new int[] { 6, 1, 9 });
            if (temp != 2) throw new Exception();

            temp = MinJumps(new int[] { 11, 22, 7, 7, 7, 7, 7, 7, 7, 22, 13 });
            if (temp != 3) throw new Exception();

            temp = MinJumps(new int[] { 0, 4, 3, 9 });
            if (temp != 3) throw new Exception();
        }

        public int MinJumps(int[] arr)
        {
            var valuePosSetDic = new Dictionary<int, HashSet<int>>();
            for (int i = 0; i < arr.Length; i++)
            {
                var curValue = arr[i];

                if (!valuePosSetDic.ContainsKey(curValue))
                    valuePosSetDic[curValue] = new HashSet<int>();

                valuePosSetDic[curValue].Add(i);
            }

            var queueTemp = new Queue<int>();
            queueTemp.Enqueue(0);

            m_forReturn2 = 0;
            Recursive(arr, queueTemp, arr.Length - 1, valuePosSetDic, new HashSet<int>());
            return m_forReturn2 - 1;
        }

        private int m_forReturn2;

        private void Recursive(int[] arr, Queue<int> queueTemp, int targetPos, Dictionary<int, HashSet<int>> valuePosSetDic, HashSet<int> visited)
        {
            m_forReturn2++;

            var newQueueTemp = new Queue<int>();
            while (queueTemp.Any())
            {
                var curPos = queueTemp.Dequeue();
                if (curPos == targetPos) return;

                if (curPos != 0 && !visited.Contains(arr[curPos - 1]))
                    newQueueTemp.Enqueue(curPos - 1);
                if (!visited.Contains(arr[curPos + 1]))
                    newQueueTemp.Enqueue(curPos + 1);

                if (visited.Contains(arr[curPos])) continue;
                visited.Add(arr[curPos]);

                var otherPosSet = valuePosSetDic[arr[curPos]];
                foreach (var otherPosItem in otherPosSet)
                    newQueueTemp.Enqueue(otherPosItem);
            }

            if (newQueueTemp.Any())
                Recursive(arr, newQueueTemp, targetPos, valuePosSetDic, visited);
        }

        public int MinJumps2(int[] arr)
        {
            if (arr.Length == 1) return 0;

            var firstItem = arr.First();
            var lastItem = arr.Last();
            if (firstItem == lastItem) return 1;

            var calcDic = new Dictionary<int, DicEntity>();
            calcDic[firstItem] = new DicEntity(int.MinValue, 0);
            for (int i = 0; i < arr.Length - 1; i++)
            {
                var curValue = arr[i];
                var curEntity = calcDic[curValue];

                if (i != 0)
                {
                    var leftValue = arr[i - 1];
                    Opera(calcDic, curValue, leftValue, curEntity.Count);
                }

                var rightValue = arr[i + 1];
                Opera(calcDic, curValue, rightValue, curEntity.Count);
            }

            return calcDic[lastItem].Count;
        }

        private void Opera(Dictionary<int, DicEntity> calcDic, int preValue, int curValue, int preCount)
        {
            if (!calcDic.ContainsKey(curValue))
            {
                calcDic[curValue] = new DicEntity(preValue, preCount + 1);
                return;
            }

            var entityTemp = calcDic[curValue];
            if (entityTemp.Count <= preCount)
            {
                if (entityTemp.PreValue != curValue)
                {
                    entityTemp.PreValue = curValue;
                    entityTemp.Count++;
                }

                return;
            }

            entityTemp.PreValue = preValue;
            entityTemp.Count = preCount + 1;
        }

        class DicEntity
        {
            public DicEntity(int pre, int count)
            {
                PreValue = pre;
                Count = count;
            }

            public int PreValue { get; set; }

            public int Count { get; set; }
        }

        public int MinJumps1(int[] arr)
        {
            if (arr.Length == 1) return 0;

            var pointSetDic = new Dictionary<int, HashSet<int>>();

            for (int i = 0; i < arr.Length; i++)
            {
                var curPos = arr[i];

                if (!pointSetDic.ContainsKey(curPos))
                    pointSetDic[curPos] = new HashSet<int>();

                if (i != 0)
                    pointSetDic[curPos].Add(arr[i - 1]);

                if (i != arr.Length - 1)
                    pointSetDic[curPos].Add(arr[i + 1]);
            }

            m_forReturn = 0;

            var firstItem = arr.First();
            var target = arr.Last();
            if (firstItem == target) return 1;

            var initQueue = new Queue<int>();
            initQueue.Enqueue(firstItem);
            var visited = new HashSet<int>();
            visited.Add(firstItem);

            CalcCount(initQueue, target, pointSetDic, new HashSet<int>());

            return m_forReturn;
        }

        private int m_forReturn;

        private void CalcCount(Queue<int> queueTemp, int target, Dictionary<int, HashSet<int>> pointSetDic, HashSet<int> visited)
        {
            m_forReturn++;

            var newQueue = new Queue<int>();
            while (queueTemp.Any())
            {
                var curPoint = queueTemp.Dequeue();

                var otherPoint = pointSetDic[curPoint];
                foreach (var otherItem in otherPoint)
                {
                    if (target == otherItem) return;

                    if (visited.Contains(otherItem)) continue;

                    visited.Add(otherItem);
                    newQueue.Enqueue(otherItem);
                }
            }

            CalcCount(newQueue, target, pointSetDic, visited);
        }
    }
}
