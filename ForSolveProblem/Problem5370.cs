using System;
using System.Collections.Generic;

namespace ForSolveProblem
{
    public class Problem5370 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public class UndergroundSystem
        {
            private (string Name, int Time)[] m_innerArray = new (string Name, int Time)[(int)1e6 + 1];
            private Dictionary<string, (long Duration, int Count)> m_innerDic = new Dictionary<string, (long Duration, int Count)>((int)1e4);
            private string GetStr(string s, string d) => $"{s}_{d}";

            public UndergroundSystem()
            {

            }

            public void CheckIn(int id, string stationName, int t)
            {
                m_innerArray[id] = (stationName, t);
            }

            public void CheckOut(int id, string stationName, int t)
            {
                var curItem = m_innerArray[id];
                var str = GetStr(curItem.Name, stationName);
                if (!m_innerDic.ContainsKey(str))
                {
                    m_innerDic[str] = (t - curItem.Time, 1);
                }
                else
                {
                    var curI = m_innerDic[str];
                    curI.Count++;
                    curI.Duration += t - curItem.Time;
                }
            }

            public double GetAverageTime(string startStation, string endStation)
            {
                var curDicItem = m_innerDic[GetStr(startStation, endStation)];
                return 1.0 * curDicItem.Duration / curDicItem.Count;
            }
        }
    }
}
