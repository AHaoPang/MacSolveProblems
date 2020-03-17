using System;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem5305 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public IList<string> WatchedVideosByFriends(IList<IList<string>> watchedVideos, int[][] friends, int id, int level)
        {
            var visited = new bool[friends.Length];

            var queueTemp = new Queue<int>();
            queueTemp.Enqueue(id);
            visited[id] = true;

            var loopCount = 0;
            while (queueTemp.Any() && loopCount < level)
            {
                var newQueue = new Queue<int>();
                while (queueTemp.Any())
                {
                    var curId = queueTemp.Dequeue();
                    foreach (var nextId in friends[curId])
                    {
                        if (visited[nextId]) continue;
                        visited[nextId] = true;

                        newQueue.Enqueue(nextId);
                    }
                }
                queueTemp = newQueue;
                loopCount++;
            }

            var videoDic = new Dictionary<string, int>();
            while (queueTemp.Any())
            {
                var friendTemp = queueTemp.Dequeue();

                foreach (var videoItem in watchedVideos[friendTemp])
                {
                    if (!videoDic.ContainsKey(videoItem)) videoDic[videoItem] = 0;

                    videoDic[videoItem]++;
                }
            }

            return videoDic.OrderBy(i => i.Value).ThenBy(j => j.Key, StringComparer.Ordinal).Select(k => k.Key).ToList();
        }
    }
}
