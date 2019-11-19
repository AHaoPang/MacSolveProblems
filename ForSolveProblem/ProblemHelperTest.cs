using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ForSolveProblem
{
    public class ProblemHelperTest : IProblem
    {
        public void RunProblem()
        {
            PriorityQueueTest();
        }

        #region PriorityQueue
        private void PriorityQueueTest()
        {
            var numArray = new int[] { 23, 1, 356, 3, 56, 63, 3, 6, 0 };
            var pq = new PriorityQueue<int>(true);

            foreach (var numItem in numArray)
                pq.AddData(numItem);

            var resultList = new List<int>(numArray.Length);
            while (pq.HasData()) resultList.Add(pq.GetData());

            var entityList = new List<TestEntity>()
            {
                new TestEntity(3,"3"),
                new TestEntity(5,"5"),
                new TestEntity(23,"23"),
                new TestEntity(36,"36"),
                new TestEntity(1,"1"),
            };
            var pqEntity = new PriorityQueue<TestEntity>(true);
            foreach (var entityItem in entityList)
                pqEntity.AddData(entityItem);

            var resultTemp = new List<TestEntity>(entityList.Count);
            while (pqEntity.HasData()) resultTemp.Add(pqEntity.GetData());
        }

        class TestEntity : IComparable<TestEntity>
        {
            public int m_i { get; }
            public string m_s { get; }

            public TestEntity(int i, string s)
            {
                m_i = i;
                m_s = s;
            }

            public int CompareTo([AllowNull] TestEntity other)
            {
                if (other == null || m_i > other.m_i) return 1;

                if (m_i < other.m_i) return -1;

                return 0;
            }
        } 
        #endregion
    }
}
