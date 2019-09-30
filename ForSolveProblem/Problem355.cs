using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem355 : IProblem
    {
        public void RunProblem()
        {
            Twitter t = new Twitter();

            t.PostTweet(1, 1);
            t.PostTweet(1, 2);
            t.PostTweet(2, 1);
            t.PostTweet(2, 2);
        }

        public class Twitter
        {
            /// <summary>
            /// 表示一个推文实体
            /// </summary>
            class FeedInfo
            {
                public FeedInfo(int userId, int tweetId)
                {
                    UserId = userId;
                    TweetId = tweetId;
                }

                /// <summary>
                /// 记录用户ID
                /// </summary>
                public int UserId { get; set; }

                /// <summary>
                /// 记录推文ID
                /// </summary>
                public int TweetId { get; set; }
            }

            /// <summary>
            /// 存储关注列表
            /// </summary>
            private Dictionary<int, HashSet<int>> m_FollowDic;

            /// <summary>
            /// 存储推文列表
            /// </summary>
            private LinkedList<FeedInfo> m_FeedLinkedList;

            /** Initialize your data structure here. */
            public Twitter()
            {
                m_FollowDic = new Dictionary<int, HashSet<int>>();
                m_FeedLinkedList = new LinkedList<FeedInfo>();
            }

            /** Compose a new tweet. */
            public void PostTweet(int userId, int tweetId)
            {
                m_FeedLinkedList.AddLast(new FeedInfo(userId, tweetId));
            }

            /** Retrieve the 10 most recent tweet ids in the user's news feed. Each item in the news feed must be posted by users who the user followed or by the user herself. Tweets must be ordered from most recent to least recent. */
            public IList<int> GetNewsFeed(int userId)
            {
                var forReturn = new List<int>();

                var hashfollowers = new HashSet<int>();
                if (m_FollowDic.ContainsKey(userId)) hashfollowers = m_FollowDic[userId];

                int feedCount = 0;
                var itemStart = m_FeedLinkedList.Last;
                while (itemStart != null && feedCount < 10)
                {
                    var userIdTemp = itemStart.Value.UserId;
                    var tweetIdTemp = itemStart.Value.TweetId;

                    if (userIdTemp == userId || hashfollowers.Contains(userIdTemp))
                    {
                        feedCount++;
                        forReturn.Add(tweetIdTemp);
                    }

                    itemStart = itemStart.Previous;
                }

                return forReturn;
            }

            /** Follower follows a followee. If the operation is invalid, it should be a no-op. */
            public void Follow(int followerId, int followeeId)
            {
                if (!m_FollowDic.ContainsKey(followerId)) m_FollowDic[followerId] = new HashSet<int>();

                m_FollowDic[followerId].Add(followeeId);
            }

            /** Follower unfollows a followee. If the operation is invalid, it should be a no-op. */
            public void Unfollow(int followerId, int followeeId)
            {
                if (!m_FollowDic.ContainsKey(followerId)) return;

                m_FollowDic[followerId].Remove(followeeId);
            }
        }
    }
}
