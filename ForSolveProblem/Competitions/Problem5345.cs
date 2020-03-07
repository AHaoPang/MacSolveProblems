using System;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem5345 : IProblem
    {
        public void RunProblem()
        {
            var temp = RankTeams(new string[]
            {
                "FVSHJIEMNGYPTQOURLWCZKAX",
                "AITFQORCEHPVJMXGKSLNZWUY",
                "OTERVXFZUMHNIYSCQAWGPKJL",
                "VMSERIJYLZNWCPQTOKFUHAXG",
                "VNHOZWKQCEFYPSGLAMXJIUTR",
                "ANPHQIJMXCWOSKTYGULFVERZ",
                "RFYUXJEWCKQOMGATHZVILNSP",
                "SCPYUMQJTVEXKRNLIOWGHAFZ",
                "VIKTSJCEYQGLOMPZWAHFXURN",
                "SVJICLXKHQZTFWNPYRGMEUAO",
                "JRCTHYKIGSXPOZLUQAVNEWFM",
                "NGMSWJITREHFZVQCUKXYAPOL",
                "WUXJOQKGNSYLHEZAFIPMRCVT",
                "PKYQIOLXFCRGHZNAMJVUTWES",
                "FERSGNMJVZXWAYLIKCPUQHTO",
                "HPLRIUQMTSGYJVAXWNOCZEKF",
                "JUVWPTEGCOFYSKXNRMHQALIZ",
                "MWPIAZCNSLEYRTHFKQXUOVGJ",
                "EZXLUNFVCMORSIWKTYHJAQPG",
                "HRQNLTKJFIEGMCSXAZPYOVUW",
                "LOHXVYGWRIJMCPSQENUAKTZF",
                "XKUTWPRGHOAQFLVYMJSNEIZC",
                "WTCRQMVKPHOSLGAXZUEFYNJI"
            });
        }

        public string RankTeams(string[] votes)
        {
            var membersDic = new Dictionary<char, int[]>(26);
            for (var i = 'A'; i <= 'Z'; i++)
                membersDic[i] = new int[votes[0].Length];

            for (var c = 0; c < votes[0].Length; c++)
                for (var r = 0; r < votes.Length; r++)
                    membersDic[votes[r][c]][c]++;

            var newList = new List<KeyValuePair<char, int[]>>();
            foreach (var dicItem in membersDic)
            {
                if (dicItem.Value.All(i => i == 0)) continue;

                newList.Add(dicItem);
            }

            for (var i = votes[0].Length - 1; i >= 0; i--)
                newList = newList.OrderByDescending(v => v.Value[i]).ToList();

            return new string(newList.Select(i => i.Key).ToArray());
        }
    }
}
