using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class DynamicLearn : IProblem
    {
        public DynamicLearn()
        {
        }

        public void RunProblem()
        {
            var v1 = Add(1, 2);
            var v2 = Add("1", "2");
            var v3 = Add(1.0, 2.0);

            Test2();
        }

        private dynamic Add(dynamic a, dynamic b) => a + b;

        private class MyType
        {
            public MyType(string str) => StringMember = str;

            public string StringMember { get; }

            public static implicit operator string(MyType myType) => myType.StringMember;

            public static implicit operator MyType(string str) => new MyType(str);
        }



        private void Test1()
        {
            var strArr = new[] { "a", "b", "c" };
            var tempArr = strArr.Cast<MyType>();
            try
            {
                foreach (var item in tempArr)
                    Console.WriteLine(item);
            }
            catch (Exception)
            {
            }
        }

        private void Test2()
        {
            var strArr = new[] { "a", "b", "c" };
            var tempArr = strArr.Convert<MyType>();

            foreach (var item in tempArr)
                Console.WriteLine(item);
        }
    }

    public static class IEnumerableExt
    {
        public static IEnumerable<TResult> Convert<TResult>(this IEnumerable datas)
        {
            foreach (var item in datas)
            {
                var d = (dynamic)item;
                yield return (TResult)d;
            }
        }
    }
}
