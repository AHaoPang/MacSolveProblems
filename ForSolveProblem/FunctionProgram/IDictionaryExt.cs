using System;
using System.Collections.Generic;

namespace ForSolveProblem.FunctionProgram
{
    public static class IDictionaryExt
    {
        public static Option<T> Lookup<K, T>(this IDictionary<K, T> dict, K key)
            => dict.TryGetValue(key, out var value) ? F.Some(value) : F.None;
    }
}
