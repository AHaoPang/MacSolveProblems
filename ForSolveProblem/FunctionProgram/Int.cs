using System;
using ForSolveProblem.FunctionProgram.Option;

namespace ForSolveProblem.FunctionProgram
{
    public static class Int
    {
        /// <summary>
        /// string -> option<int>
        /// 将数据从一种形式转换为另一种更具限制性的形式
        /// </summary>
        public static Option<int> Parse(string s)
            => int.TryParse(s, out var res) ? F.Some(res) : F.None;
    }
}
