using System;
using System.Collections.Generic;

namespace ForSolveProblem
{
    public class Problem284 : IProblem
    {
        public void RunProblem()
        {
            var p = new PeekingIterator(new List<int>() { 1, 2, 3 }.GetEnumerator());
            var t = p.Next();
            t = p.Peek();

            t = p.Next();
            t = p.Next();

            var b = p.HasNext();
        }

        class PeekingIterator
        {
            private IEnumerator<int> m_iter;
            // iterators refers to the first element of the array.
            public PeekingIterator(IEnumerator<int> iterator)
            {
                // initialize any member here.
                m_iter = iterator;
                m_iter.MoveNext();
            }

            // Returns the next element in the iteration without advancing the iterator.
            public int Peek()
            {
                return m_iter.Current;
            }

            // Returns the next element in the iteration and advances the iterator.
            public int Next()
            {
                var r = m_iter.Current;
                m_iter.MoveNext();
                return r;
            }

            // Returns false if the iterator is refering to the end of the array of true otherwise.
            public bool HasNext()
            {
                return m_iter.Current != 0;
            }
        }
    }
}
