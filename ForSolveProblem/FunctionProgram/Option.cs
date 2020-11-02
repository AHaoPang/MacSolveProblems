using System;
using System.Collections.Generic;

namespace ForSolveProblem.FunctionProgram
{
    /// <summary>
    /// Option 定义的特征
    ///
    /// 1. None 值表示无值
    /// 2. Some 表示存在一个值
    /// 3. 一个可以根据是否存在值来执行代码的方法
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public struct Option<T>
    {
        private readonly bool isSome;
        private readonly T value;

        private Option(T value)
        {
            this.isSome = true;
            this.value = value;
        }

        public static implicit operator Option<T>(Option.None _) => new Option<T>();

        public static implicit operator Option<T>(Option.Some<T> some) => new Option<T>(some.Value);

        public static implicit operator Option<T>(T value) => value == null ? F.None : F.Some(value);

        public R Match<R>(Func<R> noneFunc, Func<T, R> someFunc) => isSome ? someFunc(value) : noneFunc();

        public IEnumerable<T> AsEnumerable()
        {
            if (isSome)
                yield return value;
        }
    }
}
