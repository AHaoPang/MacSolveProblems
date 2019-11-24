using ForSolveProblem;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SolutionTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var p = new Problem5273();
            p.RunProblem();
        }
    }
}
