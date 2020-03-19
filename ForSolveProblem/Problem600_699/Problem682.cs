using System;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem682 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int CalPoints(string[] ops)
        {
            var numStack = new Stack<int>();
            foreach(var opsItem in ops)
            {
                switch (opsItem)
                {
                    case "+":
                        var top = numStack.Pop();
                        var twoSum = top + numStack.Peek();
                        numStack.Push(top);
                        numStack.Push(twoSum);
                        break;

                    case "D":
                        numStack.Push(2 * numStack.Peek());
                        break;

                    case "C":
                        numStack.Pop();
                        break;

                    default:
                        numStack.Push(int.Parse(opsItem));
                        break;
                }
            }

            return numStack.Sum();
        }

        public int CalPoints1(string[] ops)
        {
            var numArray = new List<int>(ops.Length);
            foreach (var opsItem in ops)
            {
                switch (opsItem)
                {
                    case "+":
                        numArray.Add(numArray.TakeLast(2).Sum());
                        break;

                    case "D":
                        numArray.Add(numArray.Last() * 2);
                        break;

                    case "C":
                        numArray.RemoveAt(numArray.Count - 1);
                        break;

                    default:
                        numArray.Add(int.Parse(opsItem));
                        break;
                }
            }

            return numArray.Sum();
        }
    }
}
