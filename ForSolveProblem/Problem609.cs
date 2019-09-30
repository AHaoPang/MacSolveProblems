using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem609 : IProblem
    {
        public void RunProblem()
        {
            var temp = FindDuplicate(new string[] { "root/a 1.txt(abcd) 2.txt(efgh)", "root/c 3.txt(abcd)", "root/c/d 4.txt(efgh)", "root 4.txt(efgh)" });
        }

        public IList<IList<string>> FindDuplicate(string[] paths)
        {
            /*
             * 涉及到统计和汇总的，使用HashTable
             * 1.遍历每行已有的条件，解析出：路径、文件、内容
             * 2.已内容为key，路径+文件为值
             * 3.最后过滤出value大于1的key-value，输出
             * 
             * 时间复杂度：O(n);
             * 空间复杂度：O(n);
             */

            Dictionary<string, IList<string>> contextDirectoryDic = new Dictionary<string, IList<string>>();
            foreach (var pathItem in paths)
            {
                var arrTemp = pathItem.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var dirStr = arrTemp[0] + "/";
                for (int i = 1; i < arrTemp.Length; i++)
                {
                    var fileNameAndContext = arrTemp[i].Split(new char[] { '(' }, StringSplitOptions.RemoveEmptyEntries);
                    if (!contextDirectoryDic.ContainsKey(fileNameAndContext[1]))
                        contextDirectoryDic[fileNameAndContext[1]] = new List<string>();

                    contextDirectoryDic[fileNameAndContext[1]].Add(dirStr + fileNameAndContext[0]);
                }
            }

            IList<IList<string>> forReturn = new List<IList<string>>();
            foreach (var dicItem in contextDirectoryDic)
                if (dicItem.Value.Count > 1) forReturn.Add(dicItem.Value);

            return forReturn;
        }
    }
}
