using System;
namespace ForSolveProblem.FunctionProgram
{
    public class AgeTest
    {
        public AgeTest()
        {
        }


        public struct Age
        {
            private int Value { get; }

            private Age(int value)
            {
                if (!IsValid(value))
                    throw new ArgumentOutOfRangeException($"{value} is not a valid age");

                Value = value;
            }

            /// <summary>
            /// 返回一个 option 的智能构造函数
            /// </summary>
            /// <param name="age"></param>
            /// <returns></returns>
            public static Option<Age> Of(int age)
                => IsValid(age) ? F.Some(new Age(age)) : F.None;

            private static bool IsValid(int age)
                => age >= 0 && age < 120;
        }
    }
}
