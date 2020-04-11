using System;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem929 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int NumUniqueEmails(string[] emails)
        {
            return emails.Select(i =>
            {
                var strArr = i.Split(new[] { '@' }, StringSplitOptions.RemoveEmptyEntries);
                if (strArr.Length != 2) return "";

                var emailStr = strArr[0].Where(c => c != '.').TakeWhile(c => c != '+');
                return new string(emailStr.ToArray()) + "@" + strArr[1];
            }).ToHashSet().Count;
        }
    }
}
