using System;
using System.Collections.Generic;

namespace ForSolveProblem
{
    public class Problem460 : IProblem
    {
        public void RunProblem()
        {
            var lfu = new LFUCache(2);
            lfu.Put(1, 1);
            lfu.Put(2, 2);
            var v = lfu.Get(1);
            lfu.Put(3, 3);
            v = lfu.Get(2);
        }

        public class LFUCache
        {
            private LinkedList<DataItem> m_innerLinkedList;
            private Dictionary<int, LinkedListNode<DataItem>> m_innerDic;
            private int m_capacity;

            public LFUCache(int capacity)
            {
                m_innerLinkedList = new LinkedList<DataItem>();
                m_innerDic = new Dictionary<int, LinkedListNode<DataItem>>(capacity + 1);
                m_capacity = capacity;
            }

            public int Get(int key)
            {
                if (m_capacity == 0 || !m_innerDic.ContainsKey(key))
                    return -1;

                var curNode = m_innerDic[key];
                curNode.Value.PCount++;

                var preNode = curNode.Previous;
                while (preNode != null && preNode.Value.PCount <= curNode.Value.PCount)
                    preNode = preNode.Previous;

                m_innerLinkedList.Remove(curNode);
                if (preNode == null)
                    m_innerLinkedList.AddFirst(curNode);
                else
                    m_innerLinkedList.AddAfter(preNode, curNode);

                return curNode.Value.PValue;
            }

            public void Put(int key, int value)
            {
                if (m_capacity == 0) return;

                if (m_innerDic.ContainsKey(key))
                {
                    m_innerDic[key].Value.PValue = value;
                    Get(key);
                    return;
                }

                var newNode = new LinkedListNode<DataItem>(new DataItem(key, value, 0));
                m_innerDic[key] = newNode;

                if (m_innerDic.Count > m_capacity)
                {
                    var v = m_innerLinkedList.Last;
                    m_innerDic.Remove(v.Value.PKey);
                    m_innerLinkedList.RemoveLast();
                }

                m_innerLinkedList.AddLast(newNode);
                Get(key);
            }

            private class DataItem
            {
                public DataItem(int key, int value, int count)
                {
                    PKey = key;
                    PValue = value;
                    PCount = count;
                }
                public int PKey { get; set; }
                public int PValue { get; set; }
                public int PCount { get; set; }
            }
        }
    }
}
