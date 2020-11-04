<<<<<<< HEAD:ForSolveProblem/FunctionProgram/Option/Some.cs
﻿using System;
namespace ForSolveProblem.FunctionProgram.Option
{
    public struct Some<T>
    {
        internal T Value { get; }

        internal Some(T value)
        {
            if (value == null)
                throw new ArgumentNullException();

            Value = value;
        }
    }
}
=======
namespace ForSolveProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            new Problem5500().RunProblem();
        }
    }
}


>>>>>>> f9cdf63e26c41b4111b80036a648692e34626a18:ForSolveProblem/Program.cs
