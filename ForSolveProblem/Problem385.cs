using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace ForSolveProblem
{
    public class Problem385 : IProblem
    {
        public void RunProblem()
        {
            var temp = Deserialize("[123,[456,[789]]]");
        }

        public class NestedInteger
        {

            // Constructor initializes an empty nested list.
            public NestedInteger() { }

            // Constructor initializes a single integer.
            public NestedInteger(int value) { }

            // @return true if this NestedInteger holds a single integer, rather than a nested list.
            public bool IsInteger() => true;

            // @return the single integer that this NestedInteger holds, if it holds a single integer
            // Return null if this NestedInteger holds a nested list
            public int GetInteger() => 1;

            // Set this NestedInteger to hold a single integer.
            public void SetInteger(int value) { }

            // Set this NestedInteger to hold a nested list and adds a nested integer to it.
            public void Add(NestedInteger ni) { }

            // @return the nested list that this NestedInteger holds, if it holds a nested list
            // Return null if this NestedInteger holds a single integer
            public IList<NestedInteger> GetList() => new List<NestedInteger>();
        }

        public NestedInteger Deserialize(string s)
        {
            return Recursive(s, 0, out int i);
        }

        private NestedInteger Recursive(string s, int curIndex, out int nextIndex)
        {
            nextIndex = curIndex + 1;

            var forReturn = new NestedInteger();
            var numTemp = 0;
            for (int i = curIndex; i < s.Length; i++)
            {
                var curChar = s[i];
                switch (curChar)
                {
                    case '[':
                        var r = Recursive(s, i + 1, out int ni);
                        if (r.GetList() == null)
                            forReturn.Add(r);
                        else
                        {
                            foreach (var item in r.GetList())
                                forReturn.Add(item);
                        }

                        i = ni - 1;
                        break;

                    case ']':
                        nextIndex = i + 1;
                        return forReturn;

                    case ',':
                        if (numTemp != 0)
                        {
                            forReturn.Add(new NestedInteger(numTemp));
                            numTemp = 0;
                        }
                        break;

                    case '-':
                        numTemp *= -1;
                        break;

                    default:
                        numTemp = numTemp * 10 + int.Parse(curChar.ToString());
                        break;
                }
            }

            if (numTemp != 0)
                forReturn.SetInteger(numTemp);

            return forReturn;
        }
    }
}
