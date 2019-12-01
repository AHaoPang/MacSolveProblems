using System;
using System.Collections.Generic;
using System.Text;

namespace ForSolveProblem
{
    public class Problem5109 : IProblem
    {
        public void RunProblem()
        {
            var temp = FindSmallestRegion(new List<IList<string>>()
            {
                new List<string>(){"Earth","North America","South America"},
                new List<string>(){"North America","United States","Canada"},
                new List<string>(){"United States","New York","Boston"},
                new List<string>(){"Canada","Ontario","Quebec"},
                new List<string>(){"South America","Brazil"},
            }, "Quebec", "New York");
            if (temp != "North America") throw new Exception();
        }

        public string FindSmallestRegion(IList<IList<string>> regions, string region1, string region2)
        {
            var regionDic = new Dictionary<string, string>();

            foreach(var regionItem in regions)
            {
                var fatherStr = regionItem[0];

                for(int i = 1;i < regionItem.Count; i++)
                    regionDic[regionItem[i]] = fatherStr;
            }

            var regionHash = new HashSet<string>() { region1 };
            var curgionStr = region1;

            while (regionDic.ContainsKey(curgionStr))
            {
                var fatherTemp = regionDic[curgionStr];
                regionHash.Add(fatherTemp);
                curgionStr = fatherTemp;
            }

            if (regionHash.Contains(region2)) return region2;

            var curgionResult = region2;
            while (regionDic.ContainsKey(curgionResult))
            {
                curgionResult = regionDic[curgionResult];

                if (regionHash.Contains(curgionResult))
                    break;
            }

            return curgionResult;
        }


    }
}
