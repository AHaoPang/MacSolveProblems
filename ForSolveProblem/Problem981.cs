using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem981 : IProblem
    {
        public void RunProblem()
        {
            var map = new TimeMap();

            map.Set("foo", "bar", 1);
            var temp = map.Get("foo", 1);
            if (temp != "bar") throw new Exception();

            temp = map.Get("foo", 3);
            if (temp != "bar") throw new Exception();

            map.Set("foo", "bar2", 4);
            temp = map.Get("foo", 4);
            if (temp != "bar2") throw new Exception();

            temp = map.Get("foo", 5);
            if (temp != "bar2") throw new Exception();

            temp = map.Get("foo", 0);

        }

        public class TimeMap
        {
            private Dictionary<string, SortedDictionary<int, string>> m_innerDic;

            /** Initialize your data structure here. */
            public TimeMap()
            {
                m_innerDic = new Dictionary<string, SortedDictionary<int, string>>();
            }

            public void Set(string key, string value, int timestamp)
            {
                if (!m_innerDic.ContainsKey(key))
                    m_innerDic[key] = new SortedDictionary<int, string>();

                m_innerDic[key][timestamp] = value;
            }

            public string Get(string key, int timestamp)
            {
                if (!m_innerDic.ContainsKey(key)) return "";

                var orderedTimes = m_innerDic[key].Keys.ToList();
                var posIndex = orderedTimes.BinarySearch(timestamp);
                if (posIndex < 0)
                {
                    var newIndex = ~posIndex;

                    if (newIndex == 0) return "";
                    return m_innerDic[key][orderedTimes[newIndex - 1]];
                }

                return m_innerDic[key][orderedTimes[posIndex]];
            }
        }
    }
}
