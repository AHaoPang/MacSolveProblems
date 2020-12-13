using System;
using Unit = System.ValueTuple;

namespace ForSolveProblem.FunctionProgram
{
    /// <summary>
    /// 包含函数式库的核心函数
    /// </summary>
    public static class F
    {
        public static R Using<TDisp, R>(TDisp disposable, Func<TDisp, R> f) where TDisp : IDisposable
        {
            using (disposable) return f(disposable);
        }

        public static Unit Unit() => default(Unit);

        public static Option<T> Some<T>(T value) => new Option.Some<T>(value);

        public static Option.None None => Option.None.Default;
    }
}
