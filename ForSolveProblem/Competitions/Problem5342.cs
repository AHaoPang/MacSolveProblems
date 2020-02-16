using System;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem5342 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int MaxEvents(int[][] events)
        {
            var orderEvents = events.OrderBy(i => i[1]);

            var totalSum = (int)1e5 + 1;
            var daySet = new bool[totalSum];
            var forReturn = 0;
            foreach (var eventItem in orderEvents)
            {
                for (var i = eventItem[0]; i <= eventItem[1]; i++)
                {
                    if (daySet[i]) continue;

                    daySet[i] = true;
                    forReturn++;
                    break;
                }
            }

            return forReturn;
        }

        public int MaxEvents1(int[][] events)
        {
            var orderEvent = events.OrderBy(i => i[0]).ThenBy(i => i[1]);

            var forReturn = 0;
            var curDay = 1;
            foreach (var eventItem in orderEvent)
            {
                var start = eventItem[0];
                var end = eventItem[1];

                if (curDay < start)
                {
                    curDay = start + 1;
                    forReturn++;
                }
                else if (curDay > end)
                {

                }
                else
                {
                    curDay += 1;
                    forReturn++;
                }
            }

            return forReturn;
        }

        public int MaxEvents2(int[][] events)
        {
            var eventDaysDic = new Dictionary<int, List<int[]>>();

            for (int i = 0; i < events.Length; i++)
            {
                var dayCount = events[i][1] - events[i][0] + 1;

                if (!eventDaysDic.ContainsKey(dayCount))
                    eventDaysDic[dayCount] = new List<int[]>();

                eventDaysDic[dayCount].Add(events[i]);
            }

            var orderEventDays = eventDaysDic.OrderBy(i => i.Key);

            var totalSum = (int)1e5 + 1;
            var daySet = new bool[totalSum];
            var forReturn = 0;
            foreach (var orderItem in orderEventDays)
            {
                var orderChild = orderItem.Value.OrderBy(i => i[0]);

                foreach (var childItem in orderChild)
                {
                    for (int i = childItem[0]; i <= childItem[1]; i++)
                    {
                        if (daySet[i]) continue;

                        forReturn++;
                        daySet[i] = true;
                        break;
                    }
                }
            }

            return forReturn;
        }
    }
}
