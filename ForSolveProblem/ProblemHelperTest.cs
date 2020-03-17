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
            GetPrimeSetTest();
        }

        #region PriorityQueue
        private void PriorityQueueTest()
        {
            var numArray = new int[] { 23, 1, 0, 356, 3, 56, 63, 3, 6, 0 };
            var pq = new PriorityQueue<int>(false);

            foreach (var numItem in numArray)
                pq.AddData(numItem);

            var resultList = new List<int>(numArray.Length);
            while (pq.HasData()) resultList.Add(pq.GetData());

            var entityList = new List<TestEntity>()
            {
                new TestEntity(3,"3"),
                new TestEntity(5,"5"),
                null,
                new TestEntity(23,"23"),
                new TestEntity(36,"36"),
                new TestEntity(1,"1"),
            };
            var pqEntity = new PriorityQueue<TestEntity>(false);
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

        private void MadeTreeV2Test()
        {
            int?[] array = new int?[] { 1, null, 1, 1, 1, null, null, 1, 1, null, 1, null, null, null, 1, null, 1 };
            var root = ProblemHelper.MadeTreeV2(array);

            array = new int?[] { 1, 1, 1, null, 1, null, null, 1, 1, null, 1 };
            root = ProblemHelper.MadeTreeV2(array);

            array = new int?[] { 1 };
            root = ProblemHelper.MadeTreeV2(array);

        }

        private void AssertEqualTest()
        {
            ProblemHelper.AEqual(5, 5);

            ProblemHelper.AEqual(5, 6);
        }

        private void ArrayEqualTest()
        {
            var a1 = new[] { 1, 2, 3, 4 };
            var a2 = new[] { 3, 4, 1, 2 };

            var temp = ProblemHelper.ArrayEqual(a1, a2);

            var b1 = new List<int>() { '1', '2', '4', '6' };
            var b2 = new List<int>() { '1', '2', '4', '6' };

            temp = ProblemHelper.ArrayEqual(b1, b2, false);

            var c1 = new[] { 'a', 'b', 'c' };
            var c2 = new[] { 'b', 'a', 'c' };

            temp = ProblemHelper.ArrayEqual(c1, c2, false);
            temp = ProblemHelper.ArrayEqual(c1, c2);
        }

        private void GetPrimeSetTest()
        {
            var temp = ProblemHelper.GetPrimeSet(100);
        }
    }
}
