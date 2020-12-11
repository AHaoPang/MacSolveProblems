using System;
using Unit = System.ValueTuple;

namespace ForSolveProblem.FunctionProgram
{
    public static class ActionExt
    {
        public static Func<Unit> ToFunc(this Action action)
            => () => { action(); return F.Unit(); };

        public static Func<T, Unit> ToFunc<T>(this Action<T> action)
            => (t) => { action(t); return F.Unit(); };
    }
}
