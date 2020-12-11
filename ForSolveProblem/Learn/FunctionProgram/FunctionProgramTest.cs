using System;
using System.Collections.Generic;
using System.Linq;
using ForSolveProblem.FunctionProgram;

namespace ForSolveProblem
{
    public class FunctionProgramTest : IProblem
    {
        public void RunProblem()
        {
            StringExt_ToSentenceCase_Test();
        }

        private void StringExt_ToSentenceCase_Test()
        {
            var shoppingList = new List<string> { "coffee beans", "BANANAS", "Dates" };

            var t = shoppingList.Select(StringExt.ToSentenceCase).ToList();
            var t2 = shoppingList.AsParallel().Select(StringExt.ToSentenceCase).ToList();

            var t3 = shoppingList
                .Select(StringExt.ToSentenceCase)
                .Zip(Enumerable.Range(0, shoppingList.Count), (l, r) => $"{r}. {l}")
                .ToList();

            var t4 = shoppingList.AsParallel()
                .Select(StringExt.ToSentenceCase)
                .Zip(ParallelEnumerable.Range(0, shoppingList.Count), (l, r) => $"{r}. {l}")
                .ToList();
        }
    }
}
