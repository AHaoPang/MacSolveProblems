using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace ForSolveProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new Problem460();

            p.RunProblem();


            
        }
    }

    [AttributeUsage(AttributeTargets.Enum, Inherited = false)]
    class FlagsAttribute : Attribute
    {
        public FlagsAttribute()
        {

        }
    }
}


