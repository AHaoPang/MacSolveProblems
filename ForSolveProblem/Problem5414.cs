using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem5414 : IProblem
    {
        public void RunProblem()
        {
            var temp = PeopleIndexes(new List<IList<string>>()
            {
                new List<string>(){ "leetcode", "google", "facebook" },
                new List<string>(){ "google", "microsoft" },
                new List<string>(){ "google", "facebook" },
                new List<string>(){ "google" },
                new List<string>(){ "amazon" }
            });
        }

        public IList<int> PeopleIndexes(IList<IList<string>> favoriteCompanies)
        {
            var setArray = favoriteCompanies
                .Select(i => i.OrderBy(j => j).ToList())
                .ToArray();

            var orderArray = favoriteCompanies
                .Select((i, index) => new CountEntity() { Index = index, ListCount = i.Count })
                .OrderBy(i => i.ListCount)
                .ToArray();

            var res = new List<int>();
            for (var i = 0; i < orderArray.Length; i++)
            {
                var setTemp = setArray[orderArray[i].Index];
                var isInclude = false;
                for (var j = i + 1; j < orderArray.Length; j++)
                {
                    if (IsInclude(setTemp, setArray[orderArray[j].Index]))
                    {
                        isInclude = true;
                        break;
                    }
                }

                if (!isInclude)
                    res.Add(orderArray[i].Index);
            }

            return res.OrderBy(i => i).ToArray();
        }

        public class CountEntity
        {
            public int Index { get; set; }
            public int ListCount { get; set; }
            public override string ToString()
            {
                return $"{Index}_{ListCount}";
            }
        }

        private bool IsInclude(IList<string> list1, IList<string> list2)
        {
            if (list1.Count == list2.Count)
                return false;

            var oneIndex = 0;
            var twoIndex = 0;
            for (; twoIndex < list2.Count; twoIndex++)
            {
                if (list1[oneIndex] == list2[twoIndex])
                {
                    oneIndex++;
                    if (oneIndex == list1.Count)
                        break;
                }
            }

            return oneIndex == list1.Count;
        }

        public IList<int> PeopleIndexes4(IList<IList<string>> favoriteCompanies)
        {
            var dic = new Dictionary<string, HashSet<int>>();
            for (var i = 0; i < favoriteCompanies.Count; i++)
            {
                foreach (var f in favoriteCompanies[i])
                {
                    if (!dic.ContainsKey(f))
                        dic[f] = new HashSet<int>();

                    dic[f].Add(i);
                }
            }

            var res = new List<int>();
            for (var i = 0; i < favoriteCompanies.Count; i++)
            {
                var set = new HashSet<int>(dic[favoriteCompanies[i].First()]);
                var isInclude = true;
                foreach (var f in favoriteCompanies[i])
                {
                    set.IntersectWith(dic[f]);
                    if (set.Count == 1)
                    {
                        isInclude = false;
                        break;
                    }
                }

                if (!isInclude)
                    res.Add(i);
            }

            return res;
        }

        public IList<int> PeopleIndexes3(IList<IList<string>> favoriteCompanies)
        {
            var list = new List<HashSet<string>>(favoriteCompanies.Count);
            for (var i = 0; i < favoriteCompanies.Count; i++)
                list.Add(new HashSet<string>(favoriteCompanies[i]));

            var res = new List<int>();
            for (var i = 0; i < favoriteCompanies.Count; i++)
            {
                var isInclude = false;
                for (var j = 0; j < favoriteCompanies.Count; j++)
                {
                    if (i == j) continue;
                    if (!list[i].Except(list[j]).Any())
                    {
                        isInclude = true;
                        break;
                    }
                }

                if (!isInclude)
                    res.Add(i);
            }

            return res;
        }

        public class ListEntity
        {
            public int Index { get; set; }
            public HashSet<string> StrSets { get; set; }
        }

        public IList<int> PeopleIndexes2(IList<IList<string>> favoriteCompanies)
        {
            var list = new List<ListItem>();
            for (var i = 0; i < favoriteCompanies.Count; i++)
                list.Add(new ListItem() { Id = i, ListValue = favoriteCompanies[i] });

            var orderList = list.OrderBy(i => i, new MyComparer()).ToArray();

            var res = new List<int>();
            for (var i = 0; i < orderList.Length; i++)
            {
                if (i != orderList.Length - 1)
                {
                    if (IsSame(orderList[i].ListValue, orderList[i + 1].ListValue))
                        continue;
                }

                res.Add(orderList[i].Id);
            }

            return res.OrderBy(i => i).ToList();
        }

        private bool IsSame(IList<string> str1, IList<string> str2)
        {
            if (str1.Count > str2.Count)
                return false;

            for (var i = 0; i < str1.Count; i++)
            {
                if (str1[i] != str2[i])
                    return false;
            }

            return true;
        }

        public class ListItem
        {
            public int Id { get; set; }
            public IList<string> ListValue { get; set; }

            public override string ToString()
            {
                return string.Join(" ", ListValue);
            }
        }

        public class MyComparer : IComparer<ListItem>
        {
            public int Compare(ListItem x, ListItem y)
            {
                var list1 = x.ListValue;
                var list2 = y.ListValue;

                var minIndex = Math.Min(list1.Count, list2.Count);
                for (var i = 0; i < minIndex; i++)
                {
                    if (list1[i] == list2[i])
                        continue;

                    return list1[i].CompareTo(list2[i]);
                }

                if (list1.Count == minIndex)
                    return -1;
                else
                    return 1;
            }
        }

    }
}
