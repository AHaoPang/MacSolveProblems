using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ForSolveProblem
{
    public class ReflectionLearn : IProblem
    {
        public ReflectionLearn()
        {
            //var assArray = AppDomain.CurrentDomain.GetAssemblies();

            var s = new string('a', 9);

            

            var ass = Assembly.Load("ForSolveProblem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null");
            var strArr = ass.ExportedTypes.Select(i => i.FullName).ToList();

            var index = 0;
            strArr.ForEach(i => Console.WriteLine($"{index++}:{i}"));

            Console.ReadKey();
        }
                   
        public void RunProblem()
        {
            throw new NotImplementedException();
        }
    }
}
