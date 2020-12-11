using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace ForSolveProblem
{
    public class VarianceLearn : IProblem
    {
        public void RunProblem()
        {
            var newArray = new Planet[] { new Planet() { Name = "PyhPlanet", Mass = 10 } };

            CoVariantArray(newArray);

            //UnsafeVariantArray(newArray);

            CovariantGeneric(newArray);

            InvariantGeneric(newArray);

            var testList = new List<Planet> { new Planet() { Name = "PyhPlanet", Mass = 10 } };
            //InvariantGeneric(testList);

        }

        public abstract class CelestialBody : IComparable<CelestialBody>
        {
            public int CompareTo([AllowNull] CelestialBody other)
            {
                throw new NotImplementedException();
            }

            public double Mass { get; set; }

            public string Name { get; set; }
        }

        public class Planet : CelestialBody { }

        public class Moon : CelestialBody { }

        public class Asteroid : CelestialBody { }


        public static void CoVariantArray(CelestialBody[] baseItems)
        {
            foreach (var thing in baseItems)
                Console.WriteLine($"{thing.Name} has a mass of {thing.Mass} Kg");
        }

        public static void UnsafeVariantArray(CelestialBody[] baseItems)
        {
            baseItems[0] = new Asteroid { Name = "Hygiea", Mass = 8.85e19 };
        }

        public static void CovariantGeneric(IEnumerable<CelestialBody> baseItems)
        {
            foreach (var item in baseItems)
                Console.WriteLine($"{item.Name} has a mass of {item.Mass} Kg");
        }

        public static void InvariantGeneric(IList<CelestialBody> baseItems)
        {
            baseItems[0] = new Asteroid() { Name = "Hygiea", Mass = 8.85e19 };
        }

        interface IContravariant<in A> where A : class { }

        interface IExtContravariant<in A> : IContravariant<A> where A : class { }

        class Sample<A> : IContravariant<A> where A : class { }

        public void Test()
        {
            IContravariant<Object> iobj = new Sample<Object>();
            IContravariant<string> istr = new Sample<string>();

            istr = iobj;
            //iobj = istr;
        }

        public delegate void DContravariant<in A>(A argument);

        //public static void SampleControl(Control)

        interface ICovariant<out R> where R : class { }

        interface IExtCovariant<out R> : ICovariant<R> where R : class { }

        class Sample2<R> : ICovariant<R> where R : class { }

        //这种机制，可以让泛型接口和委托适用于更多的场景，同时拥有编译时的安全性

        public interface ICovariantTest2<out S>
        {
            S GetSomething();
        }

        public interface ICovariantTest3<S> : ICovariantTest2<S> { }

        //public interface ICovariantTest4<in S> : ICovariantTest2<S> { }
    }


}
