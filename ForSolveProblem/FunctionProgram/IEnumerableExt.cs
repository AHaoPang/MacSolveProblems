using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Unit = System.ValueTuple;

namespace ForSolveProblem.FunctionProgram
{
    public static class IEnumerableExt
    {
        public static IEnumerable<R> Map<T, R>(this IEnumerable<T> ts, Func<T, R> f)
            => ts.Select(f);

        public static Option<R> Map<T, R>(this Option<T> optT, Func<T, R> f)
            => optT.Match(
                () => F.None,
                (t) => F.Some(f(t)));

        public static IEnumerable<Unit> ForEach<T>(this IEnumerable<T> ts, Action<T> action)
            => ts.Map(action.ToFunc()).ToImmutableList();

        public static Option<Unit> ForEach<T>(this Option<T> optT, Action<T> action)
            => optT.Map(action.ToFunc());

        public static Option<R> Bind<T, R>(this Option<T> optT, Func<T, Option<R>> f)
            => optT.Match(
                () => F.None,
                (t) => f(t));

        public static IEnumerable<R> Bind<T, R>(this IEnumerable<T> ts, Func<T, IEnumerable<R>> f)
            => ts.SelectMany(f);

        public static IEnumerable<R> Bind<T, R>(this IEnumerable<T> ts, Func<T, Option<R>> f)
            => ts.Bind(t => f(t).AsEnumerable());

        public static IEnumerable<R> Bind<T, R>(this Option<T> optT, Func<T, IEnumerable<R>> f)
            => optT.AsEnumerable().Bind(f);

        public static IEnumerable<T> List<T>(params T[] items)
            => items.ToImmutableList();

        public static Option<T> Where<T>(this Option<T> optT, Func<T, bool> pred)
            => optT.Match(
                () => F.None,
                t => pred(t) ? optT : F.None);
    }
}
