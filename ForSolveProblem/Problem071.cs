using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem071 : IProblem
    {
        public void RunProblem()
        {
            var temp = SimplifyPath("/home/");
            if (temp != "/home") throw new Exception();

            var temp2 = SimplifyPath("/../");
            if (temp2 != "/") throw new Exception();

            var temp3 = SimplifyPath("/home//foo/");
            if (temp3 != "/home/foo") throw new Exception();

            var temp4 = SimplifyPath("/a/./b/../../c/");
            if (temp4 != "/c") throw new Exception();

            var temp5 = SimplifyPath("/a/../../b/../c//.//");
            if (temp5 != "/c") throw new Exception();

            var temp6 = SimplifyPath("/a//b////c/d//././/..");
            if (temp6 != "/a/b/c") throw new Exception();
        }

        public string SimplifyPath(string path)
        {
            /* 改进了字符串的切割 */

            Stack<string> dirStack = new Stack<string>();
            var dirArray = path.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            foreach(var dirItem in dirArray)
            {
                switch (dirItem)
                {
                    case ".":
                        break;

                    case "..":
                        if (dirStack.Any()) dirStack.Pop();
                        break;

                    default:
                        dirStack.Push(dirItem);
                        break;
                }
            }

            string forReturn = "";
            while (dirStack.Any())
                forReturn = $"/{dirStack.Pop()}{forReturn}";

            //依据业务需求做的特殊处理
            if (string.IsNullOrWhiteSpace(forReturn))
                forReturn = "/";

            return forReturn;
        }

        public string SimplifyPath2(string path)
        {
            /*
             * 将“正确的但是复杂的决定路径”做“最短最清晰描述的简化”
             * 思路：
             *  1.已“/”后缀为单位，解析字符串，不断向栈中加入目录和删除目录的过程
             *  2.之所以用栈，是因为，"../"表示要跳到上一级，而上一级就是之前刚加入的目录，也就是说，这个满足“先入后出”的规则；
             *  3.要处理的特殊字符串有：
             *      3.1 空       -->跳过，继续扫描
             *      3.2 .        -->跳转，继续扫描
             *      3.3 ..      -->从栈中弹出元素（栈为空，则什么都不动）
             *      3.4 正常的路径 -->直接压入栈中
             *  4.路径扫描完以后，把栈的内容弹出，构造出最短路径，返回即可
             *  
             * 时间复杂度：O(n)，需要把输入的字符串扫描一遍
             * 空间复杂度：O(n)，路径越长，有可能需要压入的目录越多，我们是依据栈中的内容，来构造最短路径的
             * 
             * 考察点：
             *  1.栈的应用，能正确的依据题目特性，匹配到这种数据结构
             */


            Stack<string> dirStack = new Stack<string>();
            for (int i = 0; i < path.Length; i++)
            {
                int endPos = i;
                while (endPos < path.Length && path[endPos] != '/')
                    endPos++;

                var subStr = "";
                if (endPos - i > 0) subStr = path.Substring(i, endPos - i);

                switch (subStr)
                {
                    case "":
                    case ".":
                        break;

                    case "..":
                        if (dirStack.Any()) dirStack.Pop();
                        break;

                    default:
                        dirStack.Push(subStr);
                        break;
                }

                i = endPos;
            }

            string forReturn = "";
            while (dirStack.Any())
                forReturn = $"/{dirStack.Pop()}{forReturn}";

            //依据业务需求做的特殊处理
            if (string.IsNullOrWhiteSpace(forReturn))
                forReturn = "/";

            return forReturn;
        }
    }
}
