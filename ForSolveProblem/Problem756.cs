using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem756 : IProblem
    {
        public void RunProblem()
        {
            var temp = PyramidTransition("XYZ", new List<string>() { "XYD", "YZE", "DEA", "FFF" });
            if (temp != true) throw new Exception();

            temp = PyramidTransition("XXYX", new List<string>() { "XXX", "XXY", "XYX", "XYY", "YXZ" });
            if (temp != false) throw new Exception();

            temp = PyramidTransition("BCD", new List<string>() { "ACC", "ACB", "ABD", "DAA", "BDC", "BDB", "DBC", "BBD", "BBC", "DBD", "BCC", "CDD", "ABA", "BAB", "DDC", "CCD", "DDA", "CCA", "DDD" });
            if (temp != true) throw new Exception();
        }

        public bool PyramidTransition(string bottom, IList<string> allowed)
        {
            /*
             * 验证金字塔是否能盖成
             * 思路：
             *  1.给了一层底，那么上一层的砖的可选项就是固定的了
             *  2.若上一层的可选项都试验过了，然后还是不成，那么就得通知下一层换个方案了
             *  3.若下一层是一开始约定好的，那么显然说明盖不成金字塔
             *  4.若底层只有一块儿砖，说明已经到了塔尖，现有的方案是可行的
             *  5.这是一种典型的回溯思路，即每一层都有很多种可选项，一个可选项不行，就接着试验另一种可选项
             *  
             * 时间复杂度：O(n^2)
             * 空间复杂度：O(n^2)
             * 
             * 注意：allowed表示可用的砖，并没有说此种转只有一块儿，所以砖是可以重复使用的
             */

            Dictionary<string, List<char>> allowedDic = new Dictionary<string, List<char>>();
            foreach (var allowItem in allowed)
            {
                var keyTemp = allowItem.Substring(0, 2);
                if (!allowedDic.ContainsKey(keyTemp)) allowedDic[keyTemp] = new List<char>();

                allowedDic[keyTemp].Add(allowItem.Last());
            }

            return BackTrace(bottom, allowedDic, 0, new List<char>());
        }

        private bool BackTrace(string bottom, Dictionary<string, List<char>> allowedDic, int pos, List<char> newBottom)
        {
            if (bottom.Length == 1) return true;
            if (bottom.Length - 1 == pos) return BackTrace(new string(newBottom.ToArray()), allowedDic, 0, new List<char>());

            var keyTemp = bottom.Substring(pos, 2);
            if (!allowedDic.ContainsKey(keyTemp)) return false;

            foreach (var optionItem in allowedDic[keyTemp])
            {
                newBottom.Add(optionItem);
                var resultTemp = BackTrace(bottom, allowedDic, pos + 1, newBottom);
                if (resultTemp) return true;

                newBottom.RemoveAt(newBottom.Count - 1);
            }

            return false;
        }
    }
}
