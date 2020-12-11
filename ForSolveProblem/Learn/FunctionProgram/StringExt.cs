using System;
namespace ForSolveProblem.FunctionProgram
{
    public static class StringExt
    {
        public static string ToSentenceCase(this string s)
            => s == null ? s : s.ToUpper()[0] + s.ToLower().Substring(1);
    }
}
